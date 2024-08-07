﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entitites.Concrete;
using Entitites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, SqlContext>, IRentalDal
    {
        public bool CheckRentedCarIsDelivered(int carId)
        {
            using (SqlContext context = new SqlContext())
            {
                var result = context.Set<Rental>().Where(r => r.CarId == carId && r.ReturnDate == null).SingleOrDefault();

                return result == null ? true : false;

            }
        }

        public List<RentalDetailsDto> GetRentalDetailsDto()
        {
            using (SqlContext context = new SqlContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join u in context.Users on r.CustomerId equals u.Id
                             select new RentalDetailsDto
                             { Id = r.Id, BrandName = b.BrandName, FullName = u.FirstName + " " + u.LastName, RentDate = r.RentDate, ReturnDate = r.ReturnDate };
                return result.ToList();
            }
        }
    }
}
