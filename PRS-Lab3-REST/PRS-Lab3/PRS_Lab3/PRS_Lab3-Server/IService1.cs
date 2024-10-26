using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PRS_Lab3_Server
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "Addit?num1={num1}&num2={num2}",
            Method = "GET",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Xml
            )]
        string AddIt(int num1, int num2);

        [OperationContract]
        [WebInvoke(UriTemplate = "getResource", 
            Method = "GET", 
            BodyStyle = WebMessageBodyStyle.WrappedRequest, 
            ResponseFormat = WebMessageFormat.Xml)]
        string getResource();

        [OperationContract]
        [WebInvoke(UriTemplate = "addResource?id={id}&value={value}", 
            Method = "POST", 
            BodyStyle = WebMessageBodyStyle.WrappedRequest, 
            ResponseFormat = WebMessageFormat.Xml)]
        string addResource(string id, string value);

        [OperationContract]
        [WebInvoke(UriTemplate = "updateResource?id={id}&value={value}&isdel={isdel}", 
            Method = "POST", 
            BodyStyle = WebMessageBodyStyle.WrappedRequest, 
            ResponseFormat = WebMessageFormat.Xml)]
        string updateResource(string id, string value, bool isdel = false);
    }
}
