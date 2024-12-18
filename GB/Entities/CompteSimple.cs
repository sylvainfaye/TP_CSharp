using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Entities
{
    internal class CompteSimple : Compte
    {
        public float TauxDecouvert { get; set; }

        public CompteSimple(string numeroCompte, float solde, float tauxDecouvert) : base(numeroCompte, solde)
        {
            this.TauxDecouvert = tauxDecouvert;
        }

        public override void AfficherDetails()
        {
            Console.WriteLine($"Compte Simple :: ID: {Id}, Numéro: {NumeroCompte}, Solde: {Solde}, Taux Découvert: {TauxDecouvert}");
        }
    }
}
