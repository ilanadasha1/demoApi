using demoApi.Infrastracture.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace demoApi.Infrastracture
{
    public class DBProvider : IDBProvider
    {
        private readonly List<Position> _PositionsTable = new List<Position>();

        public async Task<Position> SavePosition(Position position)
        {
            if (_PositionsTable.Find(x => x.PositionId == position.PositionId && x.PositionId != default(Guid)) == null)
            {
                _PositionsTable.Add(position);
                await Task.Delay(1);
                return position;
            }
            throw new Exception("Position not saved");
        }

        public async Task<Position> GetPosition(Guid positionId)
        {
            await Task.Delay(1);
            return _PositionsTable.Find(x => x.PositionId == positionId);
        }

        public async Task<Position> GetPosition()
        {
            await Task.Delay(1);
            return _PositionsTable.FindLast(x => x != null);
        }

        public async Task UpdatePosition(Guid positionId, Position position)
        {
            _PositionsTable.Find(x => x.PositionId == positionId).X = position.X;
            _PositionsTable.Find(x => x.PositionId == positionId).Y = position.Y;
            _PositionsTable.Find(x => x.PositionId == positionId).Z = position.Z;
            await Task.Delay(1);
        }
    }
}
