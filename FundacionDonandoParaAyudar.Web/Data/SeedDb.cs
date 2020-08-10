﻿using FundacionDonandoParaAyudar.Common.Enums;
using FundacionDonandoParaAyudar.Web.Data.Entities;
using FundacionDonandoParaAyudar.Web.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace FundacionDonandoParaAyudar.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(
            DataContext dataContext,
            IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            var admin1 = await CheckUserAsync("1010",
                "Giovanni", 
                "Gomez Restrepo", 
                "giovannyg32@gmail.com", 
                "300 634 2747", 
                "Calle 1 # 1-1", 
                UserType.Admin);
            var admin2 = await CheckUserAsync("2020",
                "Hernan Yesid",
                "Gomez Osorio",
                "yesid@yopmail.com",
                "300 200 1111",
                "Calle 2 # 2-2",
                UserType.Admin);
            var user1 = await CheckUserAsync("3030", 
                "Giovanni", 
                "Gomez R", 
                "giovannigomez198077@correo.itm.edu.co", 
                "300 121 5847", 
                "Calle 2 # 2-2", 
                UserType.User);
            var user2 = await CheckUserAsync("4040",
                "Hernan Yesid",
                "Gomez Osorio",
                "yesiduser@yopmail.com",
                "300 200 2850",
                "Calle 3 # 2-2",
                UserType.User);

            await CheckCommentsAsync(user1, user2);
        }

        private async Task<UserEntity> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);

            }
            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }


        private async Task CheckCommentsAsync(
            UserEntity user1,
            UserEntity user2)
        {
            if (!_dataContext.Comments.Any())
            {
                _dataContext.Comments.Add(new FoundationEntity
                {
                    User = user1,
                    Comments = "Felicitaciones por ese gran proyecto"
                });

                _dataContext.Comments.Add(new FoundationEntity
                {
                    User = user2,
                    Comments = "Qué gran proyecto"
                });
            }
            await _dataContext.SaveChangesAsync();
        }
    }
}