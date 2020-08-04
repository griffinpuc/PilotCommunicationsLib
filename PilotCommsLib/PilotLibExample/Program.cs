using System;
using PilotCommsLib;

namespace PilotLibExample
{
    class Program
    {
        

        static void Main(string[] args)
        {
            CommInstance comm = new CommInstance("COM3", 115200);
        }
    }
}
