namespace HealthCheck.Core.Response
{
    public class BaseApiResponse
    {
        public string Status { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public List<string> ValidationMessages { get; set; }
        public List<string> ErrorMessages { get; set; }
        public object Data { get; set; }

        public BaseApiResponse()
        {
            ValidationMessages = new List<string>();
            ErrorMessages = new List<string>();
        }
    }

    public class BasePaginationApiResponse : BaseApiResponse
    {
        public int? TotalNumberOfRecords { get; set; }
        public int? TotalNumberOfPages { get; set; }

        public BasePaginationApiResponse()
        {
            ValidationMessages = new List<string>();
            ErrorMessages = new List<string>();
        }
    }
}
