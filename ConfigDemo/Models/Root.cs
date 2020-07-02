using Newtonsoft.Json;

namespace ConfigDemo.Models
{
    public class Root
    {
        [JsonIgnore]
        public bool HasLoginModes => this.LoginModes != null;
        //------------------------------------------
        [JsonProperty(PropertyName = "loginModes")]
        public LoginModes LoginModes { get; set; }

        [JsonProperty(PropertyName = "clients")]
        public Clients Clients { get; set; }

        [JsonProperty(PropertyName = "isProduction")]
        public bool IsProduction { get; set; }

        [JsonProperty(PropertyName = "apiDomain")]
        public string ApiDomain { get; set; }

        [JsonProperty(PropertyName = "pingOneLogoutUrl")]
        public string PingOneLogoutUrl { get; set; }

        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }
    }
}



