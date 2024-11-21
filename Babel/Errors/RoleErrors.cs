

using Babel.Models;

namespace Babel.Errors
{
    public static class RoleErrors
    {
        public static Error NoRolesFound => new Error("Roles.NoRolesFound", "No roles found.");

        public static Error RoleNotFound(int id) => new Error(
            "Roles.RoleNotFound", $"Role with ID '{id}' not found.");

        public static Error InvalidRoleData => new Error("Role.InvalidRoleData", "The provided role data is invalid.");
    }

}

