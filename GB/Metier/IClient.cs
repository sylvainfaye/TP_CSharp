using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GB.Entities;
using GB.Implementation;
using GestionBanque.Entities;

namespace GB.Metier
{
    internal interface IClient
    {
        Compte SaisirCompte();
        void AjouterCompte(List<Agence> agences);
        Compte RechercherCompte(Client client, Type typeCompte);
        void AfficherComptes();
        void AfficherComptesDeToutesLesAgences(List<IAgenceImpl> agences);
        Compte RechercherCompte(List<IAgenceImpl> agences);
        void ModifierCompte(List<IAgenceImpl> agences);
        void SupprimerCompte(List<IAgenceImpl> agences);

    }
}
