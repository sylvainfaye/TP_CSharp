using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Entities
{
    internal class CompteEpargne : Compte
    {
        public int duree { get; set; }

        public CompteEpargne(string numeroCompte, float solde, int duree) : base(numeroCompte, solde)
        {
            this.duree = duree;
        }

        public override void AfficherDetails()
        {
            Console.WriteLine($"Compte Epargne :: ID: {Id}, Numéro: {NumeroCompte}, Solde: {Solde}, Durée : {duree} mois");
        }
    }
}
