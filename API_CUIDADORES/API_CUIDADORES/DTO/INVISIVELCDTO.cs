using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CUIDADORES.DTO
{
    public class INVISIVELCDTO
    {
        // tabela cuidadores invisiivel
        public string tipo { get; set; }
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public DateTime data_de_nasc { get; set; }
        public string cpf { get; set; }
        public string celular { get; set; }
        public string endereco { get; set; }
        public string cep { get; set; }
        public string email { get; set; }
        public double preco { get; set; }
        public string descricao { get; set; }
        public string imagem { get; set; }
        public string link { get; set; }
        public string sexo { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string bairro { get; set; }
        public string senha { get; set; }
    }
}
