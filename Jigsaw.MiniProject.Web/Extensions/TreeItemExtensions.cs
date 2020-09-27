using System.Collections.Generic;
using System.Linq;
using Jigsaw.MiniProject.Data.Models;
using Jigsaw.MiniProject.Web.Models;

namespace Jigsaw.MiniProject.Web.Extensions
{
    public static class TreeItemExtensions
    {
        public static TreeItemModel ToModel(this TreeItem treeItem)
        {
            var model = new TreeItemModel
            {
                Id = treeItem.Id,
                ParentId = treeItem.ParentId ?? 0,
                Name = treeItem.Name,
                Children = treeItem.Children.Select(x => x.ToModel()).ToList()
            };

            return model;
        }

        public static TreeItem ToEntity(this TreeItemModel treeItemModel)
        {
            var model = new TreeItem
            {
                ParentId = treeItemModel.ParentId ?? 0,
                Name = treeItemModel.Name,
                Children = new List<TreeItem>()
            };

            return model;
        }
    }
}