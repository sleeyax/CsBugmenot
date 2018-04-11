using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBugmenot.utils
{
    class AccountRegex
    {
        public const string Account = @"<article class=""account"".+?>(.+?)<\/article>";
        public const string Username = @"<dt>Username:<\/dt><dd><kbd.*?>(.+?)<\/";
        public const string Other = @"<dt>Other:<\/dt><dd><kbd.*?>(.+?)<\/";
        public const string Password = @"<dt>Password:<\/dt><dd><kbd.*?>(.+?)<\/";
        public const string Stats = @"<li class=""success_rate.*?"">(\d{1,3})%";
        public const string Votes = @"<li>(\d+) votes<\/li>";
        public const string Site = @"input type=""hidden"" name=""site"" value=""(\d+)""";
        public const string AddingDate = @"<li>(\d+ (day[s]*|month[s]*|year[s]*|)) old<\/li>";
        public const string Id = @"data-account_id=""(\d+)""";
    }
}
