using System;
using System.Collections.Generic;
using GB.Entities;
using GB.Metier;

namespace GestionBanque.Entities
{
    internal class Client
    {
        protected int id;
        protected string nom;
        protected string prenom;
        protected int tel;
        protected static int nbClient = 0;
        protected Agence agence;
        private List<Compte> comptes; 

        public List<Compte> GetCompte()
        {
            return comptes;
        }

        public List<Compte> GetComptes()  
        {
            return comptes;
        }
        public Client()
        {
            nbClient++;
            id = nbClient;
            comptes = new List<Compte>();
        }

        public Client(string nom, string prenom, int tel) : this()
        {
            this.nom = nom;
            this.prenom = prenom;
            this.tel = tel;
        }

        public int Id { get { return id; } set { id = value; } }
        public string getNom() { return nom; }
        public void setNom(string nom) { this.nom = nom; }
        public string getPrenom() { return prenom; }
        public void setPrenom(string prenom) { this.prenom = prenom; }
        public int getTel() { return tel; }
        public void setTel(int tel) { this.tel = tel; }

        public Agence getAgence() { return this.agence; }
        public void setAgence(Agence agence)
        {
            if (agence != null)
            {
                this.agence = agence;
               
            }
            else
            {
                Console.WriteLine("Erreur : L'agence fournie est nulle.");
            }
        }

        public void AjouterCompte(Compte compte)
        {
            comptes.Add(compte);
            Console.WriteLine($"Compte {compte.NumeroCompte} ajouté au client {nom} {prenom}.");
        }

        public void SupprimerCompte(Compte compte)
        {
            if (comptes.Remove(compte))
            {
                Console.WriteLine($"Compte {compte.NumeroCompte} supprimé du client {nom} {prenom}.");
            }
            else
            {
                Console.WriteLine($"Le compte {compte.NumeroCompte} n'est pas associé à ce client.");
            }
        }

        public void AfficherComptes()
        {
            Console.WriteLine($"Comptes associés au client {nom} {prenom} :");
            foreach (var compte in comptes)
            {
                compte.AfficherDetails();
            }
        }

        public void affichageClient()
        {
            Console.WriteLine($"Client :: Id : {id} | Nom : {nom} | Prénom : {prenom} | Téléphone : {tel} ");
            AfficherComptes();
        }
    }
}
