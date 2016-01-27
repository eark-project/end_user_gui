using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace end_user_gui.Models
{
    /// <summary>
    /// TODO: Fill this from EAD content in /metadata.xml file (if available)
    /// </summary>
    public class ArchiveMetadata
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public ArchiveType Type { get; set; } = ArchiveType.AIP;
        public ArchiveFormat Format { get; set; } = ArchiveFormat.mixed;
    }
}
