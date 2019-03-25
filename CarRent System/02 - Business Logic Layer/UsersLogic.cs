using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRent
{
    public class UsersLogic : BaseLogic
    {

        public List<UserModel> GetAllUsers()
        {
            if(true)
            {
                return DB.Users.Select(u => new UserModel
                {
                    id = u.Id,
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    userName = u.UserName,
                    password = u.Password,
                    telephone = u.Telephone,
                    email = u.Email,
                    dateOfBirth = u.DateOfBirth,
                    role = u.Role
                }).ToList();
            }
            else
            {
                throw new ArgumentException("User not valid");
            }

        }

        public UserModel GetOneUser(int id)
        {
            return DB.Users
              .Where(u => u.Id == id)
              .Select(u => new UserModel
              {
                  firstName = u.FirstName,
                  lastName = u.LastName,
                  telephone = u.Telephone,
                  userName = u.UserName,
                  email = u.Email,
                  dateOfBirth = u.DateOfBirth
              }).SingleOrDefault();
        }

        public UserModel AddUser(UserModel userModel)
        {
            if (Validations.ValidateUserPassword(userModel) && Validations.ValidateUserTelephone(userModel))
            {
                User user = new User
                {
                    FirstName = userModel.firstName,
                    LastName = userModel.lastName,
                    UserName = userModel.userName,
                    Password = userModel.password,
                    Telephone = userModel.telephone,
                    Email = userModel.email,
                    DateOfBirth = userModel.dateOfBirth,

                    Role = "user"
                };
                DB.Users.Add(user);
                DB.SaveChanges();

                return GetOneUser(user.Id);
            }
            else
            {
                throw new ArgumentException("User not valid");
            }
        }

        public bool CheckIfUserExists(UserModel userModel)
        {
            return DB.Users.Any(user => user.UserName == userModel.userName);
        }

    }
}

