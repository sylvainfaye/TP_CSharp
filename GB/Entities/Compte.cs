using GestionBanque.Entities;
using System;

namespace GB.Entities
{
    internal abstract class Compte
    {
        private static int _idCounter = 1;

        public int Id { get; }
        public string NumeroCompte { get; protected set; }
        public float Solde { get;  set; }
        public Client Client { get; private set; } 
        protected Compte(string numeroCompte, float solde)
        {
            Id = _idCounter++;
            NumeroCompte = numeroCompte;
            Solde = solde;
        }

        public void AssocierClient(Client client)
        {
            Client = client;
            client.AjouterCompte(this);
            Console.WriteLine($"Compte {NumeroCompte} associé au client {client.getNom()} {client.getPrenom()}.");
        }

        public abstract void AfficherDetails();
    }




}
