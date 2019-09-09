using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tractus
{
    [Serializable]
    public class LocalHolidays
    {
        [JsonProperty("local_holidays")]
        public List<LocalHoliday> LocalHolidaysList = new List<LocalHoliday>();
    }
}
