using System.Threading.Tasks;
namespace SpartanEnvironment
{
    public interface IEnviroment
    {
        Task SetAsync(string name, string value);
        Task Delete(string name);
        void Set(string name, string value);
        string Get(string name);

    }
}
