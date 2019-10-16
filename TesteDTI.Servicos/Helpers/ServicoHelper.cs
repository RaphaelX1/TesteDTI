using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteDTI.Comum;
using TesteDTI.Enumeradores;
using TesteDTI.Modelos;

namespace TesteDTI
{
    public static class ServicoHelper
    {
        public static bool FimDeSemana(this DateTime data)
        {
            if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }

            return false;
        }
    }
}
