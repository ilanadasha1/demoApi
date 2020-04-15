using demoApi.Infrastracture.DTO;
using System;
using System.Threading.Tasks;

namespace demoApi.Infrastracture
{
    public interface IDBProvider
    {
        Task<Position> SavePosition(Position position);
        Task<Position> GetPosition(Guid positionId);
        Task<Position> GetPosition();
        Task UpdatePosition(Guid positionId, Position position);
    }
}