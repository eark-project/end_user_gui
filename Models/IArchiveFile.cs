using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace end_user_gui.Models
{
    public interface IArchiveFile
    {
        string ContentType { get; set; }
        long Size { get; set; }
        string Path { get; set; }
        string Contents { get; set; }
    }
}
