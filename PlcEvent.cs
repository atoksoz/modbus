using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plc
{
    public class PlcEvent : PlcCommand //: UglassOnline.Plc.PlcCommand
    {
        private int _machineStartStop = (int)PlcData.MachineStartStop.Stop;

        //public PlcEvent() { }
        public PlcEvent(string plcIpAddress) : base(plcIpAddress) { }
        
        public PlcEvent(string plcIpAddress, int port = (int)PlcConfig.StartupValues.Port) : base(plcIpAddress, port) { }
        public PlcEvent(string plcIpAddress, int port = (int)PlcConfig.StartupValues.Port, int timeout = (int)PlcConfig.StartupValues.ConnectionTimeout) : base(plcIpAddress, port, timeout) { }

        public int MachineStartStop
        {
            set { _machineStartStop = value; }
            get { return _machineStartStop; }
        }

        public void StartEvent()
        {
            try
            {
                if (this.MachineStartStop == (int)PlcData.MachineStopWithWorkorder.Disable)
                    throw new Exception();

                this.PlcStart();
            }
            catch (Exception) { }           
        }

        public void StopEvent()
        {
            try
            {
                if (this.MachineStartStop == (int)PlcData.MachineStopWithWorkorder.Disable)
                    throw new Exception();
                this.PlcStop();                
            }
            catch (Exception) { }
        }

        public bool MachineStop2Result()
        {
            bool result = false;
            try
            {
                if (this.MachineStartStop == (int)PlcData.MachineStopWithWorkorder.Disable) { result = true; throw new Exception(); }
                result = this.PlcStop();
            }
            catch (Exception) { }
            return result;
        }
        
        public bool MachineStart2Result()
        {
            bool result = false;
            try
            {
                if (this.MachineStartStop == (int)PlcData.MachineStopWithWorkorder.Disable) { result = true; throw new Exception(); }
                result = this.PlcStart();
            }
            catch (Exception) { }
            return result;
        }
    }
}
