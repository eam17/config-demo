using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConfigDemo.Models
{
    public class LoginModes
    {
        [JsonProperty(PropertyName = "organizations")]
        public List<Organization> Organizations { get; set; }

        public override string ToString()
        {
            return "Organizations";
        }
    }
}
