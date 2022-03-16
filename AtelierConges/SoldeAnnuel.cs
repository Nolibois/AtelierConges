using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtelierConges.Metier
{

    public class SoldeAnnuel
    {
        private TimeSpan soldeTotal = TimeSpan.Zero;
        private TimeSpan restant = TimeSpan.Zero;
        private int annee = DateTime.Today.Year;
        private DateTime? utilisableJusquA = null;

        public SoldeAnnuel(int annee)
        {
            this.annee = annee;
        }

        public SoldeAnnuel(int annee, TimeSpan soldeTotal)
        {
            this.annee = annee;
            this.soldeTotal = soldeTotal;
        }

        public void AugmenterSolde(double nbJoursSupp)
        {

        }
        
        public void Imputer(DemandeConge conge)
        {
            if(conge.Etat != EtatDemande.Approuve)
            {
                throw new InvalidOperationException("La demande a été refusé");
            }

            // TODO: coder le reste
        }


    }
}
