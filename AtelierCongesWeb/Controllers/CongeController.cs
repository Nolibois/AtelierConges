using Microsoft.AspNetCore.Mvc;
using AtelierConges.Metier;

namespace AtelierCongesWeb.Controllers
{
    public class CongeController : Controller
    {
        private static Planning planning;

        static CongeController()
        {
            planning = new Planning();
            var rogerIbernatus = new User()
            {
                FirstName = "Roger",
                LastName = "Ibernatus",
                Email = "roger@ibernatus.com"
            };

            var batman = new User()
            {
                FirstName = "Bruce",
                LastName = "Wayne",
                Email = "bruce@wayne.com",
                Manager = rogerIbernatus
            };

            var yakupS = new User()
            {
                FirstName = "Yakup",
                LastName = "Senel",
                Email = "yakup@senel.com",
                Manager = rogerIbernatus
            };

            var dem1 = new DemandeConge(1, rogerIbernatus);
            dem1.Poser(new DateTime(2022, 7, 1), TimeSpan.FromDays(7));
            planning.Ajouter(dem1);

            var dem2 = new DemandeConge(2, yakupS);
            dem2.Poser(new DateTime(2022, 11, 25), TimeSpan.FromDays(7.4));
            dem2.Envoyer();
            planning.Ajouter(dem2);

            var dem3 = new DemandeConge(3, batman);
            dem3.Poser(new DateTime(2022, 3, 25), TimeSpan.FromDays(14));
            dem3.Approuver(true, "Demande validée");
            planning.Ajouter(dem3);

        }

        public IActionResult Index()
        {
            return View(planning);
        }

        public IActionResult Accepter(int id)
        {
            return checkAction(true, id);
        }

        public IActionResult Rejeter(int id)
        {
            return checkAction(false, id);

        }

        private IActionResult checkAction(bool action,int id)
        {
            var conge = planning.Demandes.Find(c => c.Id == id);
            var choice = !action ? "" : "Demande refusée";

            if (conge == null)
            {
                return NotFound();
            }
            else
            {
                conge.Approuver(action,choice);
                return RedirectToAction("Index");
            }
        }
    }
}
