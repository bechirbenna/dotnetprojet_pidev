using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace data
{
    public static class GlobalVariables 
    {
       public static HttpClient Client = new HttpClient();

        static GlobalVariables()
        {
            Client.BaseAddress= new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
