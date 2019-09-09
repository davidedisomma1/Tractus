using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tractus
{
    [Serializable]
    public class Project
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("since")]
        public DateTime Since { get; set; }
        [JsonProperty("until")]
        public DateTime Until { get; set; }
        [JsonProperty("effort_days")]
        public int EffortDays { get; set; }
    }
}
