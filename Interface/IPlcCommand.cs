using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plc.Interface
{
    interface IPlcCommand
    {
        void SetPlcIpAddress(string ipAddress);
        void SetPlcPort(int port);
        bool SetPlcValue(int Bit, int Value);
        int PlcReadBit(int registerBit);
        int[] PlcRead(int startBit, int endBit, int size);
        bool PlcClearCounter(int bit);
        bool PlcStop(int bit, int value);
        bool PlcStart(int bit, int value);
        bool SetSetting(int bit, int value);
        bool Disconnect();
        bool Connect();

    }
}
