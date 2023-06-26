using API_CUIDADORES.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CUIDADORES.DAO
{
    public class TiposDAO
    {
        public List<TipoDTO> Listar()
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT * FROM tipos";

            var comando = new MySqlCommand(query, conexao);
            var dataReader = comando.ExecuteReader();

            var tipos = new List<TipoDTO>();

            while (dataReader.Read())
            {
                var tipo = new TipoDTO();
                tipo.id = dataReader["id"].ToString();
                tipo.tipo = dataReader["tipo"].ToString();

                tipos.Add(tipo);
            }

            conexao.Close();

            return tipos;
        }

        public void Cadastrar(TipoDTO tipo)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"INSERT INTO tipos (id, tipo) VALUES (@id, @tipo)";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@id", tipo.id);
            comando.Parameters.AddWithValue("@tipo", tipo.tipo);

            try
            {
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    throw new ArgumentException($"O tipo com id {tipo.id} já existe na tabela tipos.");
                }
                else
                {
                    throw ex;
                }
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Remover(int id)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"
        DELETE FROM recentesusuarios WHERE cuidador_id IN (SELECT id FROM cuidadores WHERE tipos_id = @id);
        DELETE FROM recentescuidadores WHERE cuidador_id IN (SELECT id FROM cuidadores WHERE tipos_id = @id);
        DELETE FROM favoritoscuidadores WHERE cuidador_id IN (SELECT id FROM cuidadores WHERE tipos_id = @id);
        DELETE FROM estrelascuidador WHERE cuidador_id IN (SELECT id FROM cuidadores WHERE tipos_id = @id);
        DELETE FROM favoritosusuarios WHERE cuidador_id IN (SELECT id FROM cuidadores WHERE tipos_id = @id);
        DELETE FROM estrelasusuario WHERE cuidador_id IN (SELECT id FROM cuidadores WHERE tipos_id = @id);
        DELETE FROM favoritoscuidadores WHERE usuario_id IN (SELECT id FROM usuarios WHERE tipos_id = @id);
        DELETE FROM estrelascuidador WHERE usuario_id IN (SELECT id FROM usuarios WHERE tipos_id = @id);
        DELETE FROM favoritosusuarios WHERE usuario_id IN (SELECT id FROM usuarios WHERE tipos_id = @id);
        DELETE FROM estrelasusuario WHERE usuario_id IN (SELECT id FROM usuarios WHERE tipos_id = @id);
        DELETE FROM cuidadores WHERE tipos_id = @id;
        DELETE FROM usuarios WHERE tipos_id = @id;
        DELETE FROM tipos WHERE id=@id;
    ";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            conexao.Close();
        }


        public void Alterar(TipoDTO tipo)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"UPDATE tipos SET 
                        id = @id,
                        tipo = @tipo
                        WHERE id = @id";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@id", tipo.id);
            comando.Parameters.AddWithValue("@tipo", tipo.tipo);

            comando.ExecuteNonQuery();

            conexao.Close();
        }
    }
}
