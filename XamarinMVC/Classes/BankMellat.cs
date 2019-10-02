using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XamarinMVC.Classes
{
    public class BankMellat
    {
        public static readonly string PgwSite = "https://bpm.shaparak.ir/pgwchannel/startpay.mellat";
        static readonly string callBackUrl = "http://ShopApplication/Payment/BankCallback";
        static readonly long terminalId = long.Parse("");
        static readonly string userName = "";
        static readonly string password = "";

        string localDate = string.Empty;
        string localTime = string.Empty;

        public BankMellat()
        {
            try
            {
                localDate = DateTime.Now.ToString("yyyyMMdd");
                localTime = DateTime.Now.ToString("HHMMSS");
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public string bpPayRequest(long orderId, long priceAmount, string additionalText)
        {
            try
            {
                BankMellatService.PaymentGatewayImplService WebService = new BankMellatService.PaymentGatewayImplService();
                return WebService.bpPayRequest(terminalId, userName, password, orderId, priceAmount, localDate, localTime,
                                 additionalText, callBackUrl, 0);

            }
            catch (Exception error)
            {
                throw new Exception(error.Message); ;
            }
        }

        public enum MellatBankReturnCode
        {
            ﺗﺮاﻛﻨﺶ_ﺑﺎ_ﻣﻮﻓﻘﻴﺖ_اﻧﺠﺎم_ﺷﺪ = 0,
            ﺷﻤﺎره_ﻛﺎرت_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ = 11,
            ﻣﻮﺟﻮدی_ﻛﺎﻓﻲ_ﻧﻴﺴﺖ = 12,
            رﻣﺰ_ﻧﺎدرﺳﺖ_اﺳﺖ = 13,
            ﺗﻌﺪاد_دﻓﻌﺎت_وارد_ﻛﺮدن_رﻣﺰ_ﺑﻴﺶ_از_ﺣﺪ_ﻣﺠﺎز_اﺳﺖ = 14,
            ﻛﺎرت_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ = 15,
            دﻓﻌﺎت_ﺑﺮداﺷﺖ_وﺟﻪ_ﺑﻴﺶ_از_ﺣﺪ_ﻣﺠﺎز_اﺳﺖ = 16,
            ﻛﺎرﺑﺮ_از_اﻧﺠﺎم_ﺗﺮاﻛﻨﺶ_ﻣﻨﺼﺮف_ﺷﺪه_اﺳﺖ = 17,
            ﺗﺎرﻳﺦ_اﻧﻘﻀﺎی_ﻛﺎرت_ﮔﺬﺷﺘﻪ_اﺳﺖ = 18,
            ﻣﺒﻠﻎ_ﺑﺮداﺷﺖ_وﺟﻪ_ﺑﻴﺶ_از_ﺣﺪ_ﻣﺠﺎز_اﺳﺖ = 19,


            ﺻﺎدر_ﻛﻨﻨﺪه_ﻛﺎرت_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ = 111,
            ﺧﻄﺎی_ﺳﻮﻳﻴﭻ_ﺻﺎدر_ﻛﻨﻨﺪه_ﻛﺎرت = 112,
            ﭘﺎﺳﺨﻲ_از_ﺻﺎدر_ﻛﻨﻨﺪه_ﻛﺎرت_درﻳﺎﻓﺖ_ﻧﺸﺪ = 113,
            دارﻧﺪه_ﻛﺎرت_ﻣﺠﺎز_ﺑﻪ_اﻧﺠﺎم_اﻳﻦ_ﺗﺮاﻛﻨﺶ_ﻧﻴﺴﺖ = 114,


            ﭘﺬﻳﺮﻧﺪه_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ = 21,
            ﺧﻄﺎی_اﻣﻨﻴﺘﻲ_رخ_داده_اﺳﺖ = 23,
            اﻃﻼﻋﺎت_ﻛﺎرﺑﺮی_ﭘﺬﻳﺮﻧﺪه_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ = 24,
            ﻣﺒﻠﻎ_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ = 25,
            ﭘﺎﺳﺦ_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ = 31,
            ﻓﺮﻣﺖ_اﻃﻼﻋﺎت_وارد_ﺷﺪه_ﺻﺤﻴﺢ_ﻧﻤﻲ_ﺑﺎﺷﺪ = 32,
            ﺣﺴﺎب_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ = 33,
            ﺧﻄﺎی_ﺳﻴﺴﺘﻤﻲ = 34,
            ﺗﺎرﻳﺦ_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ = 35,
            ﺷﻤﺎره_درﺧﻮاﺳﺖ_ﺗﻜﺮاری_اﺳﺖ = 41,
            ﺗﺮاﻛﻨﺶ_Sale_یافت_نشد_ = 42,
            ﻗﺒﻼ_Verify_درﺧﻮاﺳﺖ_داده_ﺷﺪه_اﺳﺖ = 43,
            درخواست_verify_یافت_نشد = 44,
            ﺗﺮاﻛﻨﺶ_Settle_ﺷﺪه_اﺳﺖ = 45,
            ﺗﺮاﻛﻨﺶ_Settle_نشده_اﺳﺖ = 46,
            ﺗﺮاﻛﻨﺶ_Settle_یافت_نشد = 47,
            تراکنش_Reverse_شده_است = 48,
            تراکنش_Refund_یافت_نشد = 49,


            شناسه_قبض_نادرست_است = 412,
            ﺷﻨﺎﺳﻪ_ﭘﺮداﺧﺖ_ﻧﺎدرﺳﺖ_اﺳﺖ = 413,
            سازﻣﺎن_ﺻﺎدر_ﻛﻨﻨﺪه_ﻗﺒﺾ_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ = 414,
            زﻣﺎن_ﺟﻠﺴﻪ_ﻛﺎری_ﺑﻪ_ﭘﺎﻳﺎن_رسیده_است = 415,
            ﺧﻄﺎ_در_ﺛﺒﺖ_اﻃﻼﻋﺎت = 416,
            ﺷﻨﺎﺳﻪ_ﭘﺮداﺧﺖ_ﻛﻨﻨﺪه_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ = 417,
            اﺷﻜﺎل_در_ﺗﻌﺮﻳﻒ_اﻃﻼﻋﺎت_ﻣﺸﺘﺮی = 418,
            ﺗﻌﺪاد_دﻓﻌﺎت_ورود_اﻃﻼﻋﺎت_از_ﺣﺪ_ﻣﺠﺎز_ﮔﺬﺷﺘﻪ_اﺳﺖ = 419,
            IP_نامعتبر_است = 421,

            ﺗﺮاﻛﻨﺶ_ﺗﻜﺮاری_اﺳﺖ = 51,
            ﺗﺮاﻛﻨﺶ_ﻣﺮﺟﻊ_ﻣﻮﺟﻮد_ﻧﻴﺴﺖ = 54,
            ﺗﺮاﻛﻨﺶ_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ = 55,
            ﺧﻄﺎ_در_واریز = 61
        }

        public String DesribtionStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 0:
                    return MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_ﺑﺎ_ﻣﻮﻓﻘﻴﺖ_اﻧﺠﺎم_ﺷﺪ.ToString();
                case 11:
                    return MellatBankReturnCode.ﺷﻤﺎره_ﻛﺎرت_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ.ToString();
                case 12:
                    return MellatBankReturnCode.ﻣﻮﺟﻮدی_ﻛﺎﻓﻲ_ﻧﻴﺴﺖ.ToString();
                case 13:
                    return MellatBankReturnCode.رﻣﺰ_ﻧﺎدرﺳﺖ_اﺳﺖ.ToString();
                case 14:
                    return MellatBankReturnCode.ﺗﻌﺪاد_دﻓﻌﺎت_وارد_ﻛﺮدن_رﻣﺰ_ﺑﻴﺶ_از_ﺣﺪ_ﻣﺠﺎز_اﺳﺖ.ToString();
                case 15:
                    return MellatBankReturnCode.ﻛﺎرت_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ.ToString();
                case 16:
                    return MellatBankReturnCode.دﻓﻌﺎت_ﺑﺮداﺷﺖ_وﺟﻪ_ﺑﻴﺶ_از_ﺣﺪ_ﻣﺠﺎز_اﺳﺖ.ToString();
                case 17:
                    return MellatBankReturnCode.ﻛﺎرﺑﺮ_از_اﻧﺠﺎم_ﺗﺮاﻛﻨﺶ_ﻣﻨﺼﺮف_ﺷﺪه_اﺳﺖ.ToString();
                case 18:
                    return MellatBankReturnCode.ﺗﺎرﻳﺦ_اﻧﻘﻀﺎی_ﻛﺎرت_ﮔﺬﺷﺘﻪ_اﺳﺖ.ToString();
                case 19:
                    return MellatBankReturnCode.ﻣﺒﻠﻎ_ﺑﺮداﺷﺖ_وﺟﻪ_ﺑﻴﺶ_از_ﺣﺪ_ﻣﺠﺎز_اﺳﺖ.ToString();
                case 111:
                    return MellatBankReturnCode.ﺻﺎدر_ﻛﻨﻨﺪه_ﻛﺎرت_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ.ToString();
                case 112:
                    return MellatBankReturnCode.ﺧﻄﺎی_ﺳﻮﻳﻴﭻ_ﺻﺎدر_ﻛﻨﻨﺪه_ﻛﺎرت.ToString();
                case 113:
                    return MellatBankReturnCode.ﭘﺎﺳﺨﻲ_از_ﺻﺎدر_ﻛﻨﻨﺪه_ﻛﺎرت_درﻳﺎﻓﺖ_ﻧﺸﺪ.ToString();
                case 114:
                    return MellatBankReturnCode.دارﻧﺪه_ﻛﺎرت_ﻣﺠﺎز_ﺑﻪ_اﻧﺠﺎم_اﻳﻦ_ﺗﺮاﻛﻨﺶ_ﻧﻴﺴﺖ.ToString();
                case 21:
                    return MellatBankReturnCode.ﭘﺬﻳﺮﻧﺪه_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ.ToString();
                case 23:
                    return MellatBankReturnCode.ﺧﻄﺎی_اﻣﻨﻴﺘﻲ_رخ_داده_اﺳﺖ.ToString();
                case 24:
                    return MellatBankReturnCode.اﻃﻼﻋﺎت_ﻛﺎرﺑﺮی_ﭘﺬﻳﺮﻧﺪه_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ.ToString();
                case 25:
                    return MellatBankReturnCode.ﻣﺒﻠﻎ_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ.ToString();
                case 31:
                    return MellatBankReturnCode.ﭘﺎﺳﺦ_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ.ToString();
                case 32:
                    return MellatBankReturnCode.ﻓﺮﻣﺖ_اﻃﻼﻋﺎت_وارد_ﺷﺪه_ﺻﺤﻴﺢ_ﻧﻤﻲ_ﺑﺎﺷﺪ.ToString();
                case 33:
                    return MellatBankReturnCode.ﺣﺴﺎب_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ.ToString();
                case 34:
                    return MellatBankReturnCode.ﺧﻄﺎی_ﺳﻴﺴﺘﻤﻲ.ToString();
                case 35:
                    return MellatBankReturnCode.ﺗﺎرﻳﺦ_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ.ToString();
                case 41:
                    return MellatBankReturnCode.ﺷﻤﺎره_درﺧﻮاﺳﺖ_ﺗﻜﺮاری_اﺳﺖ.ToString();
                case 42:
                    return MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_Sale_یافت_نشد_.ToString();
                case 43:
                    return MellatBankReturnCode.ﻗﺒﻼ_Verify_درﺧﻮاﺳﺖ_داده_ﺷﺪه_اﺳﺖ.ToString();



                case 44:
                    return MellatBankReturnCode.درخواست_verify_یافت_نشد.ToString();
                case 45:
                    return MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_Settle_ﺷﺪه_اﺳﺖ.ToString();
                case 46:
                    return MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_Settle_نشده_اﺳﺖ.ToString();

                case 47:
                    return MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_Settle_یافت_نشد.ToString();
                case 48:
                    return MellatBankReturnCode.تراکنش_Reverse_شده_است.ToString();
                case 49:
                    return MellatBankReturnCode.تراکنش_Refund_یافت_نشد.ToString();
                case 412:
                    return MellatBankReturnCode.شناسه_قبض_نادرست_است.ToString();
                case 413:
                    return MellatBankReturnCode.ﺷﻨﺎﺳﻪ_ﭘﺮداﺧﺖ_ﻧﺎدرﺳﺖ_اﺳﺖ.ToString();
                case 414:
                    return MellatBankReturnCode.سازﻣﺎن_ﺻﺎدر_ﻛﻨﻨﺪه_ﻗﺒﺾ_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ.ToString();
                case 415:
                    return MellatBankReturnCode.زﻣﺎن_ﺟﻠﺴﻪ_ﻛﺎری_ﺑﻪ_ﭘﺎﻳﺎن_رسیده_است.ToString();
                case 416:
                    return MellatBankReturnCode.ﺧﻄﺎ_در_ﺛﺒﺖ_اﻃﻼﻋﺎت.ToString();
                case 417:
                    return MellatBankReturnCode.ﺷﻨﺎﺳﻪ_ﭘﺮداﺧﺖ_ﻛﻨﻨﺪه_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ.ToString();
                case 418:
                    return MellatBankReturnCode.اﺷﻜﺎل_در_ﺗﻌﺮﻳﻒ_اﻃﻼﻋﺎت_ﻣﺸﺘﺮی.ToString();
                case 419:
                    return MellatBankReturnCode.ﺗﻌﺪاد_دﻓﻌﺎت_ورود_اﻃﻼﻋﺎت_از_ﺣﺪ_ﻣﺠﺎز_ﮔﺬﺷﺘﻪ_اﺳﺖ.ToString();
                case 421:
                    return MellatBankReturnCode.IP_نامعتبر_است.ToString();

                case 51:
                    return MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_ﺗﻜﺮاری_اﺳﺖ.ToString();
                case 54:
                    return MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_ﻣﺮﺟﻊ_ﻣﻮﺟﻮد_ﻧﻴﺴﺖ.ToString();
                case 55:
                    return MellatBankReturnCode.ﺗﺮاﻛﻨﺶ_ﻧﺎﻣﻌﺘﺒﺮ_اﺳﺖ.ToString();
                case 61:
                    return MellatBankReturnCode.ﺧﻄﺎ_در_واریز.ToString();

            }
            return "";
        }

        public string VerifyRequest(long orderId, long saleOrderId, long saleReferenceId)
        {
            try
            {
                BankMellatService.PaymentGatewayImplService WebService = new BankMellatService.PaymentGatewayImplService();
                return WebService.bpVerifyRequest(terminalId, userName, password, orderId, saleOrderId, saleReferenceId);

            }
            catch (Exception Error)
            {
                throw new Exception(Error.Message);
            }
        }

        public string SettleRequest(long orderId, long saleOrderId, long saleReferenceId)
        {
            try
            {
                BankMellatService.PaymentGatewayImplService WebService = new BankMellatService.PaymentGatewayImplService();
                return WebService.bpSettleRequest(terminalId, userName, password, orderId, saleOrderId, saleReferenceId);
            }
            catch (Exception Error)
            {
                throw new Exception(Error.Message);
            }
        }

        public string InquiryRequest(long orderId, long saleOrderId, long saleReferenceId)
        {
            try
            {
                BankMellatService.PaymentGatewayImplService WebService = new BankMellatService.PaymentGatewayImplService();
                return WebService.bpInquiryRequest(terminalId, userName, password, orderId, saleOrderId, saleReferenceId);

            }
            catch (Exception Error)
            {
                throw new Exception(Error.Message);
            }
        }

        public string bpReversalRequest(long orderId, long saleOrderId, long saleReferenceId)
        {
            try
            {
                BankMellatService.PaymentGatewayImplService WebService = new BankMellatService.PaymentGatewayImplService();
                return WebService.bpReversalRequest(terminalId, userName, password, orderId, saleOrderId, saleReferenceId);

            }
            catch (Exception error)
            {
                throw new Exception(error.Message); ;
            }
        }
    }
}