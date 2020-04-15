using demoApi.Application.Abstract.Motion;
using demoApi.Application.DTO;
using demoApi.Application.DTO.Motion;
using demoApi.Infrastracture;
using demoApi.Infrastracture.DTO;
using System;
using System.Threading.Tasks;

namespace demoApi.Application.Concrete
{
    public class MotionService : IMotionService
    {
        private readonly IDBProvider _DBProvider;

        public MotionService(IDBProvider DBProvider)
        {
            _DBProvider = DBProvider;
        }

        public async Task<HandlerResponse> Move(Position position)
        {
            Console.WriteLine($"Move (X={position.X}, Y={position.Y}, Z={position.Z})");
            var response = new HandlerResponse() 
            { 
                Status = CommandStatus.Ack, Type = "Move", position = position 
            };
            return response;
        }

        public async Task<HandlerResponse> Lock()
        {
            Console.WriteLine($"Lock");
            return new HandlerResponse() { Status = CommandStatus.Ack, Type = "Lock", position = new Position() { PositionId = Guid.NewGuid() } };
        }

        public async Task<HandlerResponse> Unlock()
        {
            Console.WriteLine($"UnLock");
            return new HandlerResponse() { Status = CommandStatus.Ack, Type = "Unlock", position = new Position() { PositionId = Guid.NewGuid() }};
        }

        public async Task<HandlerResponse> SavePosition()
        {
            try
            {
                var currentPosition = GenearteRndPosition(); ;  // got from handler
                var position = await _DBProvider.SavePosition(currentPosition);
                return new HandlerResponse() { Status = CommandStatus.Ack, Type = "Save", position = position };
            }
            catch (Exception ex)
            {
                return new HandlerResponse() { ErrorReason = ex.Message };
            }

        }

        public async Task<HandlerResponse> GetPosition(Guid positionId)
        {
            try
            {
                var position = await _DBProvider.GetPosition(positionId);
                if (position == null)
                    return new HandlerResponse() { Type = "Get", ErrorReason = "poistion not found" };
                return new HandlerResponse() { Status = CommandStatus.Ack, Type = "Get", position = position };
            }
            catch (Exception ex)
            {
                return new HandlerResponse() { ErrorReason = ex.Message };
            }
        }

        public async Task<HandlerResponse> GetCurrentPosition()
        {
            try
            {
                var position = await _DBProvider.GetPosition(); // current
                if (position == null)
                    return new HandlerResponse() { Type = "Get", ErrorReason = "current poistion not found" };
                return new HandlerResponse() { Status = CommandStatus.Ack, Type = "Get", position = position };
            }
            catch (Exception ex)
            {
                return new HandlerResponse() { ErrorReason = ex.Message };
            }
        }

        private Position GenearteRndPosition()
        {
            Position rndPosition = new Position();
            Random rnd = new Random();
            rndPosition.X = rnd.Next(-100, 100);
            rndPosition.Y = rnd.Next(-100, 100);
            rndPosition.Z = rnd.Next(-100, 100);
            rndPosition.PositionId = Guid.NewGuid();
            return rndPosition;
        }
    }
}
