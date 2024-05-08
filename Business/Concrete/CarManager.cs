using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entitites.Concrete;
using Entitites.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal=carDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            var result =BusinessRules.Run(CheckCarBrandMax(car.BrandId), CheckCarDescriptionNotSame(car.Description));
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessDataResult<Car>(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), "Arablar Listelendi.");
        }

        public IDataResult<Car> GetByDailyPrice(int min, int max)
        {
            return new DataResult<Car>(_carDal.Get(c => c.DailyPrice<=max&&c.DailyPrice>=min), true);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new DataResult<Car>(_carDal.Get(c => c.Id == id), true);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), "Arablar Listelendi.");
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessDataResult<Car>(Messages.CarUpdated);
        }

        private IResult CheckCarBrandMax(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId==brandId).Count;
            if (result>=10)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }

        private IResult CheckCarDescriptionNotSame(string description)
        {
            var result = _carDal.GetAll(c=>c.Description==description).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
           
        }
    }
}
