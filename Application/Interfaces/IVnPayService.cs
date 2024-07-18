using ServiceLayer.Services.VnPayConfig;
using ServiceLayer.ViewModels.PaymentDTOs;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IVnPayService
    {
        string CreateLink(VnpayOrderInfo orderInfo);

        Task<IPNReponse> IPNReceiver(string vnpTmnCode, string vnpSecureHash, string vnpTxnRef, string vnpTransactionStatus, string vnpResponseCode, string vnpTransactionNo, string vnpBankCode, string vnpAmount, string vnpPayDate, string vnpBankTranNo, string vnpCardType, NameValueCollection requestNameValue);
    }
}