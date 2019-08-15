using System;
namespace exanim.Models
{
    public class Emisor
    {
        //Revisar en el examén esta definido como string, pero la base lo tiene como int
        public int Id { get; set; }
        public string Rfc { get; set; }
        //Revisa en el examén esta definido como datetime, pero en la base esta como string
        public string FechaInicioOperacion { get; set; }
        public decimal Capital { get; set; }
        //Este campo no viene en la definición del modelo
        public int? activo { get; set; }
    }
}
