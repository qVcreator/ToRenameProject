namespace ToRename.DAL.Dtos
{
    public class ActionAllInfoDto
    {
        public int? Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public OptionDto Option { get; set; }
        public bool IsDeleted { get; set; }
    }
}
