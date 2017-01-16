using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ItechSupEDT.Modele;
using ItechSupEDT.Ajout_UC;
using System.Data.SqlClient;
using ItechSupEDT.Outils;
using System.Data;

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Interaction logic for AjoutFormateur.xaml
    /// </summary>
    public partial class AjoutFormateur : UserControl
    {
        public AjoutFormateur()
        {
            InitializeComponent();
            //MutliSelectPickList multiSelect = new MutliSelectPickList(_lstMatiere);
            //this.MultiSelect.Content = multiSelect;
        }

        private void btn_valider_Click(object sender, RoutedEventArgs e)
        {
            String nom = tb_nomFormateur.Text;
            String prenom = tb_prenomFormateur.Text;
            String mail = tb_mailFormateur.Text;
            String telephone = tb_telephoneFormateur.Text;
            SqlCommand cmdInsert = new SqlCommand();
            SqlConnection conn = ConnexionBase.GetInstance().Conn;

            try
            {
                try
                {
                    cmdInsert.CommandText = "INSERT INTO formateur(nom, prenom, mail, telephone) VALUES('"+ nom + "','" + prenom + "','" + mail + "','" + telephone + "');";
                    cmdInsert.CommandType = CommandType.Text;
                    cmdInsert.Connection = conn;
                    cmdInsert.ExecuteReader();
                    this.tbk_retourMessage.Text = "Formateur ajouté";

                    tb_nomFormateur.Clear();
                    tb_mailFormateur.Clear();
                    tb_prenomFormateur.Clear();
                    tb_telephoneFormateur.Clear();
                    //conn.Close();
                    //this.LstMatiere.Add(new Matiere(this.tb_nomMatiere.Text));
                    //this.tbk_retourMessage.Text = "Formateur ajouté";
                }
                catch (Formateur.FormateurException error)
                {
                    tbk_errorMessage.Text = error.Message;
                }
            }
            catch (Exception)
            {
                tbk_errorMessage.Text = "Désolé, une erreur est survenu lors de l'ajout du formateur, veuillez vérifier les informations renseignées et recommencer.";
            }
        }
    }
}
