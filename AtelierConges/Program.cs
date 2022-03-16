using AtelierConges.Metier;

var planning = new Planning();
var rogerIbernatus = new User()
{
    FirstName = "Roger",
    LastName = "Ibernatus",
    Email = "roger@ibernatus.com",

};

var yakupS = new User()
{
    FirstName = "Yakup",
    LastName = "Senel",
    Email = "yakup@senel.com",
    Manager = rogerIbernatus
};

// Nouvelle demande de congé
var dem1 = new DemandeConge(rogerIbernatus);

// Pose la demande avec (une instance de la date, et une instance de la durée = new TimeSpan(7, 0, 0))
dem1.Poser(new DateTime(2022, 7, 1), TimeSpan.FromDays(7));

planning.Ajouter(dem1);

string? choix;

do
{
    Console.WriteLine("1) Lister les congés");
    Console.WriteLine("2) Poser des congés");
    Console.WriteLine("3) Valider des congés");
    Console.WriteLine("4) Quitter");
    Console.Write("Votre choix : ");
    choix = Console.ReadLine();

    switch (choix)
    {
        case "2":
            {
                // Saisir la date
                Console.WriteLine("Quand ?");
                string? quand = Console.ReadLine();
                DateTime debut = DateTime.Parse(quand);
                Console.WriteLine($"Quand: {debut:D}");

                // Saisir la durée des congés
                Console.WriteLine("Durée des congés ?");
                string? combienDeTemps = Console.ReadLine() ;
                double duree = double.Parse(combienDeTemps);
                Console.WriteLine($"Durée: {duree}");

                // Créer une demande de congés
                DemandeConge nouvelleDemande = new DemandeConge(rogerIbernatus);
                nouvelleDemande.Poser(debut, TimeSpan.FromDays(duree));
                nouvelleDemande.Envoyer();
                Console.WriteLine($"Etat de votre demande: {nouvelleDemande.Etat}");

                // Ajouter au planning
                planning.Ajouter(nouvelleDemande);

                break;
            }

        case "1":
            // Foreach sur les demandes du planning
            Console.WriteLine("Liste des Demandes de congés:");
            foreach(var conge in planning.Demandes)
            {
                Console.WriteLine($"Du: {conge.Debut:D} au {conge.Fin:D}, durée: {conge.Duree.TotalDays}j, Etat: {conge.Etat}");
            }
            break;

        case "3":
            // Afficher les demandes avec un numéro devant (for)
            // ReadLine pour le choix de la demande de congés à valider
            // ReadLine pour savoir si la demande est acceptée ou non (O/N)
            // Appeler la méthode "Approuver"
            break;

    }
}

while (choix != "4");
