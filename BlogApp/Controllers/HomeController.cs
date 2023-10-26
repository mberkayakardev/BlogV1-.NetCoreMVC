using BlogApp.Controllers.Admin;
using BlogApp.Data;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogDbContext context;
        public HomeController(BlogDbContext db)
        {
            context = db;
        }

        public IActionResult Index()
        {
            var result = context.Blogs.ToList();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetDetail(int blogid)
        {

            var model = await context.Blogs.Include(x => x.Contents).FirstOrDefaultAsync(x => x.Id == blogid);
            model.Contents = model.Contents.Where(x=> x.ParentId == null).ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveComment(AddChildComment comment)
        {
            await context.Comments.AddAsync(new Comment { BlogId = comment.BlogId, Content = comment.Description, WriterName = comment.UserName , ParentId = comment.RootCommentId});
            context.SaveChanges();
            return RedirectToAction("GetDetail", new { blogid = comment.BlogId });
        }

    }
}
