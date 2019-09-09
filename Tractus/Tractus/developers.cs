using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tractus
{
    [Serializable]
    public class Developers
    {
        [JsonProperty("developers")]
        public List<Developer> developerList = new List<Developer>();
    }
}