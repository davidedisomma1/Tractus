using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tractus
{
    [Serializable]
    static public class Availabilities
    {
        [JsonProperty("availabilities")]
        static public List<Availability> availabilitiesList = new List<Availability>();
    }
}
