using Business.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodService _foodService;
        private readonly IBlogservice _blogService;
        private readonly IAboutService _aboutService;
        public FoodsController(IFoodService foodService, IAboutService aboutService,
            IBlogservice blogService)
        {
            _foodService = foodService;
            _blogService = blogService;
            _aboutService = aboutService;   
        }


        [HttpGet("GetFoods")]
        public IActionResult GetFoods()
        {
            HttpClient client = new HttpClient();
            
            var result = _foodService.GetFoodWithFoodCategoryId();

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }

        [HttpPost("AddBlog")]
        public IActionResult AddBlog(BlogCreateDto blogCreateDto)
        {
            var  result = _blogService.Add(blogCreateDto);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Göndərilən məlumat doğru deyil");
        }
        [AllowAnonymous]
        [HttpPost("AddAbout")]
        public IActionResult AddAbout(AboutCreateDto aboutCreateDto)
        {
            var result = _aboutService.Add(aboutCreateDto);

            if(result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
