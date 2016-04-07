using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace end_user_gui.Models
{
    [ComplexType]
    public class ArchiveFile
    {
        public string ContentType { get; set; }
        public long Size { get; set; }
        public string Path { get; set; }
        public byte[] Contents { get; set; }

        [NotMapped]
        public FileTypes Type
        {
            get
            {
                var p = Path.ToLower();
                return p.EndsWith("ead.xml") ? FileTypes.EAD
                    : p.Contains("/data/") || p.Contains("\\data\\") ? FileTypes.Data
                    : FileTypes.Other;
            }
        }
    }

    public enum FileTypes
    {
        EAD,
        Data,
        Other
    }
}
