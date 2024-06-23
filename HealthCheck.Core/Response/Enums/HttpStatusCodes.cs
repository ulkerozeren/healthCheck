namespace HealthCheck.Core.Response.Enums
{
    public static class HttpStatusCodes
    {
        public const int Ok = 200;
        public const int Created = 201;
        public const int ResourceNotFound = 404;
        public const int InvalidInput = 422;
        public const int ResourceExist = 409;
        public const int InternalError = 500;
        public const int PreconditionFailed = 412;
    }
}
