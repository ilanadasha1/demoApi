using System;
using System.Collections.Generic;
using System.Text;

namespace demoApi.Application.DTO
{
    public class ActionResponse
    {
        public bool IsSuccedded { get; set; } = true;
        public string Reason { get; set; } = "No Error";
        public float Results { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public string ActionType { get; set; }
    }
}
