using api_backend.Dtos;
using api_backend.Models;

namespace api_backend.Mappers
{
    public static class FoodMapper
    {
        public static Food CreateFoodRequestToFood(this CreateFoodRequest request)
        {
            var foodModel = new Food()
            {
                Name = request.Name,
                Count = request.Count,
                IsHealthy = request.IsHealthy
            };
            return foodModel;
        }

        public static FoodPublic FoodToFoodPublic(this Food food)
        {
            var foodModel = new FoodPublic()
            {
                Name = food.Name,
                Count = food.Count,
                IsHealthy = food.IsHealthy
            };
            return foodModel;
        }
    }
}
