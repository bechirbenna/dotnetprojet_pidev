using data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class Class1
    {

        HttpResponseMessage response = GlobalVariables.Client.DeleteAsync("/pidev-web/rest/objectives/" + 13).Result;

           





    }
}
