using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace escolauc10a.Class
{
    public class Professor
    {
        public Professor()
        {

        }   

        public Professor(string nome_prof, string cpf_prof, string email_prof, string tel_prof) // método construtor
        {
            //Id_prof = id_prof;
            Nome_prof = nome_prof;
            Cpf_prof = cpf_prof;
            Email_prof = email_prof;
            Tel_prof = tel_prof;
        }

        //Propriedades de professor.
        public int Id_prof { get; set; }
        public string Nome_prof { get; set; }
        public string Cpf_prof { get; set; }
        public string Email_prof { get; set; }
        public string Tel_prof { get; set; }

        public List<Professor> ObterProfessor()
        {
            List<Professor> lista = new List<Professor>();
            var cmd = Banco.Abrir();
            if (cmd.Connection.State == System.Data.ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from professor";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Professor(
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetString(3),
                    dr.GetString(4)
                    ));
                }
            }
            return lista;
        }

        public void Inserir()
        {
            var cmd = Banco.Abrir();
            if (cmd.Connection.State == System.Data.ConnectionState.Open)
            {
                //erro no execute
                cmd.CommandText = "insert professor (nome,cpf,email,telefone)" +
                 "values('" + Nome_prof + "','" + Cpf_prof + "','" +Email_prof+ "','" + Tel_prof + "')";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select @@identity";
                Id_prof = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void BuscarPorId(int id)
        {
            var cmd = Banco.Abrir();
            if (cmd.Connection.State == System.Data.ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from professor where id = " + id;
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Nome_prof = dr.GetString(1);
                    Cpf_prof = dr.GetString(2);
                    Email_prof = dr.GetString(3);
                    Tel_prof = dr.GetString(4);

                }
            }
        }

        public bool Editar()
        {
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandText = "update professor set nome = '" + Nome_prof + "'" +
                ", telefone = " + Tel_prof + "where id= " + Id_prof;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }// final do método atualizar


    }
}
