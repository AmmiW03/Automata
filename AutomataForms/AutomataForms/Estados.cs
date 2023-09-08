using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomataForms
{
    public class Estados
    {
        public String[] Alfabeto { get; set; }
        public String[] Ruta { get; set; }

        public String evaluar(String entrada)
        {
            for (int i = 0; i < Alfabeto.Length; i++)
            {
                if (Alfabeto[i] == entrada)
                {
                    if (Ruta[i] != "null")
                        return Ruta[i];
                    return null;
                }
            }
            return null;
        }
    }
}
