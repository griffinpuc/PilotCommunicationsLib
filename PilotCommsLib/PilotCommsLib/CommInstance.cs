using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace PilotCommsLib
{
    public class CommInstance
    {

        public Identity BoardIdentity;

        private SerialPort SerialPort;
        private bool IsOpen;

        public CommInstance(string CommPort, int BaudRate)
        {
            this.SerialPort = new SerialPort() { PortName = CommPort, BaudRate = BaudRate };
            this.IsOpen = false;
        }

        /* INITIALIZE COMMUNICATIONS WITH DRONE CONTROLLER */
        public void Init()
        {
            if (Protocols.TryConnect(this.SerialPort))
            {
                this.IsOpen = true;
            }
        }

        /* CHECK COMM STATUS */
        public bool CheckStatus()
        {
            return this.IsOpen;
        }



    }
}
