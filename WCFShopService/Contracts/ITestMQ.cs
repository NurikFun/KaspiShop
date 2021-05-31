﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFShopService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITestMQ" in both code and config file together.
    [ServiceContract]
    public interface ITestMQ
    {
        [OperationContract(IsOneWay = true)]
        void Process(string data);
    }
}