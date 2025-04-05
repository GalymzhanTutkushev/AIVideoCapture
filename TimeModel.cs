using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADAL_Video
{
    public class TimeModel
    {
        public int Time { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }

        public string FullName
        {
            get
            {
                return $"{ Time }      { Name } { Note }";
            }
        }
    }
}
