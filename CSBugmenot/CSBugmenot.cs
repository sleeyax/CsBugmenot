using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSBugmenot.utils;

namespace CSBugmenot
{
    public class CsBugmenot
    {
        private const string BaseUrl = "http://bugmenot.com/";
        public static int MinimumSuccessRate { get; set; } = 0;
        public static string UserAgent { get; set; } = "Mozilla/5.0 (Windows; U; Windows NT 6.1; rv:2.2) Gecko/20110201";

        public static List<Account> GetAllAccounts(string website)
        {
            return GetAllAccounts(website, UserAgent);
        }

        public static List<Account> GetAllAccounts(string website, string userAgent)
        {
            List<Account> accounts = new List<Account>();

            Request.UserAgent = userAgent;
            string doc = Request.DownloadHtml(BaseUrl + "view/" + website);

            foreach (Match accountMatch in Regex.Matches(doc, AccountRegex.Account))
            {
                Account account = new Account();
                
                int stats = Convert.ToInt32(Regex.Match(accountMatch.Value, AccountRegex.Stats).Groups[1].Value);
                if (stats >= MinimumSuccessRate)
                {
                    account.Username = Regex.Match(accountMatch.Value, AccountRegex.Username).Groups[1].Value;
                    account.Password = WebUtility.HtmlDecode(Regex.Match(accountMatch.Value, AccountRegex.Password).Groups[1].Value);
                    account.Other = Regex.Match(accountMatch.Value, AccountRegex.Other).Groups[1].Value;
                    account.Stats = stats;
                    account.Votes = Convert.ToInt32(Regex.Match(accountMatch.Value, AccountRegex.Votes).Groups[1].Value);
                    account.Id = Convert.ToInt32(Regex.Match(accountMatch.Value, AccountRegex.Id).Groups[1].Value);
                    account.Site = Convert.ToInt32(Regex.Match(accountMatch.Value, AccountRegex.Site).Groups[1].Value);
                    account.AddingDate = ParseDate(Regex.Match(accountMatch.Value, AccountRegex.AddingDate).Groups[1].Value);

                    accounts.Add(account);
                }
            }
            return accounts;
        }

        private static DateTime ParseDate(string dateString)
        {
            int daysAgo = Convert.ToInt32(Regex.Match(dateString, @"\d+").Value);
            if (dateString.Contains("month"))
            {
                daysAgo *= 30;
            }else if (dateString.Contains("year"))
            {
                daysAgo *= 365;
            }
            return DateTime.Now.AddDays(daysAgo * -1);
        }

        public static string Vote(Account account, bool vote)
        {
            string voteString = vote ? "Y" : "N";

            NameValueCollection data = new NameValueCollection();
            data["account"] = account.Id.ToString();
            data["site"] = account.Site.ToString();
            data["vote"] = voteString;

            return Request.Post(BaseUrl + "vote.php", data);
        }
    }
}
