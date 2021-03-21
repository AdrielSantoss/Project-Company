using Api.Core.Exceptions;
using Api.Core.Utils;
using Api.DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.DB.Repository
{
    public class UserRepository
    {
        private DatabaseContext _db;

        public UserRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<User> CreateUser(string name, string email, string password)
        {
            var existngUser = await _db.Users.FirstOrDefaultAsync(user => user.Email == email);
            if (existngUser != null)
            {
                throw new ConflictException("Este E-mail já está cadastrado.");
            }
            
            var newUser = new User
            {
                Email = email,
                Name = name,
                Senha = PasswordHasher.Hash(password)
            };

            await _db.Users.AddAsync(newUser);
            await _db.SaveChangesAsync();

            return newUser;
        } 
    }
}
