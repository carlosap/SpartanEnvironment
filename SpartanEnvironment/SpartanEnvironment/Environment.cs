using System.Threading.Tasks;
using static System.Environment;
namespace SpartanEnvironment
{
    public class Environment : IEnviroment
    {

        public string Get(string name)
        {
            string retVal = string.Empty;
            if (!string.IsNullOrWhiteSpace(name))
            {
                retVal = GetEnvironmentVariable(name);
            }
            return retVal;
        }

        public void Set(string name, string value)
        {
            if(!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(value))
            {
                SetEnvironmentVariable(name, value);
            }   
        }

        public Task SetAsync(string name, string value) => Task.Run(async () =>
        {
            await Task.Run(() =>
            {
                if(!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(value))
                {
                    SetEnvironmentVariable(name, value);
                }
                
            });
        });

        public Task Delete(string name) => Task.Run(async () =>
        {
            await Task.Run(() =>
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    SetEnvironmentVariable(name, null);
                }
            });
        });
    }
}
