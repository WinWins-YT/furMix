using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furMix
{
    public class MonitorNotFound : Exception
    {
        public MonitorNotFound()
        {

        }

        public MonitorNotFound(string message) : base(message)
        {

        }
    }
}
