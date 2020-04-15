using demoApi.Application.DTO.Motion;
using demoApi.Infrastracture.DTO;
using System;

namespace demoApi.Application.DTO
{
    public class HandlerResponse
    {
        public Position position { get; set; }
        public string Type { set; get; }
        public CommandStatus Status { get; set; }
        public string ErrorReason { set; get; } = "None";
    }
}
