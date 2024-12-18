using System;
using System.Collections.Generic;
using GB.Implementation;

namespace GestionBanque.Entities
{
    internal class Agence
    {
        protected int id;
        protected string code;
        protected string libelle;
        protected static int nbAgence = 0;
        protected List<Client> clients { get; set; }

        public Agence()
        {
            nbAgence++;
            id = nbAgence;
            clients = new List<Client>();
        }
        public List<Client> GetClients()
        {
            return clients;
        }

        public string GetCode()
        {
            return code;
        }
        public Agence(string code) : this()
        {
            this.code = code;
        }

        public int Id { get { return id; } set { id = value; } }
        public string getCode() { return code; }
        public void setCode(string code) { this.code = code; }

        public string GenerationLibelle()
        {
            if (code != null && code.Length >= 3)
            {
                return id + code.Substring(0, 3);
            }
            else
            {
                return id + "XXX";
            }
        }

        

        public void affichageAgence()
        {
            libelle = GenerationLibelle();
            Console.WriteLine(" ");
            Console.WriteLine($"Affichage de l'agence :: Id : {id} | Code : {code} | Libellé : {libelle}");
            Console.WriteLine(" ");
        }
        public void AfficherClientsParAgence()
        {
            Console.WriteLine($"Liste des clients pour l'agence {code} :");
            if (clients.Count == 0)
            {
                Console.WriteLine("Aucun client trouvé.");
                return;
            }

            for (int i = 0; i < clients.Count; i++)
            {
                var client = clients[i];
                Console.WriteLine($"{i + 1}. Id: {client.Id} | Nom: {client.getNom()} | Prénom: {client.getPrenom()} | Téléphone: {client.getTel()}");
            }
        }
   



    }
}
