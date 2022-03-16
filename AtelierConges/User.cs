using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtelierConges.Metier
{
    /// <summary>
    /// Représente un collaborateur de l'entreprise
    /// </summary>
    /// <example>
    /// var c = new Collaborateur(){ firstName = "Dupont", lastName = "Pierre", email = "pierre.dupont@example"};
    /// var d = new Collaborateur();
    /// d.firstName = "Dupont";
    /// d.lastName = "Pierre";
    /// d.email = "pierre.dupont@example";
    /// </example>
    public class User
    {
        private string firstName { get; set; };
        private string lastName { get; set; };
        private string email { get; set; };
        private User? manager { get; set; } = null;

    }
}
