using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static NUnit.Framework.Internal.OSPlatform;

namespace TMS_Diploma.Models
{
    public class ApiMilestoneModel
    {
        [JsonPropertyName("project_id")] public int ProjectId { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("description")] public string Description { get; set; }
        [JsonPropertyName("id")] public int Id { get; set; }

        public bool Equals(ApiMilestoneModel milestoneModel)
        {
            return Name == milestoneModel.Name && Description == milestoneModel.Description && 
                Id == milestoneModel.Id;
        }
    }
}
