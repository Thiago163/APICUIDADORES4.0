using API_CUIDADORES.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace API_CUIDADORES.DAO
{
    public class EstrelasUsuarioDAO
    {
        public List<EstrelasUsuarioDTO> Listar()
        {
            using (var conexao = ConnectionFactory.Build())
            {
                conexao.Open();

                var query = "SELECT * FROM estrelasusuario";

                var comando = new MySqlCommand(query, conexao);
                var dataReader = comando.ExecuteReader();

                var estrelas = new List<EstrelasUsuarioDTO>();

                while (dataReader.Read())
                {
                    var estrela = new EstrelasUsuarioDTO();
                    estrela.id = Convert.ToInt32(dataReader["id"]);
                    estrela.usuario_id = Convert.ToInt32(dataReader["usuario_id"]);
                    estrela.cuidador_id = Convert.ToInt32(dataReader["cuidador_id"]);
                    estrela.estrela = Convert.ToInt32(dataReader["estrela"]);

                    estrelas.Add(estrela);
                }

                return estrelas;
            }
        }

        public void Cadastrar(EstrelasUsuarioDTO estrela)
        {
            using (var conexao = ConnectionFactory.Build())
            {
                conexao.Open();

                var query = @"INSERT INTO estrelasusuario (usuario_id, cuidador_id, estrela)
                              VALUES (@usuario_id, @cuidador_id, @estrela)";

                var comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@usuario_id", estrela.usuario_id);
                comando.Parameters.AddWithValue("@cuidador_id", estrela.cuidador_id);
                comando.Parameters.AddWithValue("@estrela", estrela.estrela);

                comando.ExecuteNonQuery();
            }
        }

        public void Remover(int id)
        {
            using (var conexao = ConnectionFactory.Build())
            {
                conexao.Open();

                var query = @"DELETE FROM estrelasusuario WHERE id = @id";

                var comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@id", id);

                comando.ExecuteNonQuery();
            }
        }

        public void Alterar(EstrelasUsuarioDTO estrela)
        {
            using (var conexao = ConnectionFactory.Build())
            {
                conexao.Open();

                var query = @"UPDATE estrelasusuario SET 
                            usuario_id = @usuario_id,
                            cuidador_id = @cuidador_id,
                            estrela = @estrela
                            WHERE id = @id";

                var comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@id", estrela.id);
                comando.Parameters.AddWithValue("@usuario_id", estrela.usuario_id);
                comando.Parameters.AddWithValue("@cuidador_id", estrela.cuidador_id);
                comando.Parameters.AddWithValue("@estrela", estrela.estrela);

                comando.ExecuteNonQuery();
            }
        }
    }
}
