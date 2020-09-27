using Jigsaw.MiniProject.Data;
using Jigsaw.MiniProject.Web.Extensions;
using Jigsaw.MiniProject.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Jigsaw.MiniProject.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TreeController : ControllerBase
    {
        private readonly ITreeContext _treeContext;

        public TreeController(ITreeContext treeContext)
        {
            _treeContext = treeContext;
        }

        [HttpGet]
        public TreeItemModel Get()
        {
            var treeItems = _treeContext.TreeItems.Include(e => e.Children).ToList();
            var treeItem = treeItems.First(x => x.Parent == null);
            return treeItem.ToModel();
        }

        public bool Post(TreeItemModel model)
        {

            var entity = model.ToEntity();
            _treeContext.TreeItems.Add(entity);
            _treeContext.SaveChanges();
            return true;
        }
    }
}
