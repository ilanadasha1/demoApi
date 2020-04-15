using demoApi.Application.DTO;
using demoApi.Concrete;
using System.Threading.Tasks;

namespace demoApi.Application
{
    public interface IMathActions
    {
        Task<ActionResponse> Add(ActionRequest request);
        Task<ActionResponse> Devide(ActionRequest request);
    }
}