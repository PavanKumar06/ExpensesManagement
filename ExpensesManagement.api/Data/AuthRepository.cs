using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpensesManagement.api.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManagement.api.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext Context;

        public AuthRepository(DataContext context)
        {
            Context = context;
        }
        public async Task<User> Login(string username, string password)
        {
            var user = await Context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if(user == null)
            {
                return null;
            }

            // var hi = await Context.Users.FromSqlRaw($"Select Name from Users").ToListAsync();

            // var unique = await Context.Taxes.FromSqlRaw($"SELECT * from Taxes Group By Username;").ToListAsync();

            // var name = await Context.Users.FromSqlRaw($"Select Name from Users where Username = '{username}'").ToListAsync();

            // foreach(var x in hi)
            // {
                
            // }

            if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < computedHash.Length; ++i)
                {
                    if(computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte [] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await Context.Users.AddAsync(user);

            await Context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()) {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if(await Context.Users.AnyAsync(x => x.Username == username))
            {
                return true;
            }
            
            return false;
        }
    }
}