using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
        [MaxLength(50), Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public User? Manager { get; set; } = null;
        
    }
}
