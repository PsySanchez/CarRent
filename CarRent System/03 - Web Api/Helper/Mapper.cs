namespace CarRent.Helper
{
    /// <summary>
    /// This class will impliment logic of mapping from model to viewModel and from viewModel to model
    /// </summary>
    public class Mapper
    {
        //Casting from car business logic to car view model:
        public static CarViewModel MapCarModelToCarViewModel(CarModel carModel)
        {
            CarViewModel carViewModel = new CarViewModel();
            carViewModel.id = carModel.id;
            carViewModel.photo = carModel.photo;
            carViewModel.model = carModel.model;
            carViewModel.pricePerDay = carModel.pricePerDay;
            carViewModel.carNumber = carModel.carNumber;
            carViewModel.manufacturer = carModel.manufacturer;

            return carViewModel;
        }

        //Casting from car view model logic to car business logic:
        public static CarModel MapCarViewModelToCarModel(CarViewModel carViewModel)
        {
            CarModel carModel = new CarModel();
            carModel.photo = carViewModel.photo;
            carModel.model = carViewModel.model;
            carModel.pricePerDay = carViewModel.pricePerDay;
            carModel.carNumber = carViewModel.carNumber;
            carModel.manufacturer = carViewModel.manufacturer;

            return carModel;
        }

        //Casting from user business logic to user view model:
        public static UserViewModel MapUserModelToUserViewModel(UserModel userModel)
        {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.firstName = userModel.firstName;
            userViewModel.lastName = userModel.lastName;
            userViewModel.userName = userModel.userName;
            userViewModel.password = userModel.password;
            userViewModel.telephone = userModel.telephone;
            userViewModel.email = userModel.email;
            userViewModel.dateOfBirth = userModel.dateOfBirth;
            userViewModel.role = userModel.role;

            return userViewModel;
        }

        //Casting from user view model to user business logic:
        public static UserModel MapUserViewModelToUserModel(UserViewModel userViewModel)
        {
            UserModel userModel = new UserModel();
            userModel.firstName = userViewModel.firstName;
            userModel.lastName = userViewModel.lastName;
            userModel.userName = userViewModel.userName;
            userModel.password = userViewModel.password;
            userModel.telephone = userViewModel.telephone;
            userModel.email = userViewModel.email;
            userModel.dateOfBirth = userViewModel.dateOfBirth;
            userModel.role = userViewModel.role;

            return userModel;
        }

        //Casting from credentials view model to credentials businnes logic:
        public static CredentialsModel MapCredentialsViewModelToCredentialsModel(CredentialsViewModel credentialsViewModel)
        {
            CredentialsModel credentialsModel = new CredentialsModel();
            credentialsModel.username = credentialsViewModel.username;
            credentialsModel.password = credentialsViewModel.password;

            return credentialsModel;
        }

        //Casting from credentials businnes logic to credentials view model:
        public static CredentialsViewModel MapCredentialsModelToCredentialsViewModel(CredentialsModel credentialsModel)
        {
            CredentialsViewModel credentialsViewModel = new CredentialsViewModel();
            credentialsViewModel.username = credentialsModel.username;
            credentialsViewModel.password = credentialsModel.password;

            return credentialsViewModel;
        }

        //Casting from user model businnes logic to user registration view model:
        public static UserRegistrationViewModel MapUserModelToUserRegistrationViewModel(UserModel userModel)
        {
            UserRegistrationViewModel userRegistrationViewModel = new UserRegistrationViewModel();

            userRegistrationViewModel.userName = userModel.userName;
            userRegistrationViewModel.password = userModel.password;
            userRegistrationViewModel.firstName = userModel.firstName;
            userRegistrationViewModel.lastName = userModel.lastName;
            userRegistrationViewModel.email = userModel.email;
            userRegistrationViewModel.telephone = userModel.telephone;
            userRegistrationViewModel.dateOfBirth = userModel.dateOfBirth;


            return userRegistrationViewModel;
        }

        //Casting from user registration view model to user model business logc:
        public static UserModel MapUserRegistrationViewModelToUserModel(UserRegistrationViewModel userRegistrationViewModel)
        {
            UserModel userModel = new UserModel();

            userModel.userName = userRegistrationViewModel.userName;
            userModel.password = userRegistrationViewModel.password;
            userModel.firstName = userRegistrationViewModel.firstName;
            userModel.lastName = userRegistrationViewModel.lastName;
            userModel.email = userRegistrationViewModel.email;
            userModel.telephone = userRegistrationViewModel.telephone;
            userModel.dateOfBirth = userRegistrationViewModel.dateOfBirth;

            return userModel;
        }

        //Casting from order mode bussines logic to view order model:
        public static OrderViewModel MapOrderModelToOrderViewModel(OrderModel orderModel)
        {
            OrderViewModel orderViewModel = new OrderViewModel();

            orderViewModel.id = orderModel.id;
            orderViewModel.carId = orderModel.carId;
            orderViewModel.fromDate = orderModel.fromDate;
            orderViewModel.toDate = orderModel.toDate;
            orderViewModel.totalCost = orderModel.totalCost;

            return orderViewModel;
        }

        //Casting from order view model to order mode bussines logic:
        public static OrderModel MapOrderViewModelToOrderModel(OrderViewModel orderViewModel)
        {
            OrderModel orderModel = new OrderModel();

            orderModel.id = orderViewModel.id; ;
            orderModel.carId = orderViewModel.carId;
            orderModel.fromDate = orderViewModel.fromDate;
            orderModel.toDate = orderViewModel.toDate;
            orderModel.totalCost = orderViewModel.totalCost;

            return orderModel;
        }

        // Casting user bussines logic model to user view model:
        public static AuthenticationViewModel MapUserModelToAuthenticationViewModel(UserModel userModel)
        {
            AuthenticationViewModel authenticationViewModel = new AuthenticationViewModel();

            authenticationViewModel.firstName = userModel.firstName;
            authenticationViewModel.lastName = userModel.lastName;

            return authenticationViewModel;
        }

        //Casting autentication view model to user bussines logic model:
        public static UserModel MapAuthenticationViewModelToUserModel(AuthenticationViewModel authenticationViewModel)
        {
            UserModel userModel = new UserModel();

            userModel.firstName = authenticationViewModel.firstName;
            authenticationViewModel.lastName = userModel.lastName;

            return userModel;
        }

        //Casting user order bussines logic model to user order view model:
        public static UserOrderModel MapUserViewOrderModelToUserOrderModel(UserViewOrderModel userViewOrderModel)
        {
            UserOrderModel userOrderModel = new UserOrderModel();

            userOrderModel.photo = userViewOrderModel.photo;
            userOrderModel.manufacturer = userViewOrderModel.manufacturer;
            userOrderModel.model = userViewOrderModel.model;
            userOrderModel.fromDate = userViewOrderModel.fromDate;
            userOrderModel.toDate = userViewOrderModel.toDate;
            userOrderModel.totalCost = userViewOrderModel.totalCost;

            return userOrderModel;
        }

        //Casting from user orders bussines logic to users orders view model:
        public static UserViewOrderModel MapUserOrderModelToUserViewOrderModel(UserOrderModel userOrderModel)
        {
            UserViewOrderModel userViewOrderModel = new UserViewOrderModel();

            userViewOrderModel.photo = userOrderModel.photo;
            userViewOrderModel.firstName = userOrderModel.firstName;
            userViewOrderModel.lastName = userOrderModel.lastName;
            userViewOrderModel.manufacturer = userOrderModel.manufacturer;

            userViewOrderModel.model = userOrderModel.model;
            userViewOrderModel.fromDate = userOrderModel.fromDate;
            userViewOrderModel.toDate = userOrderModel.toDate;
            userViewOrderModel.totalCost = userOrderModel.totalCost;

            return userViewOrderModel;
        }
        //Casting from manufacturer view model to manufacturer mode bussines logic:
        public static ManufacturerModel MapManufacturerViewModelToManufacturerModel(ManufacturerViewModel manufacturerViewModel)
        {
            ManufacturerModel manufacturerModel = new ManufacturerModel();

            manufacturerModel.id = manufacturerViewModel.id;
            manufacturerModel.manufacturer = manufacturerViewModel.manufacturer;

            return manufacturerModel;
        }

        //Casting from manufacturer bussines logic to manufacturer view model :
        public static ManufacturerViewModel MapManufacturerModelToManufacturerViewModel(ManufacturerModel manufacturerModel)
        {
            ManufacturerViewModel manufacturerViewModel = new ManufacturerViewModel();

            manufacturerViewModel.id = manufacturerModel.id;
            manufacturerViewModel.manufacturer = manufacturerModel.manufacturer;

            return manufacturerViewModel;
        }

        //Casting from car view model to car bussines logic model:
        public static ModelCarModel MapModelCarViewModelToModelCarModel(ModelCarViewModel modelCarViewModel)
        {
            ModelCarModel modelCarModel = new ModelCarModel();

            modelCarModel.id = modelCarViewModel.id;
            modelCarModel.model = modelCarViewModel.model;
            modelCarModel.manufacturerId = modelCarViewModel.manufacturerId;
            modelCarModel.pricePerDay = modelCarViewModel.pricePerDay;
            modelCarModel.photo = modelCarViewModel.photo;

            return modelCarModel;
        }

        //Casting from car bussines logic model to car view model:
        public static ModelCarViewModel MapModelCarModelToModelCarViewModel(ModelCarModel modelCarModel)
        {
            ModelCarViewModel modelCarViewModel = new ModelCarViewModel();

            modelCarViewModel.id = modelCarModel.id;
            modelCarViewModel.model = modelCarModel.model;
            modelCarViewModel.manufacturerId = modelCarModel.manufacturerId;
            modelCarViewModel.pricePerDay = modelCarModel.pricePerDay;
            modelCarViewModel.photo = modelCarModel.photo;

            return modelCarViewModel;
        }

        //Casting from company fleet view model to company fleet bussines logic model:
        public static CompanyFleetModel MapCompanyFleetViewModelToCompanyFleetModel(CompanyFleetViewModel companyFleetViewModel)
        {
            CompanyFleetModel companyFleetModel = new CompanyFleetModel();

            companyFleetModel.id = companyFleetViewModel.id;
            companyFleetModel.modelId = companyFleetViewModel.modelId;
            companyFleetModel.carNumber = companyFleetViewModel.carNumber;

            return companyFleetModel;
        }

        //Casting from company fleet bussines logic model to company fleet view model:
        public static CompanyFleetViewModel MapCompanyFleetModelToCompanyFleetVIewModel(CompanyFleetModel companyFleetModel)
        {
            CompanyFleetViewModel companyFleetViewModel = new CompanyFleetViewModel();

            companyFleetViewModel.id = companyFleetModel.id;
            companyFleetViewModel.modelId = companyFleetModel.modelId;
            companyFleetViewModel.carNumber = companyFleetModel.carNumber;

            return companyFleetViewModel;
        }
    }
}
