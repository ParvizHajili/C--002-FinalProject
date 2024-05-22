using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IBlogservice _blogService;
        private readonly ITagService _tagService;
        public BlogController(IBlogservice blogservice,ITagService tagService )
        {
            _blogService = blogservice;
            _tagService = tagService;
        }
        
        public IActionResult Index()
        {
            var data = _blogService.GetAll().Data;
            return View(data);
        }

        public IActionResult Create()
        {
            ViewData["Tags"] = _tagService.GetAll().Data;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog blog, int[] tagIds)
        {
            _blogService.Add(blog, tagIds);

            return RedirectToAction("Index");
        }
    }
}
