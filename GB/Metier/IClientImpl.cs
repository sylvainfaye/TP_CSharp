using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GB.Entities;
using GB.Metier;
using GestionBanque.Entities;

namespace GB.Implementation
{
    internal class IClientImpl:Client,IClient
    {
      
        public Compte SaisirCompte()
        {
            Console.WriteLine("Création d'un nouveau compte :");

           
            Console.WriteLine("Entrez le numéro de compte :");
            string numeroCompte = Console.ReadLine();

            Console.WriteLine("Entrez le solde (valeur réel) :");
            float solde = float.Parse(Console.ReadLine());

      
            Console.WriteLine("Sélectionnez le type de compte à créer :");
            Console.WriteLine("1. Compte Simple");
            Console.WriteLine("2. Compte Epargne");
            int choixType = int.Parse(Console.ReadLine());

            Compte nouveauCompte = null;

            switch (choixType)
            {
                case 1:
                    Console.WriteLine("Entrez le taux de découvert  (valeur réel) :");
                    float tauxDecouvert = float.Parse(Console.ReadLine());
                    nouveauCompte = new CompteSimple(numeroCompte, solde, tauxDecouvert);
                    break;

                case 2:
                    Console.WriteLine("Entrez la durée en mois :");
                    int duree = int.Parse(Console.ReadLine());
                    nouveauCompte = new CompteEpargne(numeroCompte, solde, duree);
                    break;

                default:
                    Console.WriteLine("Type de compte invalide.");
                    break;
            }

            return nouveauCompte;
        }
        public void AjouterCompte(List<Agence> agences)
        {
            Console.WriteLine("Sélectionnez l'agence où se trouve le client :");
            AfficherAgences(agences);
            int choixAgence = int.Parse(Console.ReadLine());
            Agence agenceChoisie = agences[choixAgence - 1];

            Console.WriteLine("Sélectionnez le client propriétaire du compte  :");
            agenceChoisie.AfficherClientsParAgence();
            int choixClient = int.Parse(Console.ReadLine());
            Client client = agenceChoisie.GetClients()[choixClient - 1];

            // Vérification si le client dispose pas déja de compte parce qu'il ne peut pas avoir plus de 2 comptes(simple et epargne )
            if (RechercherCompte(client, typeof(CompteSimple)) != null &&
                RechercherCompte(client, typeof(CompteEpargne)) != null)
            {
                Console.WriteLine("Le client possède déjà un compte simple et un compte épargne. Impossible d'ajouter un nouveau compte.");
                return;
            }

            Compte nouveauCompte = SaisirCompte();
            if (nouveauCompte == null)
            {
                Console.WriteLine("Création du compte annulée.");
                return;
            }

            // Vérification si le compte du même type existe déjà 
            if (nouveauCompte is CompteSimple && RechercherCompte(client, typeof(CompteSimple)) != null)
            {
                Console.WriteLine("Le client possède déjà un compte simple.");
                return;
            }

            if (nouveauCompte is CompteEpargne && RechercherCompte(client, typeof(CompteEpargne)) != null)
            {
                Console.WriteLine("Le client possède déjà un compte épargne.");
                return;
            }

          
            client.AjouterCompte(nouveauCompte);
            Console.WriteLine("Compte créé avec succès et associé au client.");
        }

        // Avant d'ajouter il faut d'abord verifier s'il y a pas de compte pour ce client
        public Compte RechercherCompte(Client client, Type typeCompte)
        {
            foreach (var compte in client.GetCompte())
            {
                if (compte.GetType() == typeCompte)
                {
                    return compte;
                }
            }
            return null;
        }

 
        private void AfficherAgences(List<Agence> agences)
        {
            Console.WriteLine(" ");
            Console.WriteLine("1-BCAO");
            Console.WriteLine("2-BOA");
            Console.WriteLine("3-CBAO");
            Console.WriteLine("4-ECOBANK");
        }
        public void AfficherComptesDeToutesLesAgences(List<IAgenceImpl> agences)
        {
           
            Console.WriteLine("Affichage des comptes de tous les clients de toutes les agences :");
            int i = 0;
            foreach (var agence in agences)
            {
                if (i == 0) { Console.WriteLine("Agence:BCAO ");Console.WriteLine("--------------"); } 
                else if (i == 1) { Console.WriteLine("Agence:BOA "); Console.WriteLine("--------------"); }
                else if (i == 2) { Console.WriteLine("Agence:CBAO "); Console.WriteLine("--------------"); }
                else if (i == 3) { Console.WriteLine("Agence:ECOBANK "); Console.WriteLine("--------------"); }


                var clients = agence.GetClients(); 

                if (clients == null || clients.Count == 0)
                {
                    Console.WriteLine("Aucun client dans cette agence.");
                    continue;
                }

                foreach (var client in clients)
                {
                    Console.WriteLine($"Client: {client.getNom()} {client.getPrenom()}");

                    var comptes = client.GetCompte(); 
                    if (comptes == null || comptes.Count == 0)
                    {
                        Console.WriteLine("  Aucun compte associé à ce client.");
                    }
                    else
                    {
                        foreach (var compte in comptes)
                        {
                            compte.AfficherDetails(); 
                        }
                    }
                    Console.WriteLine(); 
                }
                Console.WriteLine();
                Console.WriteLine(); 
                i++;
            }
        }

    
        public Compte RechercherCompte(List<IAgenceImpl> agences)
        {
            Console.WriteLine("Sélectionnez l'agence où effectuer la recherche :");
            Console.WriteLine(" ");
            Console.WriteLine("1-BCAO");
            Console.WriteLine("2-BOA");
            Console.WriteLine("3-CBAO");
            Console.WriteLine("4-ECOBANK");
            int choixAgence = int.Parse(Console.ReadLine());

            IAgenceImpl agenceChoisie = agences[choixAgence - 1];

            Console.WriteLine("Sélectionnez le client associé au compte :");
            agenceChoisie.AfficherClientsParAgence();
            int choixClient = int.Parse(Console.ReadLine());

            Client clientChoisi = agenceChoisie.GetClients()[choixClient - 1];

            Console.WriteLine("Entrez le numéro du compte à rechercher :");
            string numeroCompte = Console.ReadLine();

            var compte = clientChoisi.GetCompte().FirstOrDefault(c => c.NumeroCompte == numeroCompte);

            if (compte != null)
            {
                Console.WriteLine($"Compte trouvé : {compte.NumeroCompte}");
            }
            else
            {
                Console.WriteLine("Aucun compte trouvé avec ce numéro.");
            }

            return compte;
        }

       
        public void ModifierCompte(List<IAgenceImpl> agences)
        {
            Console.WriteLine("Modification d'un compte :");
            var compte = RechercherCompte(agences);

            if (compte == null) return;

            Console.WriteLine($"Modification du compte {compte.NumeroCompte}");
            Console.WriteLine($"1. Modifier le solde actuel (actuel : {compte.Solde})");

            if (compte is CompteSimple)
                Console.WriteLine($"2. Modifier le taux découvert  (actuel : {(compte as CompteSimple).TauxDecouvert})");
            else if (compte is CompteEpargne)
                Console.WriteLine($"2. Modifier la durée (actuelle : {(compte as CompteEpargne).duree})");

            Console.WriteLine("Choisissez une option :");
            int choix = int.Parse(Console.ReadLine());

            switch (choix)
            {
                case 1:
                    Console.WriteLine("Entrez le nouveau solde :");
                    compte.Solde = float.Parse(Console.ReadLine());
                    Console.WriteLine("Le solde a été modifié.");
                    break;

                case 2:
                    if (compte is CompteSimple)
                    {
                        Console.WriteLine("Entrez le nouveau taux découvert  :");
                        (compte as CompteSimple).TauxDecouvert = float.Parse(Console.ReadLine());
                    }
                    else if (compte is CompteEpargne)
                    {
                        Console.WriteLine("Entrez la nouvelle durée :");
                        (compte as CompteEpargne).duree = int.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("La modification a été appliquée.");
                    break;

                default:
                    Console.WriteLine("Option invalide.");
                    break;
            }
        }

       
        public void SupprimerCompte(List<IAgenceImpl> agences)
        {
            Console.WriteLine("Suppression d'un compte :");
            var compte = RechercherCompte(agences);

            if (compte == null) return;

            Console.WriteLine($"Confirmez-vous la suppression du compte {compte.NumeroCompte} ? (O/N)");
            string confirmation = Console.ReadLine();

            if (confirmation.ToUpper() == "O")
            {
                foreach (var agence in agences)
                {
                    foreach (var client in agence.GetClients())
                    {
                        if (client.GetCompte().Contains(compte))
                        {
                            client.GetCompte().Remove(compte);
                            Console.WriteLine($"Le compte {compte.NumeroCompte} a été supprimé.");
                            return;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Suppression annulée.");
            }
        }



        public void AssocierCompteAClient(Client client, Compte compte)
        {
            compte.AssocierClient(client);
            Console.WriteLine($"Compte {compte.NumeroCompte} associé au client {client.getNom()} {client.getPrenom()}.");
        }
      

    }
}
