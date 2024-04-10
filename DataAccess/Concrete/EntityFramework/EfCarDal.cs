using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entitites.Concrete;
using Entitites.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, SqlContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (SqlContext context = new SqlContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cr in context.Colors on c.ColorId equals cr.ColorId
                             select new CarDetailDto { Id = c.Id, Descripton=c.Description,
                             DailyPrice=c.DailyPrice, BrandName=b.BrandName,ColorName=cr.ColorName };

                return result.ToList();
            } 
        }
    }
}
