namespace api_backend.Dtos
{
    public class CreateFoodRequest
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public bool IsHealthy { get; set; }
    }
}
