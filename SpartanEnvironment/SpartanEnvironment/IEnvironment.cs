using System;
using System.Threading.Tasks;
namespace SpartanEnvironment
{
    public interface IEnviroment
    {
        Task SetAsync(string name, string value, EnvironmentVariableTarget target);
        void Set(string name, string value, EnvironmentVariableTarget target);
        void SetUserVariable(string name, string value);
        Task Delete(string name, EnvironmentVariableTarget target);
        void DeleteUserVariable(string name);
        string Get(string name, EnvironmentVariableTarget target);
        string GetUserVariable(string name);

    }
}
