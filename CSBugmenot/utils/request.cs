using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSBugmenot.utils
{
    class Request
    {
        private static WebClient wc = new WebClient();
        public static string UserAgent { set; get; }

        public static string DownloadHtml(string url)
        {
            return wc.DownloadString(url);
        }

        public static string Post(string url, NameValueCollection postData)
        {
            byte[] response = wc.UploadValues(url, "POST", postData);
            return Encoding.UTF8.GetString(response);
        }
    }
}
