using System.Text.Json.Serialization;

namespace TMS_Diploma.Models
{
    public class ProjectModel
    {
        public string Name { get; set; }
        public string Announcement { get; set; }
        public bool IsShowAnnouncement { get; set; }
        public string ProjectType { get; set; }
        public bool IsEnableTestCaseApprovals { get; set; }
    }
}
