using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Core.Exceptions
{
    public class ConflictException: Exception
    {
        public ConflictException(string message) 
            : base("Este email já esta cadastrado.") 
        { }
    }
}
