namespace ToRename.DAL.Dtos
{
    public class OptionAllInfoDto
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ActionDto Action { get; set; }
        public bool IsDeleted { get; set; }
    }
}
