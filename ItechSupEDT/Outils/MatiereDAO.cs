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
    class MatiereDAO
    {
        public static Matiere CreerMatiere(string nom)
        {
            //vzalidation nom et duree
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = ConnexionBase.GetInstance().Conn;

            cmd.CommandText = "INSERT INTO matiere(nom) VALUES(@nom); SELECT SCOPE_IDENTITY()";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            SqlParameter nomParam = new SqlParameter("nom", SqlDbType.VarChar);
            nomParam.Value = nom;

            cmd.Parameters.Add(nomParam);
            cmd.ExecuteReader();

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int id = (int)reader.GetDecimal(0);

            Matiere Matiere = new Matiere(id, nom);

            return Matiere;
        }
    }
}
