using System.Data.SqlClient;
using Dapper;
using ToRename.DAL.Dtos;

namespace ToRename.DAL
{
    public class Manager
    {
        public List<ActionAllInfoDto> GetActionAllInfo()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                List<ActionAllInfoDto> result = new List<ActionAllInfoDto>();

                connection.Query<
                    ActionAllInfoDto,
                    OptionDto,
                    ActionAllInfoDto
                    >
                    (StoredProcedureStorage.GetAllInfoAction,
                    (Action, Option) =>
                    {
                        ActionAllInfoDto crnt = Action;

                        crnt.Option = Option;
                        result.Add(crnt);

                        return crnt;
                    },
                    commandType: System.Data.CommandType.StoredProcedure,
                    splitOn: "id");

                return result;
            }
        }

        public List<OptionDto> GetOptions()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<OptionDto>
                    (StoredProcedureStorage.GetOptions,
                    commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
        }

        public ActionAllInfoDto AddAction(ActionAllInfoDto inputDto)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<ActionAllInfoDto>
                    (StoredProcedureStorage.AddAction,
                    commandType: System.Data.CommandType.StoredProcedure,
                    param: new
                    {
                        @From = inputDto.From,
                        @To = inputDto.To,
                        @StartDate = inputDto.StartTime,
                        @EndDate = inputDto.EndTime,
                        @OptionId = inputDto.Option.Id
                    });
            }
        } 

        public void DeleteActionById(ActionAllInfoDto inputDto)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.Query<ActionAllInfoDto>
                    (StoredProcedureStorage.DeleteActionById,
                    commandType: System.Data.CommandType.StoredProcedure,
                    param: new
                    {
                        @Id = inputDto.Id,
                        @From = inputDto.From,
                        @To = inputDto.To,
                        @StartTime = inputDto.StartTime,
                        @EndTime = inputDto.EndTime,
                        @OptionId = inputDto.Option.Id
                    });
            }
        }
    }
}