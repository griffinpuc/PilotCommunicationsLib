using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace PilotCommsLib
{
    static class Protocols
    {

        private const string REQUEST_OPENCOMM = "@?!";
        private const string REQUEST_SCHEMA = "@&";
        private const string REQUEST_IDENTITY = "@#";

        private const string RECIEVE_OPENSUCCESS = "@?!";
        private const string RECIEVE_SCHEMA = "@&!";
        private const string RECIEVE_IDENTITY = "@#!";


        public static Object DataRecieved(SerialPort OpenPort)
        {
            string IncomingData = OpenPort.ReadLine();

            switch (IncomingData)
            {
                case RECIEVE_OPENSUCCESS:
                    return true;
                case RECIEVE_SCHEMA:
                    return OpenPort.ReadLine();
                case RECIEVE_IDENTITY:
                    return OpenPort.ReadLine();
                default:
                    break;
            }

            return false;
        }

        public static Object SendCommunication(SerialPort OpenPort, string Command)
        {
            if (OpenPort.IsOpen)
            {
                OpenPort.Write(Command);
                return (bool)DataRecieved(OpenPort);
            }

            return false;
        }

        public static bool TryConnect(SerialPort OpenPort) { return (bool)SendCommunication(OpenPort, REQUEST_OPENCOMM); }
        public static string RecieveSchema(SerialPort OpenPort) { return (string)SendCommunication(OpenPort, REQUEST_SCHEMA); }
        public static string RecieveIdentity(SerialPort OpenPort) { return (string)SendCommunication(OpenPort, REQUEST_IDENTITY); }


    }
}
