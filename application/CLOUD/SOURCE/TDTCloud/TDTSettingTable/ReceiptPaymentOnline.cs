using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class ReceiptPaymentOnline
    {
        /// <summary>
        /// ReceiptPaymentOnlineID
        /// </summary>
        public Guid ReceiptPaymentOnlineID
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
        /// OrderDescription
        /// </summary>
        public string OrderDescription
        {
            get;
            set;
        }

        /// <summary>
        /// TransactionId
        /// </summary>
        public string TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// OrderId
        /// </summary>
        public string OrderId
        {
            get;
            set;
        }

        /// <summary>
        /// PaymentMethod
        /// </summary>
        public string PaymentMethod
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
        /// token
        /// </summary>
        public string token
        {
            get;
            set;
        }

        /// <summary>
        /// vnPayResponseCode
        /// </summary>
        public string vnPayResponseCode
        {
            get;
            set;
        }

        /// <summary>
        /// DateCreate
        /// </summary>
        public DateTime DateCreate
        {
            get;
            set;
        }

        /// <summary>
        /// TotalMoney
        /// </summary>
        public decimal TotalMoney
        {
            get;
            set;
        }

        /// <summary>
        /// TransactionExecutionTime
        /// </summary>
        public TimeSpan TransactionExecutionTime
        {
            get;
            set;
        }

        /// <summary>
        /// IsDeleteFlag
        /// </summary>
        public bool IsDeleteFlag
        {
            get;
            set;
        }

        /// <summary>
        /// BankPayment
        /// </summary>
        public string BankPayment
        {
            get;
            set;
        }

        /// <summary>
        /// BankCode
        /// </summary>
        public string BankCode
        {
            get;
            set;
        }

        /// <summary>
        /// TimeCreate
        /// </summary>
        public TimeSpan TimeCreate
        {
            get;
            set;
        }
    }
}
