using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtelierConges.Metier
{
    public class Planning
    {
        // Liste c# = tableau numéraire en PHP
        private List<DemandeConge> listeConge = new List<DemandeConge>;
        // Dictionary C# = tableau associatif en PHP
        private Dictionary<string, DemandeConge> demandeConge = new Dictionary<string, DemandeConge>(); 

        // private DemandeConge[] listeConges = new DemandeConge[10]; /* Limité par une quantité d'entrées dans un tableau (ici 10) */
    
        public void Ajouter(DemandeConge conge)
        {
            listeConge.Add(conge);
        }
    }

}
