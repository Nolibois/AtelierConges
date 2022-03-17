using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtelierConges.Metier
{
    public class DemandeConge
    {
        private EtatDemande etat = EtatDemande.Brouillon;
        private DateTime debut = DateTime.Today;
        private TimeSpan duree = TimeSpan.FromDays(1) ;
        private string? commentaire = null;
        private User employe;

        public DemandeConge(int id, User employe)
        {
            this.Id = id;
            this.employe = employe;
        }

        public int Id { get; private set; }
        
        public EtatDemande Etat => etat;

        private void VerifierEtatBrouillon()
        {
            if (etat != EtatDemande.Brouillon)
            {
                throw new InvalidOperationException("La demande est déjà envoyée et ne peut être modifiée");
            }
        }

        public DateTime Debut
        {
            get => debut; 
            set {
                VerifierEtatBrouillon();
                debut = value;
            }
        }

        public DateTime Fin
        {
            get => debut + duree;
            set
            {
                Duree = value - debut;
            }
        }

        public TimeSpan Duree {
            get => duree; 
            set
            { 
                if(value <= TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException("La durée doit être strictement positive");
                }
                duree = value;
            }
        }

        public void Poser(DateTime dateDebut, TimeSpan duree)
        {
            Debut = dateDebut;
            Duree = duree;
        }

        public void Envoyer()
        {
            etat = EtatDemande.EnAttente;
        }

        /// <summary>
        /// Permet d'approuver ou non une demande précédemment envoyée
        /// </summary>
        /// <param name="ok">true pour approuver, false pour refuser la demande</param>
        /// <param name="commentaire">Commentaire motivant le refus</param>
        /// <exception cref="InvalidOperationException">Si la demande n'est pas en attente</exception>
        public void Approuver(bool ok, string commentaire)
        {
            if (ok)
            {
                etat = EtatDemande.Approuve;
                this.commentaire = "Votre demande de congés a été acceptée.";
            }
            else
            {
                etat = EtatDemande.Refuse;
                this.commentaire = "Votre demande de congés a été refusé.";
            }
        }
    }


}
