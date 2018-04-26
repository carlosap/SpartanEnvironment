using System;
using System.Threading.Tasks;
namespace SpartanEnvironment
{
    public interface IEnviroment
    {
        Task SetAsync(string name, string value, EnvironmentVariableTarget target);
        void Set(string name, string value, EnvironmentVariableTarget target);
        Task Delete(string name, EnvironmentVariableTarget target);
        string Get(string name, EnvironmentVariableTarget target);

    }
}
