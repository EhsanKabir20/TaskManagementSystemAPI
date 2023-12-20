using Microsoft.AspNetCore.Http.Extensions;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Data.DTOs
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }
        public string RequestUrl { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string ShortDescription { get; set; }
        public int SignedInContact { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }

        public static Log ErrorLog(string errorMessage, string description, IHttpContextAccessor httpContextAccessor)
        {
            return new Log
            {
                RequestUrl = httpContextAccessor.HttpContext.Request.GetDisplayUrl(),
                IsSuccess = false,
                ErrorMessage = errorMessage,
                ShortDescription = description,
                CreatedDateTime = DateTimeOffset.Now
            };
        }
    }
}
