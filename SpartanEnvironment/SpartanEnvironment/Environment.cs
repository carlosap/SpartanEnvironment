using System;
using System.Threading.Tasks;
using static System.Environment;
namespace SpartanEnvironment
{
    public class Environment : IEnviroment
    {
        const string _appPrefix = "Spartan_";
        public string Get(string name, EnvironmentVariableTarget target = EnvironmentVariableTarget.Process)
        {
            string retVal = string.Empty;
            if (!string.IsNullOrWhiteSpace(name))
            {
                retVal = GetEnvironmentVariable(_appPrefix + name, target);
            }
            return retVal;
        }

        public string GetUserVariable(string name)
        {
            string retVal = string.Empty;
            if (!string.IsNullOrWhiteSpace(name))
            {
                retVal = Get(_appPrefix + name, EnvironmentVariableTarget.User);
            }
            return retVal;
        }

        public void Set(string name, string value, EnvironmentVariableTarget target = EnvironmentVariableTarget.Process)
        {
            if(!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(value))
            {
                SetEnvironmentVariable(_appPrefix + name, value, target);
            }   
        }

        public void SetUserVariable(string name, string value)
        {
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(value))
            {
                SetAsync(_appPrefix + name, value, EnvironmentVariableTarget.User);
            }
        }


        /// <summary>
        /// You need special permissions for this. Need to admin.
        /// or when application is completed run as admin.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetMachineVariable(string name, string value)
        {
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(value))
            {
                Set(_appPrefix + name, value, EnvironmentVariableTarget.Machine);
            }
        }

        public Task SetAsync(string name, string value, EnvironmentVariableTarget target = EnvironmentVariableTarget.Process) => Task.Run(async () =>
        {
            await Task.Run(() =>
            {
                if(!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(value))
                {
                    SetEnvironmentVariable(_appPrefix + name, value, target);
                }
                
            });
        });

        public void DeleteUserVariable(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                Delete(_appPrefix + name, EnvironmentVariableTarget.User);
            }
        }

        public Task Delete(string name, EnvironmentVariableTarget target = EnvironmentVariableTarget.Process) => Task.Run(async () =>
        {
            await Task.Run(() =>
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    SetEnvironmentVariable(_appPrefix + name, null, target);
                }
            });
        });
    }
}
