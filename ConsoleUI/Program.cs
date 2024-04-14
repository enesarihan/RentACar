using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entitites.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //GetColors();
            //GetCars();
            //GetBrands();
            //GetCarDetails();
            


           
  
        }

        private static void GetColors()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var colors in colorManager.GetAll().Data)
            {
                Console.WriteLine(colors.ColorName);
            }
        }

        private static void GetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var cars in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0} / {1} / {2} / {3} / {4} Euro", cars.Id, cars.BrandName, cars.Descripton,cars.ColorName, cars.DailyPrice);
            }
        }

        private static void GetBrands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetById(1).Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void GetCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();

            if (result.Success == true)
            {
                foreach (var cars in carManager.GetAll().Data)
                {
                    Console.WriteLine("{0} Id'li {1} Marka Araç {2}", cars.Id, cars.ColorId, cars.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}
