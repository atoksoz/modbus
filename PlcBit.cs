using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Plc
{
    public abstract class PlcBit : PlcConfig
    {        
        public enum Bits
        {
            [Description("Machine status bit")]
            MachineStatus = 0,
            [Description("Machine start stop bit")]
            StartStop = 1,
            [Description("PLC Error Flag 1 bit")]
            PlcErrorFlag1 = 2,
            [Description("PLC Error Flag 2 bit")]
            PlcErrorFlag2 = 3,
            [Description("Machine downtime bit")]
            Downtime = 4,
            [Description("Machine counter bit")]
            Counter = 5,
            [Description("Machine runtime bit")]
            Runtime = 6,
            [Description("Cutting machine pressure bit")]
            CuttingPressure = 9,
            [Description("Edge processing machine setting time bit")]
            EdgeProcessingSetSetting = 11,
            [Description("Maintaince set bit, 1 is set 0 is not set")]
            MaintainceSet = 15,
            [Description("Cutting machine speed bit")]
            CuttingSpeed = 16,
            [Description("Machine power on counter bit")]
            PowerOnCounter = 17,
            [Description("Cutting machine loader counter bit")]
            LoaderCounter = 18,
            [Description("Cutting machine sorting table counter bit")]
            SortingTableCounter = 19,
        }
    }
}
