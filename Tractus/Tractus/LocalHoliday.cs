using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tractus
{
    [Serializable]
    public class LocalHoliday
    {
        [JsonProperty("day")]
        public DateTime Day { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

    }
}