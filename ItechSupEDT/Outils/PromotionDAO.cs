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
    class PromotionDAO
    {
        public static Promotion CreerPromotion(string nom, DateTime date_debut, DateTime date_fin, int id_formation)
        {
            //vzalidation nom et duree
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = ConnexionBase.GetInstance().Conn;

            cmd.CommandText = "INSERT INTO promotion(nom, date_debut, date_fin, id_formation) VALUES(@nom, @date_debut, @date_fin, @id_formation); SELECT SCOPE_IDENTITY()";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            SqlParameter nomParam = new SqlParameter("nom", SqlDbType.VarChar);
            nomParam.Value = nom;

            SqlParameter date_debutParam = new SqlParameter("date_debut", SqlDbType.DateTime);
            date_debutParam.Value = date_debut;

            SqlParameter date_finParam = new SqlParameter("date_fin", SqlDbType.DateTime);
            date_finParam.Value = date_fin;

            SqlParameter id_formation_finParam = new SqlParameter("id_formation", SqlDbType.DateTime);
            id_formation_finParam.Value = id_formation;

            cmd.Parameters.Add(nomParam);
            cmd.Parameters.Add(date_debutParam);
            cmd.Parameters.Add(date_finParam);
            cmd.Parameters.Add(id_formation_finParam);

            // lire notre dernier id
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int id = (int)reader.GetDecimal(0);

            Promotion Promotion = new Promotion(id, nom, date_debut, date_fin, id_formation);

            return Promotion;
        }
    }
}
