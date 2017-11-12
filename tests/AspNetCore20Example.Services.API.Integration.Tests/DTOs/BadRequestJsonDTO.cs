using System.Collections.Generic;

namespace AspNetCore20Example.Services.API.Integration.Tests.DTOs
{
    public class BadRequestJsonDTO
    {
        public bool success { get; set; }
        public IEnumerable<string> errors { get; set; }
    }

}
