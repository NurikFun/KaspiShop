using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFShopService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TestMQ" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TestMQ.svc or TestMQ.svc.cs at the Solution Explorer and start debugging.
    public class TestMQ : ITestMQ
    {
        public void Process(string data)
        {
            System.Diagnostics.Trace.Write(string.Format("You entered: {0}", data));
        }
    }


    
}
