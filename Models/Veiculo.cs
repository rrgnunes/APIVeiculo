using System;
namespace Backend.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public String Placa { get; set; }
        public String Cor { get; set; }
        public String Modelo { get; set; }
        public string AnoFab { get; set; }
        public String Fabricante { get; set; }
    }
}
