using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CUIDADORES.DAO
{
	public class ConnectionFactory
	{
		public static MySqlConnection Build()
		{
			return new MySqlConnection("Server=localhost;Database=cuidadores;Uid=root;Pwd=root;");
		}
	}
}
