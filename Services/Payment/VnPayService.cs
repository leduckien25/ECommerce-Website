using Microsoft.Extensions.Options;
using System.Net;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.Services.Payment
{
    public class VnPayService
    {
        private readonly VnPayParameter parameters;
        IHttpContextAccessor accessor;

        public VnPayService(IOptions<VnPayParameter> options, IHttpContextAccessor accessor)
        {
            parameters = options.Value;
            this.accessor = accessor;
        }

        public string CreatePaymentUrl(Order order)
        {
            SortedDictionary<string, string> dict = new SortedDictionary<string, string>
            {
                {"vnp_Amount", ((int)(order.TotalAmount*100*850)).ToString() },
                {"vnp_Command", parameters.vnp_Command},
                {"vnp_CreateDate", order.OrderDate.ToString("yyyyMMddHHmmss")},
                {"vnp_CurrCode", parameters.vnp_CurrCode},
                {"vnp_IpAddr", Helper.GetIdAddress(accessor.HttpContext!)},
                {"vnp_Locale", parameters.vnp_Locale},
                {"vnp_OrderInfo", $"parameter for {order.OrderId} with amount {order.TotalAmount.ToString()}"},
                {"vnp_OrderType", parameters.vnp_OrderType},
                {"vnp_ReturnUrl", parameters.vnp_ReturnUrl},
                {"vnp_TmnCode", parameters.vnp_TmnCode},
                {"vnp_TxnRef", order.OrderId.ToString()},
                {"vnp_Version", parameters.vnp_Version},
                {"vnp_ExpireDate", order.OrderDate.AddMinutes(15).ToString("yyyyMMddHHmmss")}
            };

            string rawData = string.Join("&", dict.Select(kvp => $"{kvp.Key}={WebUtility.UrlEncode(kvp.Value)}"));
            string secureHash = Helper.HmacSHA512(parameters.vnp_HashSecret, rawData);

            string queryString = rawData + $"&vnp_SecureHash={secureHash}";

            return parameters.vnp_BaseUrl + "?" + queryString;
        }
    }
}
