namespace HealthCheck.Core.Response
{
    public class BaseServiceResult<TStatus>
    {
        public string? Message { get; set; }
        public List<string?> ValidationMessages { get; set; }
        public TStatus? Status { get; set; }

        protected BaseServiceResult()
        {
            ValidationMessages = new List<string?>();
        }
    }

    public class BasePaginationServiceListResult<TStatus> : BaseServiceResult<TStatus>
    {
        public int TotalNumberOfPages { get; set; }

        public int TotalNumberOfRecords { get; set; }
    }
}
