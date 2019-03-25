using System.Collections.Generic;
using System.Linq;


namespace CarRent
{
    public class ManagmentLogic : BaseLogic
    {

        //Manufacturer car managment logic
        public ManufacturerModel AddManufacturer(ManufacturerModel manufacturerModel)
        {         
            ManufacturersCar manufacturer = new ManufacturersCar
            {
                ManufacturerName = manufacturerModel.manufacturer
            };
            DB.ManufacturersCars.Add(manufacturer);
            DB.SaveChanges();

            return GetOneManufacturer(manufacturer.Id);
        }

        public ManufacturerModel GetOneManufacturer(int id)
        {
            return DB.ManufacturersCars
            .Where(m => m.Id == id)
            .Select(m => new ManufacturerModel
            {
                id = m.Id,
                manufacturer = m.ManufacturerName
            }).SingleOrDefault();
        }

        public void DeleteManufacturer(int id)
        {
            ManufacturersCar manufacturersCar =
            DB.ManufacturersCars.FirstOrDefault(m => m.Id == id);
            if (manufacturersCar == null)
                return;

            DB.ManufacturersCars.Remove(manufacturersCar);
            DB.SaveChanges();
        }

        public ManufacturerModel UpdateManufacturerName(ManufacturerModel manufacturerModel)
        {
            ManufacturersCar manufacturersCar =
                DB.ManufacturersCars.Where(m => m.Id == manufacturerModel.id).SingleOrDefault();
            if (manufacturersCar == null)
                return null;

            manufacturersCar.ManufacturerName = manufacturerModel.manufacturer;
            DB.SaveChanges();

            return GetOneManufacturer(manufacturersCar.Id);
        }

        public bool CheckIfManufacturerExists(ManufacturerModel manufacturerModel)
        {
            return DB.ManufacturersCars.Any(m => m.ManufacturerName == manufacturerModel.manufacturer);
        }

        //Car model managment logic
        public ModelCarModel AddModelCar(ModelCarModel modelCar)
        {
            ModelsCar car = new ModelsCar
            {
                Model = modelCar.model,
                ManufacturerId = modelCar.manufacturerId,
                PricePerDay = modelCar.pricePerDay,
                Photo = modelCar.photo
            };
            DB.ModelsCars.Add(car);
            DB.SaveChanges();

            return GetOneModelCar(car.Id);
        }

        public ModelCarModel GetOneModelCar(int id)
        {
            return DB.ModelsCars
            .Where(m => m.Id == id)
            .Select(m => new ModelCarModel
            {
                id = m.Id,
                model = m.Model,
                manufacturerId = m.ManufacturerId,
                pricePerDay = m.PricePerDay,
                photo = m.Photo
            }).SingleOrDefault();
        }

        public void DeleteModelCar(int id)
        {
            ModelsCar modelsCar =
            DB.ModelsCars.FirstOrDefault(m => m.Id == id);
            if (modelsCar == null)
                return;

            DB.ModelsCars.Remove(modelsCar);
            DB.SaveChanges();
        }

        public ModelCarModel UpdateModelCarPrice(ModelCarModel carModel)
        {
            ModelsCar car =
                DB.ModelsCars.Where(m => m.Id == carModel.id).SingleOrDefault();
            if (carModel == null)
                return null;

            car.PricePerDay = carModel.pricePerDay;
            DB.SaveChanges();

            return GetOneModelCar(car.Id);
        }

        public bool CheckIfModelCarExists(ModelCarModel modelCarModel)
        {
            return DB.ModelsCars.Any(m => m.Model == modelCarModel.model);
        }

        //Company fleet managment logic
        public CompanyFleetModel AddCompanyFleet(CompanyFleetModel companyFleetModel)
        {
            CompanyFleet companyFleet = new CompanyFleet
            {
                ModelId = companyFleetModel.modelId,
                CarNumber = companyFleetModel.carNumber
            };
            DB.CompanyFleets.Add(companyFleet);
            DB.SaveChanges();

            return GetOneCompanyFleet(companyFleet.Id);
        }

        public CompanyFleetModel GetOneCompanyFleet(int id)
        {
            return DB.CompanyFleets
            .Where(c => c.Id == id)
            .Select(c => new CompanyFleetModel
            {
                id = c.Id,
                modelId = c.ModelId,
                carNumber = c.CarNumber
  
            }).SingleOrDefault();
        }

        public List<CompanyFleetModel> GetAllCompanyFleet()
        {
            return DB.CompanyFleets
            .Select(c => new CompanyFleetModel
            {
                id = c.Id,
                modelId = c.ModelId,  
                carNumber = c.CarNumber,
            }).ToList();
        }

        public void DeleteCompanyFleet(int id)
        {
            CompanyFleet companyFleet =
            DB.CompanyFleets.FirstOrDefault(c => c.Id == id);
            if (companyFleet == null)
                return;

            DB.CompanyFleets.Remove(companyFleet);
            DB.SaveChanges();
        }

        public CompanyFleetModel UpdateCarNumber(CompanyFleetModel companyFleetModel)
        {
            CompanyFleet companyFleet =
                DB.CompanyFleets.Where(c => c.Id == companyFleetModel.id).SingleOrDefault();
            if (companyFleet == null)
                return null;

            companyFleet.CarNumber = companyFleetModel.carNumber;
            DB.SaveChanges();

            return GetOneCompanyFleet(companyFleet.Id);
        }

        public bool CheckIfCompanyCarExists(CompanyFleetModel companyFleetModel)
        {
            return DB.CompanyFleets.Any(m => m.CarNumber == companyFleetModel.carNumber);
        }

    }
}