using System.Collections.Generic;
using System.Linq;

namespace CarRent
{
    public class CarsLogic : BaseLogic
    {
        public List<CarModel> GetAllCars()
        {
            return DB.Cars.Select(c => new CarModel
            {
                id = c.Id,
                photo = c.Photo,
                model = c.Model,
                pricePerDay = c.PricePerDay,
                manufacturer = c.ManufacturerName,
                carNumber = c.CarNumber
            }).ToList();
        }

        public List<CarModel> GetAllCars(bool isAdmin)
        {
            if (isAdmin)
            {
                // do somthing for admin role
            }
            else
            {
                // do somthing for other users
            }
            return DB.Cars.Select(c => new CarModel
            {
                id = c.Id,
                photo = c.Photo,
                model = c.Model,
                pricePerDay = c.PricePerDay,
                carNumber = c.CarNumber,
                manufacturer = c.ManufacturerName
            }).ToList();
        }

        public CarModel GetOneCar(int id)
        {
            return DB.Cars
              .Where(c => c.Id == id)
              .Select(c => new CarModel
              {
                  id = c.Id,
                  photo = c.Photo,
                  model = c.Model,
                  pricePerDay = c.PricePerDay,
                  carNumber = c.CarNumber,
                  manufacturer = c.ManufacturerName
              }).SingleOrDefault();
        }

        public List<ManufacturerModel> GetAllManufacturer()
        {
            return DB.ManufacturersCars
            .Select(m => new ManufacturerModel
            {
                id = m.Id,
                manufacturer = m.ManufacturerName,
            }).ToList();
        }

        public List<ModelCarModel> GetAllModelCar()
        {
            return DB.ModelsCars
            .Select(m => new ModelCarModel
            {
                id = m.Id,
                model = m.Model,
                manufacturerId = m.ManufacturerId,
                pricePerDay = m.PricePerDay,
                photo = m.Photo
            }).ToList();
        }
    }
}