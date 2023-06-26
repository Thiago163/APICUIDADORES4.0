using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API_CUIDADORES.DTO
{
    public class FavoritosUsuarioDTO
    {
        // tabela favoritos
        public int id { get; set; }
        public int usuario_id { get; set; }
        public int cuidador_id { get; set; }

        // informações do cuidador
        public CuidadoresDTO cuidador { get; set; }
    }
}
