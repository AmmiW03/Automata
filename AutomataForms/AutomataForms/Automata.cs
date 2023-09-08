using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutomataForms
{
    public class Automata
    {
        public List<Estados> estados { get; set; }
        public String estadoInicial { get; set; }
        public String estadoFinal { get; set; }
        public String camino { get; set; }

        public bool evaluar(String entrada)
        {
            String[] entradas = entrada.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            String aux = estadoInicial;
            camino = aux.ToString();
            for (int i = 0; i < entradas.Length; i++)
            {
                aux = estados[int.Parse(aux)].evaluar(entradas[i]);
                if (aux == null)
                {
                    return false;
                }
                camino += " " + aux;
            }
            if (aux == estadoFinal)
                return true;
            else
                return false;
        }
    }
}
