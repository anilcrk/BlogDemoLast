using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DemoFramework.Core.ErrorManagement
{
    public class BaseHandleException:Exception
    {
        public  BaseHandleException(string message):base(message)
        {
        }
    }
}
