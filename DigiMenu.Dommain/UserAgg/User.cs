﻿using Common.Domain;
using Common.Domain.Exceptions;
using DigiMenu.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        private User() { }
        public User(string firstName, string lastName, string username, string password, IUserDomainService userService)
        {
            HandlePropertiesValidation(username, userService, password);
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            AvatarName = "avatar.png";
            IsActive = true;
            Roles = new();
            UserTokens = new();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string AvatarName { get; private set; }
        public bool IsActive { get; private set; }
        public List<UserRole> Roles { get; }
        public List<UserToken> UserTokens { get; }

        #region Methods

        public void Edit(string firstName, string lastName, string username, bool? isActive, IUserDomainService userService)
        {
            HandlePropertiesValidation(username, userService);
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            if (isActive != null)
            {
                IsActive = isActive.Value;
            }
        }

        public void AddRoles(List<UserRole> roles)
        {
            roles.ForEach(role => role.UserId = Id);
            Roles.Clear();
            Roles.AddRange(roles);
        }

        public void SetAvatarImage(string avatar)
        {
            if (string.IsNullOrWhiteSpace(avatar))
            {
                avatar = "avatar.png";
            }
            AvatarName = avatar;
        }

        public void AddUserToken(string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            var token = new UserToken(hashJwtToken, hashRefreshToken, tokenExpireDate, refreshTokenExpireDate, device);
            token.UserId = Id;
            UserTokens.Add(token);

        }

        public void RemoveUserToken(long tokenId)
        {
            var token = UserTokens.FirstOrDefault(x => x.Id == tokenId);
            if (token == null) throw new InvalidDomainDataException("Invalid Token");
            UserTokens.Remove(token);
        }

        public void HandlePropertiesValidation(string username, IUserDomainService userService, string? password = null)
        {
            NullOrEmptyException.CheckNotEmpty(username, nameof(username));
            if (password != null)
            {
                NullOrEmptyException.CheckNotEmpty(password, nameof(password));
            }

            //if (HasManageAccess(Id))
            //{
            //    return;
            //}

            if (username != Username)
            {
                if (userService.IsUsernameExist(username))
                {
                    throw new InvalidDomainDataException("نام کاربری تکراری است");
                }
            }

        }

        //private bool HasManageAccess(long userId)
        //{
        //    return false;

        //}

        public static User RegisterUser(string username, string password, IUserDomainService userService)
        {
            return new User("", "", username, password, userService);
        }

        public void ChangePassword(string newPassword)
        {
            NullOrEmptyException.CheckNotEmpty(newPassword, nameof(newPassword));

            Password = newPassword;
        }


        #endregion
    }
}
