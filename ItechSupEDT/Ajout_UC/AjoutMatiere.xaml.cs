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
using System.Data.SqlClient;
using ItechSupEDT.Outils;
using System.Data;

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Interaction logic for AjoutMatiere.xaml
    /// </summary>
    public partial class AjoutMatiere : UserControl
    {
        public AjoutMatiere()
        {
            InitializeComponent();
        }

        private void btn_valider_Click(object sender, RoutedEventArgs e)
        {
            String nom = tb_nomMatiere.Text;

            try
            {
                if (tb_nomMatiere.Text.Count() > 1)
                {
                    MatiereDAO.CreerMatiere(nom);
                    this.tbk_retourMessage.Text = "Matiere ajoutée";
                    // Effacer les saisies pour en saisir d'autres à la suite
                    tb_nomMatiere.Clear();
                }
                else
                {
                    tbk_errorMessage.Text = "Veuillez renseigner un nom de Matiere d'au moins deux caractères svp";
                }
               
            }
            catch (Matiere.MatiereException error)
            {
                tbk_errorMessage.Text = error.Message;
            }
            catch (Exception)
            {
                tbk_errorMessage.Text = "Désolé, une erreur est survenu lors de l'ajout de la matière, veuillez vérifier les informations renseignées et recommencer.";
            }
        }
    }
}
