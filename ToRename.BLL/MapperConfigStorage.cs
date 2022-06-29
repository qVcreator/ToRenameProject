using AutoMapper;
using ToRename.DAL.Dtos;
using ToRename.DAL;
using ToRename.BLL.OutputModels;
using ToRename.BLL.InputModels;

namespace ToRename.BLL
{
    public class MapperConfigStorage
    {
        private static Mapper _instance;

        public static Mapper GetInstance()
        {
            if (_instance == null)
                InitializeInstance();
            return _instance!;
        }

        private static void InitializeInstance()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OptionDto, OptionOutputModel>();

                cfg.CreateMap<ActionAllInfoDto, ActionAllInfoOutputModel>();

                cfg.CreateMap<ActionInfoInputModel, ActionAllInfoDto>();

                cfg.CreateMap<ActionAllInfoOutputModel, ActionAllInfoDto>();

                cfg.CreateMap<OptionOutputModel, OptionDto>();
            }));
        }
    }
}