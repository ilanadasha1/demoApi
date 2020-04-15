using System;

namespace demoApi.Infrastracture.DTO
{
    public class Position
    {
        public Guid PositionId { set; get; }
        public int X { set; get; }
        public int Y { set; get; }
        public int Z { set; get; }
    }
}