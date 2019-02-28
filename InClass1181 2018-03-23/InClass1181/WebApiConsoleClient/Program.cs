using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebAPIDB; // just for the structure of model not for DB as data would come from API Project
using System.Net.Http;


namespace WebApiConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Press any key to fetch data from API Server...");
            Console.ReadKey();

            IEnumerable<Member> members = getMembers();
            if (members != null)
            {
                foreach (Member m in members)
                {
                    Console.WriteLine($"{m.Id} - {m.Name}");
                }
            }
            else
            {
                Console.WriteLine("Error occured while access the web api server...");
            }
            Console.ReadKey();

        }

        private static IEnumerable<Member> getMembers()
        {


            HttpClient hc = new HttpClient();

            hc.BaseAddress = new Uri("http://localhost:60000");

            hc.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue
                ("application/json"));

            HttpResponseMessage hrm = hc.GetAsync("api/members").Result;
            IEnumerable<Member> members = new List<Member>(); // wrong
            if (hrm.IsSuccessStatusCode)
            {
                members = hrm.Content.ReadAsAsync<List<Member>>().Result;

            }

            return members;
        }
    }
}
