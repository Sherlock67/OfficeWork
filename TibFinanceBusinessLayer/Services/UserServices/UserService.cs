using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibFinanceDataAccess.Models;
using TibFinanceDataAccess.Repository.RolesRepository;
using TibFinanceDataAccess.Repository.UserRepository;

namespace TibFinanceBusinessLayer.Services.UserServices
{
    public class UserService
    {
        private readonly UserRepository userRepository;
        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public User CreateUser(User user)
        {
            return userRepository.Create(user);
        }
        public bool DeleteUser(int id)
        {
            try
            {
                //var user = userRepository.GetById(id);
                userRepository.Delete(id);
                return true;
            }

            catch (Exception)
            {
                return false;
                throw;

            }
           
        }
        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return userRepository.GetAll().ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public User GetUserById(int? userId)
        {
            return userRepository.GetById(userId);
            // var menu = _menuRepository.GetById(menuId);

            //  throw new NotImplementedException();
        }
        public void UpdateUser(User user)
        {
            try
            {
                userRepository.Update(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // throw new NotImplementedException();
        }
    }
}
