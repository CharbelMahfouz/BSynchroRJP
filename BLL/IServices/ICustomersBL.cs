using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface ICustomersBL
    {
        Task<CustomerDTO> GetCustomerDetails(int customerId);
    }
}