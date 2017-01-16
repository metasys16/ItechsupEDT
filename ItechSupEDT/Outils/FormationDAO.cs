using ItechSupEDT.Modele;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Outils
{
    class FormationDAO 
    {
        public static Formation CreerFormation(string nom, float duree)
        {
            //vzalidation nom et duree
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = ConnexionBase.GetInstance().Conn;

            cmd.CommandText = "INSERT INTO formation(nom, nb_heures_total) VALUES(@nom, @duree); SELECT SCOPE_IDENTITY()";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            SqlParameter nomParam = new SqlParameter("nom", SqlDbType.VarChar);
            nomParam.Value = nom;

            SqlParameter dureeParam = new SqlParameter("duree", SqlDbType.Float);
            dureeParam.Value = duree;

            cmd.Parameters.Add(nomParam);
            cmd.Parameters.Add(dureeParam);

            // lire notre dernier id
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int id = (int)reader.GetDecimal(0);

            Formation Formation = new Formation(id, nom, duree);

            return Formation;
        }

        public static List<Formation> ListerFormation()
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = ConnexionBase.GetInstance().Conn;
            List<Formation> formationListe = new List<Formation>();

            cmd.CommandText = "SELECT * FROM formation;";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader.GetInt32(0);
                string nom = (string)reader.GetString(1);

                //float duree = (float)reader.GetFloat(2);
                float duree = float.Parse(reader["nb_heures_total"].ToString());

                Formation formation = new Formation(id, nom, duree);
                formationListe.Add(formation); // ajouter ligne courante à la liste.
            }

            return formationListe;
        }
    }
}
