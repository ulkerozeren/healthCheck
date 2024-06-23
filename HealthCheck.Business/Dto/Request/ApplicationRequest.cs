namespace HealthCheck.Business.Dto.Request
{
    public class AddApplicationRequest
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Mail { get; set; }
        public string MailSubject { get; set; }
        public string MailBody { get; set; }
        public int NotificationTypeId { get; set; }
    }

    public class DeleteApplicationRequest
    {
        public int Id { get; set; }
    }

    public class UpdateApplicationRequest
    {
        public int AppllicationId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class GetApplicationsByUserRequest
    {
        public int UserId { get; set; }
    }
}
