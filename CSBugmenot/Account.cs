using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBugmenot
{
    public class Account
    {
        // Properties
        public string Username { get; set; }
        public string Password { get; set; }
        public string Other { get; set; }
        public int Stats { get; set; }
        public int Votes { get; set; }
        public int Id { get; set; }
        public int Site { get; set; }
        public DateTime AddingDate { get; set; }

        public string Vote(bool vote)
        {
           return CsBugmenot.Vote(this, vote);
        }
    }
}
