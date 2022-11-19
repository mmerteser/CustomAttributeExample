using AttributeExample.Models;

namespace AttributeExample.Services
{
    public class CarService
    {
        public IEnumerable<Car> GetAll()
        {
            return new List<Car>
            {
                new Car { Id = 1, BrandName = "Peugeout", ModelName = "308"},
                new Car { Id = 2, BrandName = "Peugeout", ModelName = "208"},
                new Car { Id = 3, BrandName = "Peugeout", ModelName = "508"},
                new Car { Id = 4, BrandName = "Peugeout", ModelName = "5008"},
            };
        }

        public IEnumerable<Car> GetCarsByBrandName(string brandName)
        {
            return GetAll().Where(x => x.BrandName == brandName);
        }
    }
}
