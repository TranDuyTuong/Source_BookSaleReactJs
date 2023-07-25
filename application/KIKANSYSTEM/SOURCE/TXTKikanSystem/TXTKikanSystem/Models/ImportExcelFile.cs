using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TXTKikanSystem.Models
{
    public class ImportExcelFile
    {
        /// <summary>
        /// ImportExcelBook
        /// </summary>
        public IFormFile ImportExcelBook 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Carshier
        /// </summary>
        public string Carshier
        {
            get;
            set;
        }
    }
}
