using ToRename.BLL.OutputModels;

namespace ToRename.BLL.InputModels
{
    public class ActionInfoInputModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public OptionOutputModel Option { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
