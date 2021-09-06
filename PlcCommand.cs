using EasyModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Plc.Interface;
namespace Plc
{
    public abstract class PlcCommand : PlcData, IPlcCommand
    {
        private ModbusClient _modbusClient;

        public PlcCommand(string ip, int port = (int)PlcConfig.StartupValues.Port, int timeout = (int)PlcConfig.StartupValues.ConnectionTimeout)
        {
            this._modbusClient = new ModbusClient(ip, port);
            this._modbusClient.ConnectionTimeout = timeout;
        }
        //public PlcCommand() { }

        public void SetPlcIpAddress(string ipAddress)
        {
            try
            {
                this._modbusClient.IPAddress = ipAddress;
            } catch (Exception) { }

        }

        public void SetPlcPort(int port)
        {
            this._modbusClient.Port = port;
        }

        public bool SetPlcValue(int Bit, int Value)
        {
            bool result = false;

            try
            {
                if (this._modbusClient.Connected == false)
                    this._modbusClient.Connect();

                this._modbusClient.WriteSingleRegister(Bit, Value);
                result = true;
            }
            catch (Exception) { result = false; if (this._modbusClient.Connected == true) this._modbusClient.Disconnect(); }

            return result;
        }

        public int PlcReadBit(int registerBit)
        {
            int result = -1;
            try
            {
                if (this._modbusClient.Connected == false)
                    this._modbusClient.Connect();
                
                int[] array = this._modbusClient.ReadHoldingRegisters((int)PlcData.PlcBitRange.StartBit, (int)PlcData.PlcBitRange.EndBit); 
                result = array[registerBit];
            }
            catch (Exception x) { if (this._modbusClient.Connected == true) this._modbusClient.Disconnect(); }

            return result;
        }

        public int[] PlcRead(int startBit = (int)PlcData.PlcBitRange.StartBit, int endBit = (int)PlcData.PlcBitRange.EndBit, int size = (int)PlcData.PlcBitRange.Size)
        {
            int[] array = new int[size];
            try
            {
                if (this._modbusClient.Connected == false)
                    this._modbusClient.Connect();

                array = this._modbusClient.ReadHoldingRegisters(startBit, endBit);
               //var a = this._modbusClient.ReadHoldingRegisters(0, 21);
            }
            catch (Exception x) { if (this._modbusClient.Connected == true) this._modbusClient.Disconnect(); }

            return array;
        }
       
        public  bool PlcClearCounter(int bit)
        {
            bool result = false;
            try
            {
                if (this._modbusClient.Connected == false)
                    this._modbusClient.Connect();

                this._modbusClient.WriteSingleRegister(bit, (int)PlcData.Values.Zero);
                result = true;
            }
            catch (Exception x) { if (this._modbusClient.Connected == true) this._modbusClient.Disconnect(); }

            return result;
        }


        public bool PlcStop(int bit = (int)PlcData.Bits.StartStop, int value = (int)PlcData.MachineStartStop.Stop)
        {
            bool result = false;
            try
            {
                if (this._modbusClient.Connected == false)
                    this._modbusClient.Connect();

                this._modbusClient.WriteSingleRegister(bit, value);
                result = true;
            }
            catch (Exception x) { if (this._modbusClient.Connected == true) this._modbusClient.Disconnect(); }
            return result;
        }

        public bool PlcStart(int bit = (int)PlcData.Bits.StartStop, int value = (int)PlcData.MachineStartStop.Start)
        {
            bool result = false;
            try
            {
                if (this._modbusClient.Connected == false)
                    this._modbusClient.Connect();
                this._modbusClient.WriteSingleRegister(bit, value);
                result = true;
            }
            catch (Exception x) { if (this._modbusClient.Connected == true) this._modbusClient.Disconnect(); }

            return result;
        }
        public bool SetSetting(int bit = (int)PlcData.Bits.EdgeProcessingSetSetting, int value = (int)PlcData.SettingStatus.Setting)
        {
            bool result = false;
            try
            {
                if (this._modbusClient.Connected == false)
                    this._modbusClient.Connect();
                this._modbusClient.WriteSingleRegister(bit, value);
                result = true;
            }
            catch (Exception x) { if (this._modbusClient.Connected == true) this._modbusClient.Disconnect(); }
            return result;
        }

        public bool Disconnect()
        {
            bool result = false;
            try
            {
                if (this._modbusClient.Connected == true)
                    this._modbusClient.Disconnect();
                result = true;
            }
            catch (Exception) { }

            return result;
        }

        public bool Connect()
        {
            bool result = false;
            try
            {
                if (this._modbusClient.Connected == false)
                    this._modbusClient.Connect();
                result = true;
            }
            catch (Exception x) { }

            return result;
        }
    }
}
