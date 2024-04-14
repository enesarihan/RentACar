using Core.DataAccess;
using Core.Entities;
using Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        bool CheckRentedCarIsDelivered(int carId);
    }
}
