using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirtMigration.DataFE
{
    public class ContextFactory : IDesignTimeDbContextFactory<ContextFE>
    {
        public ContextFE CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("SettingConnectionString.json").Build();
            var connectionstring = configuration.GetConnectionString("TXTCloud");
            var optionBuilder = new DbContextOptionsBuilder<ContextFE>();
            optionBuilder.UseSqlServer(connectionstring);
            return new ContextFE(optionBuilder.Options);
        }
    }
}
