using System;
using System.Globalization;

namespace VTS.Backend.Infrastructure.AuthServer.Exceptions
{
    public class AuthServerException : Exception
    {
        public AuthServerException() : base() { }

        public AuthServerException(string message) : base(message) { }

        public AuthServerException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
