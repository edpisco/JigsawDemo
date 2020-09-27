using System.Collections.Generic;

namespace Jigsaw.MiniProject.Data.Models
{
    public class TreeItem
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public TreeItem Parent { get; set; }
        public ICollection<TreeItem> Children { get; set; }
    }
}

