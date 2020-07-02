using Newtonsoft.Json;

namespace ConfigDemo.Models
{
    public class Clients
    {
        [JsonProperty(PropertyName = "web")]
        public ClientObject Web { get; set; }

        [JsonProperty(PropertyName = "android")]
        public ClientObject Android { get; set; }

        [JsonProperty(PropertyName = "ios")]
        public ClientObject iOS { get; set; }

    }
}