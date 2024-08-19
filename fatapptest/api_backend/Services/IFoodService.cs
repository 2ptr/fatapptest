using api_backend.Models;

namespace api_backend.Services
{
    public interface IFoodService
    {
        List<Food> GetAllFoods();
        Food CreateFood(Food food);
        Food GetFood(string name);
        void DeleteFood(Food food);

        Food UpdateFood(string name, Food food);
    }

    public class FoodService : IFoodService
    {
        private List<Food> _foods = new();

        public Food CreateFood(Food food)
        {
            _foods.Add(food);
            return food;
        }

        void IFoodService.DeleteFood(Food food)
        {
            _foods.Remove(food);
        }

        List<Food> IFoodService.GetAllFoods()
        {
            return (_foods);
        }

        Food IFoodService.GetFood(string name)
        {
            var food = _foods.FirstOrDefault(x => x.Name == name);
            return food;
        }

        Food IFoodService.UpdateFood(string name, Food food)
        {
            throw new NotImplementedException();
        }
    }
}
