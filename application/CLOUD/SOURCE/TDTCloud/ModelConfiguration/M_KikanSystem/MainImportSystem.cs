﻿using ModelConfiguration.M_KikanSystem.ImportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelConfiguration.M_KikanSystem
{
    public class MainImportSystem
    {
        /// <summary>
        /// listBooks
        /// </summary>
        public List<BooksImport> listBooks
        {
            get;
            set;
        } = new List<BooksImport>();

        /// <summary>
        /// listAuthor
        /// </summary>
        public List<AuthorsImport> listAuthor
        {
            get;
            set;
        } = new List<AuthorsImport>();

        /// <summary>
        /// listpublishingCompany
        /// </summary>
        public List<PublishingCompanyImport> listPublishingCompany
        {
            get;
            set;
        } = new List<PublishingCompanyImport>();

        /// <summary>
        /// listCitysImports
        /// </summary>
        public List<CitysImport> listCitys
        {
            get;
            set;
        } = new List<CitysImport>();

        /// <summary>
        /// listCategorys
        /// </summary>
        public List<CategorysImport> listCategorys
        {
            get;
            set;
        } = new List<CategorysImport>();

        /// <summary>
        /// listDitricts
        /// </summary>
        public List<DistrictsImport> listDistrict
        {
            get;
            set;
        } = new List<DistrictsImport>();

        /// <summary>
        /// 
        /// </summary>
        public List<BankSupportImport> listBankSupport
        {
            get;
            set;
        } = new List<BankSupportImport>();

        /// <summary>
        /// ListIssuingCompany
        /// </summary>
        public List<IssuingCompanyImport> listIssuingCompany
        {
            get;
            set;
        } = new List<IssuingCompanyImport>();

        /// <summary>
        /// FileName
        /// </summary>
        public string FileName
        {
            get;
            set;
        }

        /// <summary>
        /// TypeImport
        /// </summary>
        public string TypeImport
        {
            get;
            set;
        }

        /// <summary>
        /// UserID
        /// </summary>
        public string UserID
        {
            get;
            set;
        }

        /// <summary>
        /// RoleID
        /// </summary>
        public string RoleID
        {
            get;
            set;
        }

        /// <summary>
        /// Token
        /// </summary>
        public string Token
        {
            get;
            set;
        }

        /// <summary>
        /// EventCode
        /// </summary>
        public string EventCode
        {
            get;
            set;
        }

        /// <summary>
        /// Company
        /// </summary>
        public string Company
        {
            get;
            set;
        }

        /// <summary>
        /// AreaCode
        /// </summary>
        public string AreaCode
        {
            get;
            set;
        }

        /// <summary>
        /// StoreCode
        /// </summary>
        public string StoreCode
        {
            get;
            set;
        }
    }
}
