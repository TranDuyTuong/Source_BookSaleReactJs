using ModelConfiguration.M_KikanSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationInterfaces.KikanSystem
{
    public interface IHomeInitialization
    {
        /// <summary>
        /// initializationDataHome
        /// </summary>
        /// <returns></returns>
        Task<InitializationDataHome> initializationDataHome();
    }
}
