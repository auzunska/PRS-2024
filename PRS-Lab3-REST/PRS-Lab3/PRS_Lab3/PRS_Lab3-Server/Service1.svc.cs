using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace PRS_Lab3_Server
{
    public class Service1 : IService1
    {
        private readonly string xmlFilePath = "D:/TU_Sem_7/PRS/PRS-2024/PRS-Lab3-REST/PRS-Lab3/data.xml";
        public string AddIt(int num1, int num2)
        {
            return Convert.ToString(num1 + num2);
        }
    }
}
