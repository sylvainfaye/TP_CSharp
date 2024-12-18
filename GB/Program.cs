using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GB.Entities;
using GB.Implementation;
using GestionBanque.Entities;

namespace GB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*D'après ma compréhension du TP nous de devons pas avoir un CRUD agence pour creer une agence , supprimé 
            une agence ou la modifier donc pour c'est pour cela j'ai crée une liste d'agence pour après l'utilisation va 
            choisir une des agences disponibles d'où la liste
            */
            List<IAgenceImpl> agences = new List<IAgenceImpl>
            {
                    new IAgenceImpl("BCAO"),
                    new IAgenceImpl("BOA"),
                    new IAgenceImpl("CBAO"),
                    new IAgenceImpl("ECOBANK")
             };
            IClientImpl clientImpl = new IClientImpl();
            /* Ici j'ai effectué un casting parce que pour ajouter un compte je devais recuperer la liste des agences avec 
             leurs clients et lors de l'appelle de cette fonction j'avais des données de type IAgenceImpl et non agences
             */
            List<Agence> agencesBase = agences.Cast<Agence>().ToList();
    

            int choix;
            Console.WriteLine("Bienvenue dans le système de gestion de Banque !");


            do
            {
                Console.WriteLine("-------- MENU ---------");
                Console.WriteLine("1. CRUD gestion clients dans l'agence ");
                Console.WriteLine("2. CRUD gestion comptes des clients ");
                Console.WriteLine("3. Quitter ");
                Console.WriteLine("-----------------------");
                Console.WriteLine("Veuillez saisir votre choix : ");
                choix = int.Parse(Console.ReadLine());


                while (choix < 1 || choix > 3)
                {
                    Console.WriteLine("Choix invalide, veuillez saisir un nombre entre 1 et 3 !");
                }

                switch (choix)
                {
                    case 1:
                        int choixC;
                        do
                        {

                            Console.WriteLine("-------- MENU Client---------");
                            Console.WriteLine("1. Ajouter un client ");
                            Console.WriteLine("2. Modifier un client ");
                            Console.WriteLine("3. Supprimer un  client ");
                            Console.WriteLine("4. Rechercher un  client ");
                            Console.WriteLine("5. Afficher tous les  clients ");
                            Console.WriteLine("6. Quitter ");
                            Console.WriteLine("-----------------------");
                            Console.WriteLine("Veuillez saisir votre choix : ");
                            choixC = int.Parse(Console.ReadLine());
                            while (choixC < 1 || choixC > 6)
                            {
                                Console.WriteLine("Choix invalide, veuillez saisir un nombre entre 1 et 6!");
                            }
                            switch (choixC)
                            {
                                case 1:
                                    /*Je pouvais pas recuperer les données de type IAgenceImpl directement et j'ai trouvé que 
                                     je pouvais indexé la liste agence pour se positionner a une agence par defaut mais 
                                     l'agence ne sera pas pris au compte lors de la creation du client un choix lui sera
                                     proposé lors de la saisit du client */
                                    IAgenceImpl agence = agences[0];
                                    agence.saisieClient(agences);
   
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    IAgenceImpl agen = agences[0];
                                    agen.ModifierClient(agences);
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    IAgenceImpl agenc = agences[0];
                                    agenc.SupprimerClient(agences);
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    IAgenceImpl ag = agences[0];
                                    ag.RechercherClient(agences);

                                    Console.ReadKey();
                                    break;
                                case 5:
                                    IAgenceImpl a = agences[0];
                                    a.AfficherClientsParAgence(agences);
                                    Console.ReadKey();
                                    break;
                            }
                            Console.Clear();
                        } while (choixC != 6);

                        break;

                    case 2:
                        int choixCo;
                        do
                        {

                            Console.WriteLine("-------- MENU Compte---------");
                            Console.WriteLine("1. Ajouter un compte ");
                            Console.WriteLine("2. Modifier un compte ");
                            Console.WriteLine("3. Supprimer un  compte ");
                            Console.WriteLine("4. Rechercher un  compte ");
                            Console.WriteLine("5. Afficher tous les  comptes ");
                            Console.WriteLine("6. Quitter ");
                            Console.WriteLine("-----------------------");
                            Console.WriteLine("Veuillez saisir votre choix : ");
                            choixCo = int.Parse(Console.ReadLine());
                            while (choixCo < 1 || choixCo > 6)
                            {
                                Console.WriteLine("Choix invalide, veuillez saisir un nombre entre 1 et 6 !");
                            }
                            switch (choixCo)
                            {
                                case 1:
                                    // Convertion de agencesBase grace au casting de données
                                    clientImpl.AjouterCompte(agencesBase);
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    clientImpl.ModifierCompte(agences);
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    clientImpl.SupprimerCompte(agences);
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    clientImpl.RechercherCompte(agences);
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    clientImpl.AfficherComptesDeToutesLesAgences(agences);
                                    Console.ReadKey();
                                    break;
                            }
                            Console.Clear();

                        } while (choixCo != 6);

                        break;
                    case 3:

                        Console.WriteLine("Vous avez quitté le système ! A bientot ");
                        break;
                }
                Console.Clear();
            } while (choix != 3);
        }

    }
}

