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
using System.Data;
using ItechSupEDT.Outils;

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Interaction logic for AjoutFormation.xaml
    /// </summary>
    public partial class AjoutFormation : UserControl
    {
        public AjoutFormation()
        {
            InitializeComponent();
        }

        private void btn_ajoutFormation_Click(object sender, RoutedEventArgs e)
        {
            String nom = tb_nomFormation.Text;
            String nbHeures = tb_dureeFormation.Text;

            try
            {
                float duree = float.Parse(nbHeures);
                // validation
                if (tb_nomFormation.Text.Count() > 1)
                {
                    FormationDAO.CreerFormation(nom, duree);
                    this.tbk_retourMessage.Text = "Formation ajoutée";
                    // Effacer les saisies pour en saisir d'autres à la suite
                    tb_nomFormation.Clear();
                    tb_dureeFormation.Clear();
                }
                else
                {
                    tbk_errorMessage.Text = "Veuillez renseigner un nom de Formation d'au moins deux caractères svp";
                }
            }
            catch (Formation.FormationException error)
            {
                tbk_errorMessage.Text = error.Message;       
            }
            catch(Exception)
            {
                tbk_errorMessage.Text = "Désolé, une erreur est survenu lors de l'ajout de la formation, veuillez vérifier les informations renseignées et recommencer.";
            }

        }
    }
}
