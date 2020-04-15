using demoApi.Application.DTO;
using demoApi.Infrastracture.DTO;
using System;
using System.Threading.Tasks;

namespace demoApi.Application.Abstract.Motion
{
    public interface IMotionService
    {
        Task<HandlerResponse> Move(Position position);
        Task<HandlerResponse> Lock();
        Task<HandlerResponse> Unlock();
        Task<HandlerResponse> SavePosition();
        Task<HandlerResponse> GetPosition(Guid positionId);
        Task<HandlerResponse> GetCurrentPosition();
    }
}
