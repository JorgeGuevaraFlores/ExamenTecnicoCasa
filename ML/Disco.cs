using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Disco
    {
        public int IdDisco{ get; set; }
        public string Titulo { get; set; }
        public string Duracion { get; set; }
        public DateTime Anio { get; set; }
        public decimal Ventas { get; set; }
        public bool Disponibilidad { get; set; }
        public List<object> Discos { get; set; }
        public ML.Artista Artista { get; set; }
        public ML.GeneroMusical GeneroMusical { get; set; }
        public ML.Distribuidora Distribuidora { get; set; }
    }
}
