using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.WpfClient.Models
{
    public class SearchCaseRecord
    {
        public bool IsLocked { get; set; }
        public uint Number { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
    }
}
