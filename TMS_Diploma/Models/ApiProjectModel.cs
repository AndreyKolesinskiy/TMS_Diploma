using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TMS_Diploma.Models
{
    public class ApiProjectModel
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("announcement")] public string Announcement { get; set; }

        [JsonPropertyName("show_announcement")]
        public bool? IsShowAnnouncement { get; set; }

        [JsonPropertyName("suite_mode")] public int ProjectType { get; set; }
        public bool? IsEnableTestCase { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Announcement)}: {Announcement}, " +
                   $"{nameof(IsShowAnnouncement)}: {IsShowAnnouncement}, {nameof(ProjectType)}: {ProjectType}";
        }

        public bool Equals(ApiProjectModel projectModel)
        {
            return Name == projectModel.Name && Announcement == projectModel.Announcement &&
                   IsShowAnnouncement == projectModel.IsShowAnnouncement &&
                   ProjectType == projectModel.ProjectType;
        }
    }
}
