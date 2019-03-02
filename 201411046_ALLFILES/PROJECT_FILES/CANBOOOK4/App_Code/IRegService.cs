using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRegService" in both code and config file together.
[ServiceContract]
public interface IRegService
{


    [OperationContract]
    string makePersonPassword(string password);
}
