namespace HealthCheck.API.RequestModel
{
    public class AddApplicationRequestModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Mail { get; set; }
        public string MailSubject { get; set; }
        public string MailBody { get; set; }
        public int NotificationTypeId { get; set; }
    }

    public class UpdateApplicationRequestModel
    {
        public string Name { get; set; }
        public string Url { get; set; }

    }
}
