using System;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
