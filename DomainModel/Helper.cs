using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public static class Helper
    {
        public static Func<string, int, int, bool> validatingTxtLong = (texto, min, max) => texto.Length >= min && texto.Length <= max;
        //nombre de usuario no disponible
        
    }
}
