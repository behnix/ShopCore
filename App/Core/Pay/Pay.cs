using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Core.Pay
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web;

    namespace App.Core.Pay
    {
        public class Payment
        {
            private const string GatewaySend = "https://pay.ir/pg/send";
            private const string GatewayResult = "https://pay.ir/pg/verify";
            
            string Redirect = "https://kavian-sport.com/PeymentResult";

            public string Pay(string amount, string api)
            {
                var result = "";
                var postString = "";
                var postValues = new Dictionary<string, string>
                {
                    { "api", api },
                    { "amount", amount },
                    { "redirect", Redirect }
                };

                foreach (var postValue in postValues)
                {
                    postString += postValue.Key + "=" + HttpUtility.UrlEncode(postValue.Value) + "&";
                }
                postString = postString.TrimEnd('&');
                var objRequest = (HttpWebRequest)WebRequest.Create(GatewaySend);
                objRequest.Method = "POST";
                objRequest.ContentLength = postString.Length;
                objRequest.ContentType = "application/x-www-form-urlencoded";

                var myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(postString);
                myWriter.Close();

                var objResponse = (HttpWebResponse)objRequest.GetResponse();
                using (var responseStream = new StreamReader(objResponse.GetResponseStream()))
                {
                    result = responseStream.ReadToEnd();
                    responseStream.Close();
                }
                return result;
            }
            public string Verify(string token, string api)
            {
                string result;
                var postString = "";
                var postValues = new Dictionary<string, string> { { "api", api }, { "token", token } };

                foreach (var postValue in postValues)
                {
                    postString += postValue.Key + "=" + HttpUtility.UrlEncode(postValue.Value) + "&";
                }
                postString = postString.TrimEnd('&');
                var objRequest = (HttpWebRequest)WebRequest.Create(GatewayResult);
                objRequest.Method = "POST";
                objRequest.ContentLength = postString.Length;
                objRequest.ContentType = "application/x-www-form-urlencoded";

                var myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(postString);
                myWriter.Close();

                var objResponse = (HttpWebResponse)objRequest.GetResponse();
                using (var responseStream = new StreamReader(objResponse.GetResponseStream()))
                {
                    result = responseStream.ReadToEnd();
                    responseStream.Close();
                }
                return result;
            }
        }
    }

}
