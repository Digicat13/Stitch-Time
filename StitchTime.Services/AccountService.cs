using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StitchTime.Core.Abstractions;
using StitchTime.Core.Abstractions.Services;
using StitchTime.Core.Dto;
using StitchTime.Core.Entities;
using FluentValidation;
using StitchTime.Core.Validators;
using System.Threading.Tasks;
using System;

namespace StitchTime.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserLoginDto> SignUp(UserDto dto)
        {
            var validator = new UserDtoValidator();
            validator.ValidateAndThrow(dto);

           // await IsEmalInUse(dto.Email);

            var user = new User
            {
                UserName = dto.Email,
                Email = dto.Email,
                FirstName = dto.FirstName,
                SecondName = dto.SecondName,
                PositionId = dto.PositionId
            };


            var result = await userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                var userEntity = await userManager.FindByEmailAsync(dto.Email);
                var newDto = new UserLoginDto();
                _mapper.Map(userEntity, newDto);
                return newDto;
            }
            else
            {
                throw new System.Exception();
            }

            //foreach (var error in result.Errors)
            //{
            //    ModelState.AddModelError(string.Empty, error.Description);
            //}
        }

        public async Task<UserLoginDto> SignIn(UserDto dto)
        {
            var validator = new UserDtoValidator();
            validator.ValidateAndThrow(dto);

            var user = new User
            {
                UserName = dto.Email,
                Email = dto.Email
            };

            var result = await signInManager.PasswordSignInAsync(dto.Email, dto.Password, true, false);

            if (result.Succeeded)
            {
                var userEntity = await userManager.FindByEmailAsync(dto.Email);
                var newDto = new UserLoginDto();
                _mapper.Map(userEntity, newDto);
                return newDto;
            }
            else
            {
                throw new System.Exception();
            }

            //foreach (var error in result.Errors)
            //{
            //    ModelState.AddModelError(string.Empty, error.Description);
            //}
        }

        public async Task Logout(string Id)
        {
            await signInManager.SignOutAsync();

        }

        private async Task IsEmalInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if(user != null)
            {
                throw new NullReferenceException();

            }
        }
    }
}
