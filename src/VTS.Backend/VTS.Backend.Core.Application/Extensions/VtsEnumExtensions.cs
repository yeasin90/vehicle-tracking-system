using System;
using VTS.Backend.Core.Application.Models;

namespace VTS.Backend.Core.Application.Extensions
{
    public static class VtsEnumExtensions
    {
        public static VtsUserRole ToVtsUserRoleEnum(this string roleString)
        {
            Enum.TryParse(roleString, out VtsUserRole result);
            return result;
        }
    }
}
