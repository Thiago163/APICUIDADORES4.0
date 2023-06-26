using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CUIDADORES.DTO
{
   public class TipoDTO
    {
        public string id { get; set; }
        public string tipo { get; set; } = new string(' ', 10); // altere o valor '10' para o tamanho desejado
    }
}
