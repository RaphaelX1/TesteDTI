using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDTI.Comum
{
   public class RegraDeNegocioException : Exception
    {
        public RegraDeNegocioException(string message) : base(message)
        {

        }
    }
}
