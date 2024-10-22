﻿

using Babel.Models;

namespace Babel.Errors
{
    public static class UserErrors
    {
        public static Error NoUsersFound => new Error("Users.NoUsersFound", "No users found.");

        public static Error UserNotFound(int id) => new Error(
            "Users.UserNotFound", $"User with ID '{id}' not found.");

        public static Error InvalidUserData => new Error("Users.InvalidUserData", "The provided user data is invalid.");
    }

}

