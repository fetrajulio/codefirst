using entityCodeFirst.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace entityCodeFirst.Repo
{
    public class MySqlMeth
    {
        MySqlConnection con = new MySqlConnection("Server = localhost; user=root;database=CodeFirst;password=;port=3306");
        public List<Person> AmiConect(string name)
        {
            List<Person> list = new List<Person>();
            using (con)
            {
                con.Open();
                
                string strAmis = "SELECT p2.* FROM`amis`as am JOIN persons as p1 on P1.Id=am.IdP1 JOIN persons as p2 on P2.Id=am.IdP2 WHERE P1.Name='"+name+"'";
                MySqlCommand cmd = new MySqlCommand(strAmis, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Person person = new Person()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Email= reader["Email"].ToString(),
                        Pass= reader["Pass"].ToString(),
                        IdClasse= Convert.ToInt32(reader["IdClasse"]),
                        Age= Convert.ToInt32(reader["Age"]),
                        Connect=Convert.ToInt32(reader["Connect"]),
                    };
                    
                   list.Add(person);
                }
                con.Close();
                return list;
            }
        }
    }
}
