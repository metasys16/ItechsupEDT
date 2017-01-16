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
using System.Collections.ObjectModel;

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Interaction logic for AjoutPromotion.xaml
    /// </summary>
    public partial class AjoutPromotion : UserControl
    {
        public AjoutPromotion()
        {
            InitializeComponent();
            this.DataContext = this;

            this.cb_lstFormations.ItemsSource = FormationDAO.ListerFormation();
            
        }

        private void btn_ajoutPromotion_Click(object sender, RoutedEventArgs e)
        {
            
            String nom = tb_nomPromotion.Text;
            DateTime dateDebutPromotion = dp_dateDebutPromotion.DisplayDate;
            DateTime dateFinPromotion = dp_dateFinPromotion.DisplayDate;
            //this.DataContext = cb_lstFormations.SelectedItem;
            Formation selectedFormation = (Formation)cb_lstFormations.SelectedItem;

            int id_formation = selectedFormation.Id;

            PromotionDAO.CreerPromotion(nom, dateDebutPromotion, dateFinPromotion, id_formation);
        }
    }
}
