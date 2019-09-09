using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tractus
{
    [Serializable]
    public class Projects
    {
        [JsonProperty("projects")]
        public List<Project> projectList = new List<Project>();
    }
}
