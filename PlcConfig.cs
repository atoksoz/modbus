
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plc
{
    public abstract class PlcConfig
    {
        private string _ipAddress = "";

        public string IpAddress
        {
            set { _ipAddress = value; }
            get { return _ipAddress; }
        }
            
        public enum StartupValues
        {
            [Description("Plc connection timeout value")]
            ConnectionTimeout = 2000,
            [Description("Plc connection port")]
            Port = 502
        }
    }
}
