namespace ToRename.BLL.OutputModels
{
    public class ActionAllInfoOutputModel
    {
        public int Id { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public OptionOutputModel Option { get; set; }
        public bool IsDeleted { get; set; }
    }
}
