using AgileForm.Models;
using AgileForm.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AgileForm.Repository
{
    public class UserRepository : IUserRepository
    {
        FormContext formContext;
        public UserRepository()
        {
            formContext = new FormContext();
        }
        public User GetByEmail(string email)
        {
            return formContext.Users.FirstOrDefault(u => u.Email == email);
        }
        public void Add(User entity)
        {
            formContext.Users.Add(entity);
        }

        public void Save()
        {
            formContext.SaveChanges();
        }
    }
}

