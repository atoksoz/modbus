using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Plc
{
    public abstract class PlcData : PlcBit
    {

        private int _plcStatus;
        private int _plcStartStop;
        private int _plcErrorFlag1;
        private int _plcErrorFlag2;
        private int _downTime;
        private double _downTime_;
        private int _counter;
        private int _runTime;
        private int _cuttingPressureValue;
        private int _cuttingPressure;
        private int _maintainceSetBit;
        private int _cuttingSpeed;
        private int _powerOnCounter;
        private int _loaderCounter;
        private int _sortingCounter;

        public int PlcStatus
        {
            set { _plcStatus = value; }
            get { return _plcStatus; }
        }

        public int PlcStartStop
        {
            set { _plcStartStop = value; }
            get { return _plcStartStop; }
        }
        public int PlcErrorFlag1
        {
            set { _plcErrorFlag1 = value; }
            get { return _plcErrorFlag1; }
        }
        public int PlcErrorFlag2
        {
            set { _plcErrorFlag2 = value; }
            get { return _plcErrorFlag2; }
        }
        public int DownTime
        {
            set { _downTime = value; }
            get { return _downTime; }
        }
        public double DownTime_
        {
            set { _downTime_ = value; }
            get { return _downTime_; }
        }
        public int Counter
        {
            set { _counter = value; }
            get { return _counter; }
        }
        public int RunTime
        {
            set { _runTime = value; }
            get { return _runTime; }
        }
        public int CuttingPressureValue
        {
            set { _cuttingPressureValue = value; }
            get { return _cuttingPressureValue; }
        }
        public int CuttingPressure
        {
            set { _cuttingPressure = value; }
            get { return _cuttingPressure; }
        }
        public int MaintainceSetBit
        {
            set { _maintainceSetBit = value; }
            get { return _maintainceSetBit; }
        }
        public int CuttingSpeed
        {
            set { _cuttingSpeed = value; }
            get { return _cuttingSpeed; }
        }
        public int PowerOnCounter
        {
            set { _powerOnCounter = value; }
            get { return _powerOnCounter; }
        }
        public int LoaderCounter
        {
            set { _loaderCounter = value; }
            get { return _loaderCounter; }
        }
        public int SortingCounter
        {
            set { _sortingCounter = value; }
            get { return _sortingCounter; }

        }

        public enum MachineStatus
        {
            [Description("No connection to plc status")]
            NotPlcConnection = -1,
            [Description("Plc Wait time status")]
            Waiting = 0,
            [Description("String 2")]
            Working = 1,
            [Description("String 2")]
            Stoping = 2,
            [Description("String 2")]
            MaintainceTime = 4
        }

        public enum MachineStopWithWorkorder
        {
            [Description("Machine enable to stop value if has no work order")]
            Disable = 0,
            [Description("Machine enable to not stop value if has no work order")]
            Enable = 1,
        }

        public enum SettingStatus
        {
            [Description("Machine is now setting time")]
            Setting = 2            
        }

        public enum MachineStartStop
        {
            [Description("Enable to run machine ")]
            Start = 1,
            [Description("Not enable to run machine")]
            Stop = 2,
        }

        public enum MachineCoefficient
        {
            [Description("Cutting machine pressure coefficient")]
            CuttingPressureCoefficient = 100
        }
        public enum PlcBitRange
        {
            [Description("Cutting machine pressure coefficient")]
            StartBit = 0,
            [Description("Cutting machine pressure coefficient")]
            EndBit = 20,
            [Description("Cutting machine pressure coefficient")]
            Size = 20
        }

        public enum Values
        {
            [Description("Zero value")]
            Zero = 0,
            [Description("Set maintaince")]
            MaintainceSet = 1,
            [Description("Reset maintaince")]
            MaintainceReset = 0,
        }
    }


}
