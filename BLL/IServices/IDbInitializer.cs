using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface IDbInitializer
    {
        Task SeedDatabase();
    }
}