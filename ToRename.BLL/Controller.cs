using ToRename.DAL;
using ToRename.DAL.Dtos;
using ToRename.BLL.OutputModels;
using AutoMapper;

namespace ToRename.BLL
{
    public class Controller
    {
        private Mapper _mapper = MapperConfigStorage.GetInstance();
        private Manager _manager = new Manager();

        public List<ActionAllInfoOutputModel> GetEmployeeRequestAllInfo()
        {
            List<ActionAllInfoDto> actionRequset = _manager.GetActionAllInfo();
            List<ActionAllInfoOutputModel> actionView = new List<ActionAllInfoOutputModel>();

            return _mapper.Map(actionRequset, actionView);
        }
    }
}