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
    }
}