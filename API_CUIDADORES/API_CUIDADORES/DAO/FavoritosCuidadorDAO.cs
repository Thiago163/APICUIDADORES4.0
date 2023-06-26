using API_CUIDADORES.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CUIDADORES.DAO
{
    public class FavoritosCuidadorDAO
    {
        public List<FavoritosCuidadorDTO> Listar(int Id)
        {
            var favoritos = new List<FavoritosCuidadorDTO>();

            using (var conexao = ConnectionFactory.Build())
            {
                conexao.Open();

                var query = @"SELECT fu.id, c.id, c.nome, c.sobrenome, c.data_de_nasc, c.cpf, c.celular, c.endereco,
                      c.cep, c.email, c.preco, c.descricao, c.imagem,
                      c.link, sx.sexo, c.cidade, c.estado, c.bairro, c.senha, ti.tipo, sx.sexo,
                      fu.usuario_id, fu.cuidador_id
                      FROM favoritosusuarios AS fu
                      JOIN usuarios AS c ON fu.usuario_id = c.id
                      JOIN tipos AS ti ON c.tipos_id = ti.id
                      JOIN sexos AS sx ON c.sexos_id = sx.id
                      WHERE fu.cuidador_id = @id AND c.tipos_id <> 2";

                using (var comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@id", Id);

                    using (var dataReader = comando.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            var favorito = new FavoritosCuidadorDTO();
                            favorito.id = Convert.ToInt32(dataReader["id"]);
                            favorito.usuario_id = Convert.ToInt32(dataReader["usuario_id"]);
                            favorito.cuidador_id = Convert.ToInt32(dataReader["cuidador_id"]);

                            // dados externos
                            favorito.usuario = new UsuariosDTO();
                            favorito.usuario.tipo = dataReader["tipo"].ToString();
                            favorito.usuario.id = Convert.ToInt32(dataReader["id"]);
                            favorito.usuario.nome = dataReader["nome"].ToString();
                            favorito.usuario.sobrenome = dataReader["sobrenome"].ToString();
                            favorito.usuario.data_de_nasc = Convert.ToDateTime(dataReader["data_de_nasc"]);
                            favorito.usuario.cpf = dataReader["cpf"].ToString();
                            favorito.usuario.celular = dataReader["celular"].ToString();
                            favorito.usuario.endereco = dataReader["endereco"].ToString();
                            favorito.usuario.cep = dataReader["cep"].ToString();
                            favorito.usuario.email = dataReader["email"].ToString();
                            favorito.usuario.preco = Convert.ToDouble(dataReader["preco"]);
                            favorito.usuario.descricao = dataReader["descricao"].ToString();
                            favorito.usuario.imagem = dataReader["imagem"].ToString();
                            favorito.usuario.link = dataReader["link"].ToString();
                            favorito.usuario.sexo = dataReader["sexo"].ToString();
                            favorito.usuario.cidade = dataReader["cidade"].ToString();
                            favorito.usuario.estado = dataReader["estado"].ToString();
                            favorito.usuario.bairro = dataReader["bairro"].ToString();
                            favorito.usuario.senha = dataReader["senha"].ToString();

                            favoritos.Add(favorito);
                        }
                    }
                }

                conexao.Close();
            }

            return favoritos;
        }


        public void Cadastrar(FavoritosCuidadorDTO favorito)
        {
            using (var conexao = ConnectionFactory.Build())
            {
                conexao.Open();

                var query = @"INSERT IGNORE INTO favoritoscuidadores (usuario_id, cuidador_id)
                              VALUES (@usuario_id, @cuidador_id)";

                using (var comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@usuario_id", favorito.usuario_id);
                    comando.Parameters.AddWithValue("@cuidador_id", favorito.cuidador_id);

                    comando.ExecuteNonQuery();
                }

                conexao.Close();
            }
        }

        public bool FavoritoJaExiste(FavoritosCuidadorDTO favorito)
        {
            using (var conexao = ConnectionFactory.Build())
            {
                conexao.Open();

                var query = @"SELECT * FROM favoritoscuidadores WHERE usuario_id = @usuario_id AND cuidador_id = @cuidador_id";

                using (var comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@usuario_id", favorito.usuario_id);
                    comando.Parameters.AddWithValue("@cuidador_id", favorito.cuidador_id);

                    using (var resultado = comando.ExecuteReader())
                    {
                        var favoritoJaExiste = resultado.HasRows;

                        resultado.Close();

                        return favoritoJaExiste;
                    }
                }
            }
        }

        public void Remover(int usuario_id, int cuidador_id)
        {
            using (var conexao = ConnectionFactory.Build())
            {
                conexao.Open();

                var query = "DELETE FROM favoritoscuidadores WHERE usuario_id = @usuario_id and cuidador_id = @cuidador_id";

                using (var comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@usuario_id", usuario_id);
                    comando.Parameters.AddWithValue("@cuidador_id", cuidador_id);

                    comando.ExecuteNonQuery();
                }

                conexao.Close();
            }
        }

        public void Alterar(FavoritosCuidadorDTO favorito)
        {
            using (var conexao = ConnectionFactory.Build())
            {
                conexao.Open();

                var query = @"UPDATE favoritoscuidadores SET 
                              usuario_id = @usuario_id,
                              cuidador_id = @cuidador_id
                              WHERE id = @id";

                using (var comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@id", favorito.id);
                    comando.Parameters.AddWithValue("@usuario_id", favorito.usuario_id);
                    comando.Parameters.AddWithValue("@cuidador_id", favorito.cuidador_id);

                    comando.ExecuteNonQuery();
                }

                conexao.Close();
            }
        }
    }
}
