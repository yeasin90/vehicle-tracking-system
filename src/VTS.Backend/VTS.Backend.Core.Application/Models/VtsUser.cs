using System;

namespace VTS.Backend.Core.Application.Models
{
    public class VtsUser
    {
        public Guid UserId { get; set; }
        public VtsUserRole Role { get; set; }
    }
}
