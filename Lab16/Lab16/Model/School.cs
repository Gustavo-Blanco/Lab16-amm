using System;
using Newtonsoft.Json;

namespace Lab16.Model
{
    public class School
    {
        [JsonProperty("_id")]
        public String Id { get; set; }
        
        [JsonProperty("name")]
        public String Name { get; set; }
        
        [JsonProperty("amountTeachers")]
        public String AmountTeachers { get; set; }
        
        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }
        
        [JsonProperty("location")]
        public String Location { get; set; }
        
        [JsonProperty("licenced")]
        public Boolean Licenced { get; set; }

        
    }
}