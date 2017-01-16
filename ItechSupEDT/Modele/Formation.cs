using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Modele
{
    public class Formation
    {
        private String nom;
        private float duree;
        private List<Promotion> lstPromotions;
        private List<Matiere> lstMatiere;
        private int id;

        public int Id
        {
            get { return id; }
        }

        public String Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public float Duree
        {
            get { return this.duree; }
            set { this.duree = value; }
        }
        public List<Promotion> LstPromotions
        {
            get { return this.lstPromotions; }
            set { this.lstPromotions = value; }
        }
        public List<Matiere> LstMatiere
        {
            get { return this.lstMatiere; }
            set { this.lstMatiere = value; }
        }
        public Formation(int id, String nom, float duree)
        {
            this.id = id;
            this.Nom = nom;
            this.Duree = duree;
        }

        public Formation(String _nom, float _nbHeuresTotal, List<Matiere> _lstMatiere)
        {
            this.Nom = _nom;
            this.Duree = _nbHeuresTotal;
            this.LstMatiere = _lstMatiere;
            this.LstPromotions = new List<Promotion>();
        }
        public class FormationException : Exception
        {
            public FormationException(string message) : base(message)
            {
            }
        }
    }
}
