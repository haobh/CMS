using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntity.ViewModel
{
    public class ModuleMenu
    {
        public string ModuleID { set; get; }
        public string ID { set; get; }
        public string Text { set; get; }
        public string Link { set; get; }
        public int DisplayOrder { set; get; }
        public string Name { set; get; }
        public long ParentMenuID { set; get; }
    }
}
