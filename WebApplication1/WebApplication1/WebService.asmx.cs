using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/",
Description = "A Simple Web Calculator Service",
Name = "CalculatorWebService")]
 
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        /*[WebMethod]
        public string getlocation()
        {
            return "39.034411 -94.572049";
        }*/

        [WebMethod]
        public int Add(int x, int y)
        {
            return x + y;
        }
        [WebMethod]
        public int Subtract(int x, int y)
        {
            return x - y;
        }
        [WebMethod]
        public int Multiply(int x, int y)
        {
            return x * y;
        }
        [WebMethod]
        public int Division(int x, int y)
        {
            return x / y;
        }

    }
     }
