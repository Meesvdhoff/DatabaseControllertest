using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveApp.Models
{
    public class Token
    {
        public int Id { get; set; }
        public string acces_token { get; set; }
        public string error_description { get; set; }
        public DateTime expire_date { get; set; }

        public Token()
        {

        }
    }
}
