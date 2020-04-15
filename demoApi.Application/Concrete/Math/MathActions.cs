using demoApi.Application.DTO;
using demoApi.Concrete;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace demoApi.Application
{
    public class MathActions : IMathActions
    {
        public async Task<ActionResponse> Add(ActionRequest request )
        {
            var response = new ActionResponse();
            if (request.numbers.Count < 2)
            {
                response.IsSuccedded = false;
                response.Reason = "need at least 2 argument";
                return response;
            }

            return new ActionResponse
            {
                Results = request.numbers[0] + request.numbers[1],
                ActionType ="Add"
            };
        }

        public async Task<ActionResponse> Devide(ActionRequest request)
        {
            var response = new ActionResponse();

            if (request.numbers[1] == 0)
            {
                response.IsSuccedded = false;
                response.Reason = "can't devide by 0 in Devide action";
            }

            return new ActionResponse
            {
                Results = request.numbers[0] / request.numbers[1],
                ActionType = "Devide"
            };
        }
    }
}
