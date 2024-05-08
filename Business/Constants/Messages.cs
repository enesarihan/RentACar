using Core.Entities;
using Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car has been added.";
        public static string CarNameInvalid = "Car description is insufficient.";
        public static string BrandNameInvalid = "Brand must be greater than 2 characters.";
        public static string BrandAdded = "Brand has been successfully added.";
        public static string ColorNameInvalid = "Color must be greater than 2 characters.";
        public static string ColorAdded = "Color has been successfully added.";
        public static string MaintenanceTime = "Maintenance time.";
        public static string CarDeleted = "Car has been successfully deleted.";
        public static string BrandDeleted = "Brand has been successfully deleted.";
        public static string ColorDeleted = "Color has been successfully deleted.";
        public static string CarUpdated = "Car has been successfully updated.";
        public static string ColorUpdated = "Color has been successfully updated.";
        public static string BrandUpdated = "Brand has been successfully updated.";
        public static string UserUpdated= "User has been successfuly updated.";
        public static string UserDeleted= "User has been successfuly deleted.";
        public static string UserAdded= "User has been successfuly addded.";
        public static string UserNameInvalid= "User Name Invalid.";
        public static string CustomerUpdated= "Customer has been successfuly updated.";
        public static string CustomerDeleted= "Customer has been successfuly deleted.";
        public static string CustomerAdded= "Customer has been successfuly added.";
        public static string RentalAdded= "Rental has been successfuly added.";
        public static string RentalDeleted= "Rental has been successfuly deleted.";
        public static string RentalUpdated= "Rental has been successfuly updated.";
        public static string CarCountOfBrandError="Brand Count invalid.";
        public static string ProductNameAlreadyExist="This Name Already Exist!";
        public static string AuthorizationDenied= "You do not have authorization";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Incorrect password";
        public static string SuccessfulLogin = "Login successful";
        public static string UserAlreadyExists = "This user already exists";
        public static string UserRegistered = "User successfully registered";
        public static string AccessTokenCreated = "Access token successfully created";
        public static string ProductNameAlreadyExists = "Product name already exists";


    }
}
