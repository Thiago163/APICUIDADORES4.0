using API_CUIDADORES.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CUIDADORES.DAO
{
    public class UsuariosDAO
    {
        public UsuariosDTO Login(string cpfOuEmail, string senha)
        {
            var usuario = new UsuariosDTO();

            using (var conexao = ConnectionFactory.Build())
            {
                var query = "SELECT * FROM usuarios AS cui " +
             "JOIN sexos AS sx ON cui.sexos_id = sx.id " +
             "JOIN tipos AS ti ON cui.tipos_id = ti.id " +
             "WHERE (cui.cpf = @cpfOuEmail OR cui.email = @cpfOuEmail) " +
             "AND cui.senha = @senha " +
             "AND cui.tipos_id <> 2";

                using (var comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@cpfOuEmail", cpfOuEmail);
                    comando.Parameters.AddWithValue("@senha", senha);

                    conexao.Open();

                    using (var dataReader = comando.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            usuario.id = int.Parse(dataReader["id"].ToString());
                            usuario.nome = dataReader["nome"].ToString();
                            usuario.sobrenome = dataReader["sobrenome"].ToString();
                            usuario.data_de_nasc = dataReader.GetDateTime("data_de_nasc");
                            usuario.cpf = dataReader["cpf"].ToString();
                            usuario.celular = dataReader["celular"].ToString();
                            usuario.endereco = dataReader["endereco"].ToString();
                            usuario.cep = dataReader["cep"].ToString();
                            usuario.email = dataReader["email"].ToString();
                            usuario.preco = double.Parse(dataReader["preco"].ToString());
                            usuario.descricao = dataReader["descricao"].ToString();
                            usuario.imagem = dataReader["imagem"].ToString();
                            usuario.link = dataReader["link"].ToString();
                            usuario.sexo = dataReader["sexo"].ToString();
                            usuario.cidade = dataReader["cidade"].ToString();
                            usuario.estado = dataReader["estado"].ToString();
                            usuario.bairro = dataReader["bairro"].ToString();
                        }
                    }
                }
            }

            return usuario;
        }

        public List<UsuariosDTO> Listar()
        {
            var usuarios = new List<UsuariosDTO>();

            using (var conexao = ConnectionFactory.Build())
            {
                var query = "SELECT ti.tipo, cui.id, cui.nome, cui.sobrenome, cui.data_de_nasc, cui.cpf, cui.celular, cui.endereco, " +
                            "cui.cep, cui.email, cui.preco, cui.descricao, cui.imagem, " +
                            "cui.link, sx.sexo, cui.cidade, cui.estado, cui.bairro, 'senha' AS senha " +
                            "FROM usuarios AS cui " +
                            "JOIN sexos AS sx ON cui.sexos_id = sx.id " +
                            "JOIN tipos AS ti ON cui.tipos_id = ti.id " +
                            "WHERE tipos_id <> 2";

                using (var comando = new MySqlCommand(query, conexao))
                {
                    conexao.Open();

                    using (var dataReader = comando.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            var usuario = new UsuariosDTO();

                            usuario.tipo = dataReader["tipo"].ToString();
                            usuario.id = int.Parse(dataReader["id"].ToString());
                            usuario.nome = dataReader["nome"].ToString();
                            usuario.sobrenome = dataReader["sobrenome"].ToString();
                            usuario.cpf = dataReader["cpf"].ToString();
                            usuario.celular = dataReader["celular"].ToString();
                            usuario.endereco = dataReader["endereco"].ToString();
                            usuario.cep = dataReader["cep"].ToString();
                            usuario.email = dataReader["email"].ToString();
                            usuario.preco = double.Parse(dataReader["preco"].ToString());
                            usuario.descricao = dataReader["descricao"].ToString();
                            usuario.data_de_nasc = dataReader.GetDateTime("data_de_nasc");
                            usuario.imagem = dataReader["imagem"].ToString();
                            usuario.link = dataReader["link"].ToString();
                            usuario.sexo = dataReader["sexo"].ToString();
                            usuario.cidade = dataReader["cidade"].ToString();
                            usuario.estado = dataReader["estado"].ToString();
                            usuario.bairro = dataReader["bairro"].ToString();
			    usuario.senha = dataReader["senha"].ToString();

                            usuarios.Add(usuario);
                        }
                    }
                }

                conexao.Close();
            }

            return usuarios;
        }

        public void Cadastrar(UsuariosDTO usuario)
        {
            using (var conexao = ConnectionFactory.Build())
            {
                conexao.Open();

                var query = @"INSERT INTO usuarios (cidade, sexos_id, estado, nome, sobrenome, data_de_nasc, cpf, celular,
                    endereco, cep, email, preco, senha, descricao, link, bairro, imagem)
                  VALUES (@cidade, IFNULL(@sexos_id, 4), @estado, @nome, @sobrenome, @data_de_nasc, @cpf, @celular,
                          @endereco, @cep, @email, @preco, @senha, @descricao, @link, @bairro, @imagem)";

                var comando = new MySqlCommand(query, conexao);

                comando.Parameters.AddWithValue("@cidade", usuario.cidade);
                comando.Parameters.AddWithValue("@sexos_id", usuario.sexo);
                comando.Parameters.AddWithValue("@estado", usuario.estado);
                comando.Parameters.AddWithValue("@nome", usuario.nome);
                comando.Parameters.AddWithValue("@sobrenome", usuario.sobrenome);
                comando.Parameters.AddWithValue("@data_de_nasc", usuario.data_de_nasc);
                comando.Parameters.AddWithValue("@cpf", usuario.cpf);
                comando.Parameters.AddWithValue("@celular", usuario.celular);
                comando.Parameters.AddWithValue("@endereco", usuario.endereco);
                comando.Parameters.AddWithValue("@cep", usuario.cep);
                comando.Parameters.AddWithValue("@email", usuario.email);
                comando.Parameters.AddWithValue("@preco", usuario.preco);
                comando.Parameters.AddWithValue("@senha", usuario.senha);
                comando.Parameters.AddWithValue("@descricao", usuario.descricao);
                comando.Parameters.AddWithValue("@link", usuario.link);
                comando.Parameters.AddWithValue("@bairro", usuario.bairro);
                comando.Parameters.AddWithValue("@imagem", usuario.imagem);

                comando.ExecuteNonQuery();
            }
        }


        public void Remover(int id)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"
	DELETE FROM recentescuidadores WHERE usuario_id = @id;
        DELETE FROM recentesusuarios WHERE usuario_id = @id;
        DELETE FROM favoritoscuidadores WHERE usuario_id = @id;
        DELETE FROM estrelascuidador WHERE usuario_id = @id;
        DELETE FROM favoritosusuarios WHERE usuario_id = @id;
        DELETE FROM estrelasusuario WHERE usuario_id = @id;
        DELETE FROM usuarios WHERE id = @id;
    ";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public void Alterar(UsuariosDTO usuario)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"UPDATE usuarios SET 
                        tipos_id = IFNULL(@tipos_id, 1),
                        nome = IFNULL(@nome, nome),
                        sobrenome = IFNULL(@sobrenome, sobrenome),
                        cidade = IFNULL(@cidade, cidade),
                        sexos_id = IFNULL(@sexos_id, sexos_id),
                        estado = IFNULL(@estado, estado),
                        data_de_nasc = IFNULL(@data_de_nasc, data_de_nasc),
                        cpf = IFNULL(@cpf, cpf),
                        celular = IFNULL(@celular, celular),
                        endereco = IFNULL(@endereco, endereco),
                        cep = IFNULL(@cep, cep),
                        email = IFNULL(@email, email),
                        preco = IFNULL(@preco, preco),
                        senha = IFNULL(@senha, senha),
                        descricao = IFNULL(@descricao, descricao),
                        link = IFNULL(@link, link),
                        bairro = IFNULL(@bairro, bairro),
                        imagem = IFNULL(@imagem, imagem)
                WHERE id = @id";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@id", usuario.id);
            comando.Parameters.AddWithValue("@tipos_id", usuario.tipo);
            comando.Parameters.AddWithValue("@cidade", usuario.cidade);
            comando.Parameters.AddWithValue("@sexos_id", usuario.sexo);
            comando.Parameters.AddWithValue("@estado", usuario.estado);
            comando.Parameters.AddWithValue("@nome", usuario.nome);
            comando.Parameters.AddWithValue("@sobrenome", usuario.sobrenome);
            comando.Parameters.AddWithValue("@data_de_nasc", usuario.data_de_nasc);
            comando.Parameters.AddWithValue("@cpf", usuario.cpf);
            comando.Parameters.AddWithValue("@celular", usuario.celular);
            comando.Parameters.AddWithValue("@endereco", usuario.endereco);
            comando.Parameters.AddWithValue("@cep", usuario.cep);
            comando.Parameters.AddWithValue("@email", usuario.email);
            comando.Parameters.AddWithValue("@preco", usuario.preco);
            comando.Parameters.AddWithValue("@senha", usuario.senha);
            comando.Parameters.AddWithValue("@descricao", usuario.descricao);
            comando.Parameters.AddWithValue("@link", usuario.link);
            comando.Parameters.AddWithValue("@bairro", usuario.bairro);
            comando.Parameters.AddWithValue("@imagem", usuario.imagem);

            comando.ExecuteNonQuery();
            conexao.Close();

        }

    }
}
