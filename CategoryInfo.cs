using System.Collections.Generic;

namespace DICCreator
{
    public class CategoryInfo
    {
        public List<ItemInfo> ItemsList { get; set; }
        public string CategoryName { get; set; }
        public string CategoryNameEN { get; set; }
        public string CategoryNameDE { get; set; }
        public string CategoryID { get; set; }   //for example: tbl_shortcuts_1.1
    }
}
