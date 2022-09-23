using CheckInternet.Common;

namespace CheckInternet.Entities
{
    public class PublishVersion : BaseAuditableEntity
    {
        public string ApplicationName { get; set; }
        public string LastVersion { get; set; }
        public string CurrentVersion { get; set; }
        public bool EmailFlag { get; set; }
    }
}
