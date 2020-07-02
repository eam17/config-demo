using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using ConfigDemo.Models;
using Newtonsoft.Json;

namespace ConfigDemo.Network
{
    public class NetworkKat
    {
        public async Task<T> GetRootObject<T>()
        {
            string url = "https://api.mystrength.com/config?useNewFormat=true";
            try
            {
                using (var client = new HttpClient())
                {
                    string response = await client.GetStringAsync(url);
                    return ParseJSON<T>(response);
                    
                }
            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine("\nException Caught!");
                Debug.WriteLine("Message :{0} ", e.Message);
            }

            return default;
        }

        T ParseJSON<T>(string response)
        {
            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}

