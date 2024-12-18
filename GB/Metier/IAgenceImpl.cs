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
    internal class IAgenceImpl:Agence,IAgence
    {
    
        public string Code { get; private set; }
       

        public IAgenceImpl(string code)
        {
            Code = code;
        }
        

        public  void saisieClient(List<IAgenceImpl> agences)
        {

            Console.WriteLine("Entrer le nom du client : ");
            string nom = Console.ReadLine();
            Console.WriteLine("Entrer le prénom du client : ");
            string prenom = Console.ReadLine();
            Console.WriteLine("Entrer le téléphone du client : ");
            int tel = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Client nouveauClient = new Client(nom, prenom, tel);

        
            Console.WriteLine("Choisissez une agence pour ce client : ");
            for (int i = 0; i < agences.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {agences[i].Code}");
            }

          
            int choixAgence;
            do
            {
                Console.WriteLine("Entrez le numéro de l'agence du client : ");
                choixAgence = int.Parse(Console.ReadLine());

                if (choixAgence < 1 || choixAgence > agences.Count)
                {
                    Console.WriteLine("Numéro invalide, veuillez choisir une agence existante.");
                }
            } while (choixAgence < 1 || choixAgence > agences.Count);

           
            IAgenceImpl agenceChoisie = agences[choixAgence - 1];
            nouveauClient.setAgence(agenceChoisie);
            agenceChoisie.AjoutClient(nouveauClient);
        }



        public void AjoutClient(Client client)
        {
            if (client != null)
            {

                if (RechercherAjoutClient(client))
                {
                    Console.WriteLine("Le client existe déjà dans l'agence.");
                }
                else
                {
                    clients.Add(client);
                    client.setAgence(this);
                    Console.WriteLine($"Client ajouté à l'agence {this.code} : {client.getNom()} {client.getPrenom()}");
                    Console.WriteLine("--------------------------");
                }
            }
        }
        public bool RechercherAjoutClient(Client client)
        {

            return clients.Exists(c =>
                c.getNom().Equals(client.getNom(), StringComparison.OrdinalIgnoreCase) &&
                c.getPrenom().Equals(client.getPrenom(), StringComparison.OrdinalIgnoreCase) &&
                c.getTel() == client.getTel());
        }
        public Client RechercherClient(List<IAgenceImpl> agences)
        {
   
            Console.WriteLine("Liste des agences disponibles :");
            Console.WriteLine(" ");
            Console.WriteLine("1-BCAO");
            Console.WriteLine("2-BOA");
            Console.WriteLine("3-CBAO");
            Console.WriteLine("4-ECOBANK");

            Console.WriteLine("Choisir une agence pour rechercher un client (saisir le numéro correspondant) :");
            int choixAgence = int.Parse(Console.ReadLine());

   
            while (choixAgence < 1 || choixAgence > agences.Count)
            {
                Console.WriteLine("Choix invalide. Veuillez saisir un numéro correct :");
                choixAgence = int.Parse(Console.ReadLine());
            }

         
            IAgenceImpl agenceChoisie = agences[choixAgence - 1];

       
            Console.WriteLine("Entrer le nom du client :");
            string nomRecherche = Console.ReadLine();

            Console.WriteLine("Entrer le prénom du client :");
            string prenomRecherche = Console.ReadLine();

            Console.WriteLine("Entrer le téléphone du client :");
            int telRecherche = int.Parse(Console.ReadLine());

           
            Client client = agenceChoisie.GetClients().Find(c =>
                c.getNom().Equals(nomRecherche, StringComparison.OrdinalIgnoreCase) &&
                c.getPrenom().Equals(prenomRecherche, StringComparison.OrdinalIgnoreCase) &&
                c.getTel() == telRecherche
            );

           
            if (client != null)
            {
                string ag;
                if (agenceChoisie == agences[0]){ ag = "BCAO";}
                else if (agenceChoisie == agences[1]) { ag = "BOA";}
                else if (agenceChoisie == agences[2]){ag = "CBAO"; }
                else{ ag = "ECOBANK";}

                Console.WriteLine($"Client trouvé : {client.getNom()} {client.getPrenom()}, Téléphone : {client.getTel()}, Agence : {ag}");
            }
            else
            {
                Console.WriteLine("Client introuvable dans cette agence.");
            }

            return client;
        }

        public void ModifierClient(List<IAgenceImpl> agences)
        {
            Console.WriteLine("Modification d'un client existant :");

            Client client = RechercherClient(agences);

            if (client != null)
            {
               
                Console.WriteLine("Entrer le nouveau nom du client (laisser vide pour ne pas modifier) :");
                string nouveauNom = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nouveauNom))
                {
                    client.setNom(nouveauNom);
                }

            
                Console.WriteLine("Entrer le nouveau prénom du client (laisser vide pour ne pas modifier) :");
                string nouveauPrenom = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nouveauPrenom))
                {
                    client.setPrenom(nouveauPrenom);
                }

              
                Console.WriteLine("Entrer le nouveau téléphone du client (laisser vide pour ne pas modifier) :");
                string telInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(telInput) && int.TryParse(telInput, out int nouveauTel))
                {
                    client.setTel(nouveauTel);
                }

                Console.WriteLine("Client modifié avec succès.");
            }
            else
            {
                Console.WriteLine("Impossible de modifier. Client introuvable.");
            }
        }

        public void SupprimerClient(List<IAgenceImpl> agences)
        {
            Console.WriteLine("Suppression d'un client existant :");

          
            Client client = RechercherClient(agences);

            if (client != null)
            {
                Console.WriteLine($"Voulez-vous vraiment supprimer le client {client.getNom()} {client.getPrenom()} ? (oui/non)");
                string confirmation = Console.ReadLine();

                if (confirmation != null && confirmation.ToLower() == "oui")
                {
                    client.getAgence().GetClients().Remove(client);
                    Console.WriteLine("Client supprimé avec succès.");
                }
                else
                {
                    Console.WriteLine("Suppression annulée.");
                }
            }
            else
            {
                Console.WriteLine("Client introuvable.");
            }
        }



        public void AfficherClientsParAgence(List<IAgenceImpl> agences)
        {
            Console.WriteLine("Liste des agences disponibles :");
            Console.WriteLine();
            Console.WriteLine("1-BCAO");
            Console.WriteLine("2-BOA");
            Console.WriteLine("3-CBAO");
            Console.WriteLine("4-ECOBANK");




            Console.WriteLine("Choisir une agence pour afficher ses clients (saisir le numéro correspondant) :");
            int choixAgence = int.Parse(Console.ReadLine());

            while (choixAgence < 1 || choixAgence > agences.Count)
            {
                Console.WriteLine("Choix invalide. Veuillez saisir un numéro correct :");
                choixAgence = int.Parse(Console.ReadLine());
            }

            IAgenceImpl agenceChoisie = agences[choixAgence - 1];
            if (agenceChoisie == agences[0])
            {
                Console.WriteLine($"Liste des clients de l'agence BCAO :");
                Console.WriteLine("");

            }else if(agenceChoisie == agences[1])
            {
                Console.WriteLine($"Liste des clients de l'agence BOA :");
                Console.WriteLine("");
            }
            else if(agenceChoisie == agences[2])
            {
                Console.WriteLine($"Liste des clients de l'agence CBAO :");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine($"Liste des clients de l'agence ECOBANK :");
                Console.WriteLine("");
            }


            if (agenceChoisie.GetClients().Count == 0) 
            {
                Console.WriteLine("Aucun client trouvé pour cette agence.");
            }
            else
            {
                foreach (Client client in agenceChoisie.GetClients())
                {
                    Console.WriteLine("");
                    client.affichageClient();
                }
            }
        }

       

    }
}
