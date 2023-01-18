using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using SQLite;

namespace Anotaçoes.Models
{
    [Table("Anotacoes")]
    public class Notas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Titulo { get; set; }
        [NotNull]
        public string Dados { get; set; }
        [NotNull]
        public Boolean Favorito { get; set; }

        public Notas()
        {
            this.Id= 0;
            this.Dados = "";
            this.Titulo = "";
            this.Favorito = false;
        }
    }
}
