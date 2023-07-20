using CodeFirtMigration.DataFE;
using ConfigurationInterfaces.KikanSystem;
using Microsoft.EntityFrameworkCore;
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

        public async Task<InitializationDataHome> initializationDataHome(string companyCode, string areaCode, string storeCode)
        {
            var result = new InitializationDataHome();
            try
            {
                // check Company, Area, Store
                bool checkBaseInfo = await this.ValidationInfoBase(companyCode, areaCode, storeCode);
                if (!checkBaseInfo)
                {
                    result.Status = false;
                    result.EventCode = CommonConfiguration.DataCommon.EventError;
                    result.MessageErroe = CommonConfiguration.DataCommon.MessageBaseInfo;
                    return result;
                }
                else
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

                    var queryBank = from ba in this.context.bankSuports
                                    select ba;

                    List<string> listNumber = new List<string>();
                    // Add number data in list
                    for (int i = 1; i <= 8; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                listNumber.Add("Books" + "_" + queryBooks.ToList().Count());
                                break;
                            case 2:
                                listNumber.Add("Category" + "_" + queryCategory.ToList().Count());
                                break;
                            case 3:
                                listNumber.Add("City" + "_" + queryCitys.ToList().Count());
                                break;
                            case 4:
                                listNumber.Add("District" + "_" + queryDistricts.ToList().Count());
                                break;
                            case 5:
                                listNumber.Add("Authors" + "_" + queryAuthors.ToList().Count());
                                break;
                            case 6:
                                listNumber.Add("PublishingCompany" + "_" + queryPublishingCompany.ToList().Count());
                                break;
                            case 7:
                                listNumber.Add("Publisher" + "_" + queryPublisher.ToList().Count());
                                break;
                            case 8:
                                listNumber.Add("BankSuport" + "_" + queryBank.ToList().Count());
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
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.EventCode = CommonConfiguration.DataCommon.EventError;
                result.MessageErroe = ex.Message;
                return result;
            }
        }

        /// <summary>
        /// ValidationInfoBase
        /// </summary>
        /// <param name="company"></param>
        /// <param name="area"></param>
        /// <param name="store"></param>
        /// <returns></returns>
        private async Task<bool> ValidationInfoBase(string company, string area, string store)
        {
            var result = true;
            // Check Company and Area
            var queryCompanyArea = await this.context.areaMasters
                                    .FirstOrDefaultAsync(x => x.CompanyCode == company && x.AreaCode == area);
            // Check Store
            var queryStore = await this.context.stores.FirstOrDefaultAsync(x => x.StoreCode == store);

            if (queryCompanyArea == null || queryStore == null)
            {
                result = false;
            }

            return result;
        }
    }
}
