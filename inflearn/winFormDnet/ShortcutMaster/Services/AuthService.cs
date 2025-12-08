using Microsoft.EntityFrameworkCore;
using ShortcutMaster.Data;
using ShortcutMaster.Data.Entities;
using ShortcutMaster.Data.Services;
using ShortcutMaster.Features.SignUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutMaster.Services
{
    public interface IAuthService
    {
        Task<bool> SignUpAsync(SignUpViewModel signUpViewModel);    // 회원 가입 서비스
        Task<bool> SignInAsync(string userId, string password);     // 로그인 서비스
        Task<bool> SignOutAsync();          // 로그아웃 서비스 
    }

    public class AuthService : IAuthService
    {
        private readonly IUnitOfWorkFactory<AppDbContext> _uowFactory;

        public AuthService(IUnitOfWorkFactory<AppDbContext> uowFactory)
        {
            this._uowFactory = uowFactory;
        }
        public async Task<bool> SignUpAsync(SignUpViewModel signUpViewModel)
        {
            // 비동기 using문을 사용하였기 떄문에 이 session이 블록을 빠져나가게 되면 자동으로 Dispose문이 호출
            await using var session = await _uowFactory.CreateSessionAsync();

            // 아이디가 이미 존재하는지 확인 여부
            var userService = session.Resolve<IUserService>();
            User? existingUser = await userService.FindByUserId(signUpViewModel.UserId);

            // 이미 존재하는 아이디가 있다면 false를 반환
            if (existingUser != null)
            {
                bool validPassword = BCrypt.Net.BCrypt.EnhancedVerify(signUpViewModel.Password, existingUser.Password);    // 암호 검증
                return false;
            }

            await userService.CreateUser(signUpViewModel);
            await session.CommitAsync();
            
            return true;
        }
        public Task<bool> SignInAsync(string userId, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SignOutAsync()
        {
            throw new NotImplementedException();
        }

    }
}
