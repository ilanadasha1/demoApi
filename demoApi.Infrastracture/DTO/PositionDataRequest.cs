using System;
using System.Collections.Generic;
using System.Text;

namespace demoApi.Infrastracture.DTO
{
    class PositionDataRequest
    {
        int PositionId { get; set; }
        Position Position { get; set; }
        DateTime Time { get; set; }
    }
}
