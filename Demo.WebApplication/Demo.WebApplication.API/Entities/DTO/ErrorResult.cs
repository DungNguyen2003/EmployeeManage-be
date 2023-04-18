using Demo.WebApplication.API.Enums;

namespace Demo.WebApplication.API.Entities.DTO
{
    public class ErrorResult
    {
        public ErrorCode ErrorCode { get; set; }

        public string DevMsg { get; set; }

        public string UserMsg { get; set; }

        public string MoreInfo { get; set; }

        public string TraceId { get; set; }

    }
}
