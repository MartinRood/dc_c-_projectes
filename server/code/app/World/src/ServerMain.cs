using System;
using System.Collections.Generic;

namespace dc
{
    class ServerMain
    {
        static void Main(string[] args)
        {
            Master.Instance.Setup();
            Master.Instance.Start();
        }
    }
}
