using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entitites.Concrete;
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
    }
}
