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
        [WebInvoke(UriTemplate = "getStudents", Method = "GET", ResponseFormat = WebMessageFormat.Xml)]
        string GetStudents();

        [OperationContract]
        [WebInvoke(UriTemplate = "addStudent?id={id}&name={name}&age={age}&grade={grade}", Method = "POST", ResponseFormat = WebMessageFormat.Xml)]
        string AddStudent(string id, string name, int age, int grade);

        [OperationContract]
        [WebInvoke(UriTemplate = "updateStudent?id={id}&name={name}&age={age}&grade={grade}", Method = "POST", ResponseFormat = WebMessageFormat.Xml)]
        string UpdateStudent(string id, string name, int age, int grade);

        [OperationContract]
        [WebInvoke(UriTemplate = "deleteStudent?id={id}", Method = "DELETE", ResponseFormat = WebMessageFormat.Xml)]
        string DeleteStudent(string id);
    }
}
