using API_CUIDADORES.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CUIDADORES.DAO
{
    public class SexoDAO
    {
        public List<SexoDTO> Listar()
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT * FROM sexos";

            var comando = new MySqlCommand(query, conexao);
            var dataReader = comando.ExecuteReader();

            var cuidadores = new List<SexoDTO>();

            while (dataReader.Read())
            {
                var cuidador = new SexoDTO();
                cuidador.id = int.Parse(dataReader["id"].ToString());
                cuidador.sexo = dataReader["sexo"].ToString();

                cuidadores.Add(cuidador);
            }
            conexao.Close();

            return cuidadores;
        }

        public void Cadastrar(SexoDTO sexo)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"INSERT INTO sexos (id, sexo) VALUES (@id, @sexo)";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@id", sexo.id);
            comando.Parameters.AddWithValue("@sexo", sexo.sexo);

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public void Remover(int id)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"BEGIN;
    DELETE FROM recentescuidadores WHERE cuidador_id IN (SELECT id FROM cuidadores WHERE sexos_id = @id);
    DELETE FROM recentesusuarios WHERE usuario_id IN (SELECT id FROM usuarios WHERE sexos_id = @id);
    DELETE FROM favoritoscuidadores WHERE cuidador_id IN (SELECT id FROM cuidadores WHERE sexos_id = @id);
    DELETE FROM estrelascuidador WHERE cuidador_id IN (SELECT id FROM cuidadores WHERE sexos_id = @id);
    DELETE FROM favoritosusuarios WHERE cuidador_id IN (SELECT id FROM cuidadores WHERE sexos_id = @id);
    DELETE FROM estrelasusuario WHERE cuidador_id IN (SELECT id FROM cuidadores WHERE sexos_id = @id);
    DELETE FROM favoritoscuidadores WHERE usuario_id IN (SELECT id FROM usuarios WHERE sexos_id = @id);
    DELETE FROM estrelascuidador WHERE usuario_id IN (SELECT id FROM usuarios WHERE sexos_id = @id);
    DELETE FROM favoritosusuarios WHERE usuario_id IN (SELECT id FROM usuarios WHERE sexos_id = @id);
    DELETE FROM estrelasusuario WHERE usuario_id IN (SELECT id FROM usuarios WHERE sexos_id = @id);
    DELETE FROM cuidadores WHERE sexos_id = @id;
    DELETE FROM usuarios WHERE sexos_id = @id;
    DELETE FROM sexos WHERE id = @id;
COMMIT;";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            conexao.Close();

        }

        public void Alterar(SexoDTO sexo)
        {
            using (var conexao = ConnectionFactory.Build())
            using (var comando = conexao.CreateCommand())
            {
                conexao.Open();

                comando.CommandText = "UPDATE sexos SET id = @id, sexo = @sexo WHERE id = @id";
                comando.Parameters.AddWithValue("@id", sexo.id);
                comando.Parameters.AddWithValue("@sexo", sexo.sexo);

                comando.ExecuteNonQuery();
            }
        }

    }
}
