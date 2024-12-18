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
    internal interface IAgence
    {

        void saisieClient(List<IAgenceImpl> agences);
        void AjoutClient(Client client);
        bool RechercherAjoutClient(Client client);
        Client RechercherClient(List<IAgenceImpl> agences);
        void ModifierClient(List<IAgenceImpl> agences);
        void SupprimerClient(List<IAgenceImpl> agences);
        void AfficherClientsParAgence(List<IAgenceImpl> agences);


    }
}
