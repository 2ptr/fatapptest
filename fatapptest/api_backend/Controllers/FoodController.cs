using api_backend.Services;
using api_backend.Dtos;
using Microsoft.AspNetCore.Mvc;
using api_backend.Mappers;

namespace api_backend.Controllers
{
    [ApiController]
    [Route("api/food")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;
        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public IActionResult GetAllFoods()
        {
            var foods = _foodService.GetAllFoods();
            return Ok(foods);
        }
        [HttpGet("{name}")]
        public IActionResult GetFood(string name)
        {
            var food = _foodService.GetFood(name);
            if (food == null) return NotFound();
            return Ok(food);
        }
        [HttpPost]
        public IActionResult CreateFood([FromBody] CreateFoodRequest request)
        {
            var foodModel = request.CreateFoodRequestToFood();
            _foodService.CreateFood(foodModel);
            return Ok(foodModel.FoodToFoodPublic());
        }


    }
}
