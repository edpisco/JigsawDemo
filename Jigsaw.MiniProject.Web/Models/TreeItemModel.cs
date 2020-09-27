using System.Collections.Generic;

namespace Jigsaw.MiniProject.Web.Models
{
    public class TreeItemModel
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public ICollection<TreeItemModel> Children { get; set; }
    }
}
