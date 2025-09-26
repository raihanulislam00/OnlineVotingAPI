using System;

namespace BLL.DTOs
{
    public class PollCreateResponseDTO
    {
        public bool IsPollCreated { get; set; }
        public bool IsEmailSent { get; set; }
        public string Message { get; set; }
    }
}