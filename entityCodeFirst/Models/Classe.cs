using System.ComponentModel.DataAnnotations;

namespace entityCodeFirst.Models
{
    public class Classe
    {
        [Key]
        public int IdClasse { get; set; }
        public string NameClasse { get; set; }
        public string Departement { get; set; }
        public Classe(int idClasse, string nameClasse, string departement)
        {
            IdClasse = idClasse;
            NameClasse = nameClasse;
            Departement = departement;
        }

        public Classe() { }
    }
}
