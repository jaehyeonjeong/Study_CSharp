using Microsoft.EntityFrameworkCore;
using ShortcutMaster.Data.Entities;
using ShortcutMaster.Features.SignUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace ShortcutMaster.Data.Services
{
    public interface IUserService
    {
        Task<User?> FindByUserId(string userId);
        // 새로운 사용자 생성 (생성하는 로직)
        Task CreateUser(SignUpViewModel signUpViewModel);
    }
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context) // 해당 컨텍스트 파라미터는 UnitOfWorkSession 의 컨텍스트와 동일하다
        {
            _context = context;
        }

        public async Task CreateUser(SignUpViewModel signUpViewModel)
        {
            // 새로운 사용자 생성 (생성하는 로직)
            User newUser = new User
            {
                UserID = signUpViewModel.UserId,
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(signUpViewModel.Password), // 암호화
                Email = signUpViewModel.Email,
            };
            await _context.AddAsync(newUser);
        }

        public Task<User?> FindByUserId(string userId)
        {
            return _context.Users
                .FirstOrDefaultAsync(u => u.UserID == userId);
        }
    }
}
