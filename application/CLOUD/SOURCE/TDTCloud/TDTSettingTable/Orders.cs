using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class Orders
    {
        /// <summary>
        /// OrderID
        /// </summary>
        public Guid OrderID
        {
            get;
            set;
        }

        /// <summary>
        /// OrderCode
        /// </summary>
        public string OrderCode
        {
            get;
            set;
        }

        /// <summary>
        /// CustomerID
        /// </summary>
        public Guid CustomerID
        {
            get;
            set;
        }

        /// <summary>
        /// OrderDate
        /// </summary>
        public DateTime OrderDate
        {
            get;
            set;
        }

        /// <summary>
        /// TotalAmountItem
        /// </summary>
        public int TotalAmountItem
        {
            get;
            set;
        }

        /// <summary>
        /// FullName
        /// </summary>
        public string FullName
        {
            get;
            set;
        }

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone
        {
            get;
            set;
        }

        /// <summary>
        /// CityID
        /// </summary>
        public string CityID
        {
            get;
            set;
        }

        /// <summary>
        /// DistrictID
        /// </summary>
        public string DistrictID
        {
            get;
            set;
        }

        /// <summary>
        /// CustomerAddressOrdersID
        /// </summary>
        public string CustomerAddressOrdersID
        {
            get;
            set;
        }

        /// <summary>
        /// TypeAddressID
        /// </summary>
        public string TypeAddressID
        {
            get;
            set;
        }

        /// <summary>
        /// ShipPrice
        /// </summary>
        public decimal ShipPrice
        {
            get;
            set;
        }

        /// <summary>
        /// TotalPrice
        /// </summary>
        public decimal TotalPrice
        {
            get;
            set;
        }

        /// <summary>
        /// ReceiveApplication
        /// </summary>
        public bool ReceiveApplication
        {
            get;
            set;
        }

        /// <summary>
        /// ReceiptStatusID
        /// </summary>
        public string ReceiptStatusID
        {
            get;
            set;
        }

        /// <summary>
        /// PaymentMethodID
        /// </summary>
        public string PaymentMethodID
        {
            get;
            set;
        }

        /// <summary>
        /// StatusPayment
        /// </summary>
        public bool StatusPayment
        {
            get;
            set;
        }

        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// EstimatedDeliveryDate
        /// </summary>
        public DateTime? EstimatedDeliveryDate
        {
            get;
            set;
        }

        /// <summary>
        /// IsDelete
        /// </summary>
        public bool IsDelete
        {
            get;
            set;
        }

        /// <summary>
        /// IsSuccess
        /// </summary>
        public bool IsSuccess
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
        /// Note
        /// </summary>
        public string Note
        {
            get;
            set;
        }

        /// <summary>
        /// DateTimeCustomerGetItem
        /// </summary>
        public DateTime? DateTimeCustomerGetItem
        {
            get;
            set;
        }

        /// <summary>
        /// TotalPoint
        /// </summary>
        public int TotalPoint
        {
            get;
            set;
        }

        /// <summary>
        /// FreeShipProgram
        /// </summary>
        public bool FreeShipProgram
        {
            get;
            set;
        }

        /// <summary>
        /// BankID
        /// </summary>
        public string BankID
        {
            get;
            set;
        }
    }
}
