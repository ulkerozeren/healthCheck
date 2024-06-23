namespace HealthCheck.Business.Dto
{
    public class ApplicationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Mail { get; set; }
        public string MailSubject { get; set; }
        public string MailBody { get; set; }
        public int NotificationTypeId { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
