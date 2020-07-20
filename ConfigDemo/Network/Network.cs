using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using ConfigDemo.Models;
using ConfigDemo.PubSub;
using Newtonsoft.Json;

namespace ConfigDemo.Network
{
    public class NetworkKat
    {
        public async void GetRootObject()
        {
            string url = "https://api.mystrength.com/config?useNewFormat=true";
            try
            {
                using (var client = new HttpClient())
                {
                    string response = await client.GetStringAsync(url);
                    this.Publish(new ObjectParsed(ParseJSON<Root>(response)));
                    
                }
            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine("\nException Caught!");
                Debug.WriteLine("Message :{0} ", e.Message);
            }

        }

        T ParseJSON<T>(string response)
        {
            return JsonConvert.DeserializeObject<T>(response);//makes Root not null
        }
    }
}

