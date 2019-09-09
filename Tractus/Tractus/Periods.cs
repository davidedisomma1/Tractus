using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tractus
{
    [Serializable]
    public class Periods
    {
        [JsonProperty("periods")]
        public List<Period> periodsList = new List<Period>();
    }
}