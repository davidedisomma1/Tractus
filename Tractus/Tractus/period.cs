using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tractus
{
    [Serializable]
    public class Period
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("since")]
        public DateTime Since { get; set; }
        [JsonProperty("until")]
        public DateTime Until { get; set; }
    }
}
