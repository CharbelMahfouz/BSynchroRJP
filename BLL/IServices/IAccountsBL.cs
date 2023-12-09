using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface IAccountsBL
    {
        Task<ResponseModel> OpenAccount(OpenAccountDTO model);
    }
}