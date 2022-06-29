using ToRename.DAL;
using ToRename.DAL.Dtos;
using ToRename.BLL.OutputModels;
using AutoMapper;
using ToRename.BLL.InputModels;

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

        public List<OptionOutputModel> GetOptions()
        {
            List<OptionDto> optionRequest = _manager.GetOptions();
            List<OptionOutputModel> optionView = new List<OptionOutputModel>();

            return _mapper.Map(optionRequest, optionView);
        }

        public ActionAllInfoOutputModel AddAction(ActionInfoInputModel input)
        {

            var actionToAdd = _mapper.Map(input, new ActionAllInfoDto());
            ActionAllInfoDto optionView = _manager.AddAction(actionToAdd);

            return _mapper.Map(optionView, new ActionAllInfoOutputModel());
        }

        public void DeleteACtionById(ActionAllInfoOutputModel input)
        {
            var actionToDelete = _mapper.Map(input, new ActionAllInfoDto());
            _manager.DeleteActionById(actionToDelete);
        }
    }
}