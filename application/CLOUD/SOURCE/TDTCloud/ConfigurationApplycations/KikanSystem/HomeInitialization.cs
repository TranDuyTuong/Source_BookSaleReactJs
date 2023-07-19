using CodeFirtMigration.DataFE;
using ConfigurationInterfaces.KikanSystem;
using ModelConfiguration.M_KikanSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ConfigurationApplycations.KikanSystem
{
    public class HomeInitialization : IHomeInitialization
    {
        private readonly ContextFE context;
        public HomeInitialization(ContextFE _context)
        {
            this.context = _context;
        }

        /// <summary>
        /// initializationDataHome
        /// </summary>
        /// <returns></returns>

        public async Task<InitializationDataHome> initializationDataHome()
        {
            var result = new InitializationDataHome();
            try
            {
                var queryBooks = from bo in this.context.itemMasters
                                 select bo;

                var queryCategory = from ca in this.context.categoryItemMasters
                                    select ca;

                var queryCitys = from cy in this.context.citys
                                 select cy;

                var queryDistricts = from dt in this.context.districts
                                     select dt;

                var queryAuthors = from au in this.context.authors
                                   select au;

                var queryPublishingCompany = from pc in this.context.issuingCompanies
                                             select pc;

                var queryPublisher = from pl in this.context.publishingCompanies
                                     select pl;

                List<string> listNumber = new List<string>();
                // Add number data in list
                for (int i = 1; i <= 7; i++)
                {
                    switch (i)
                    {
                        case 1:
                            listNumber.Add("Books" + "_" + queryBooks.Count());
                            break;
                        case 2:
                            listNumber.Add("Category" + "_" + queryCategory.Count());
                            break;
                        case 3:
                            listNumber.Add("City" + "_" + queryCitys.Count());
                            break;
                        case 4:
                            listNumber.Add("District" + "_" + queryDistricts.Count());
                            break;
                        case 5:
                            listNumber.Add("Auhtors" + "_" + queryAuthors.Count());
                            break;
                        case 6:
                            listNumber.Add("PublishingCompany" + "_" + queryPublishingCompany.Count());
                            break;
                        case 7:
                            listNumber.Add("Publisher" + "_" + queryPublisher.Count());
                            break;
                        default:
                            break;
                    }
                }
                // Setting data result
                result.Status = true;
                result.EventCode = CommonConfiguration.DataCommon.EventInitialization;
                result.ListDataInitia = listNumber;
                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.EventCode = CommonConfiguration.DataCommon.EventError;
                result.MessageErroe = ex.Message;
                return result;
            }
        }
    }
}
