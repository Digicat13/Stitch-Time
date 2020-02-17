using System.Collections.Generic;

namespace StitchTime.Core.Errors
{
    public class ErrorResponse
    {
        public List<ErrorDto> Errors { get; set; } = new List<ErrorDto>();
    }
}
