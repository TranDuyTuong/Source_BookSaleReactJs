using ModelConfiguration.M_KikanSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationInterfaces.KikanSystem
{
    public interface IimportDataKikanSystem
    {
        /// <summary>
        /// GetTemplateImport
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<TemplateImportKikanSystem> GetTemplateImport(TemplateImportKikanSystem request);
    }
}
