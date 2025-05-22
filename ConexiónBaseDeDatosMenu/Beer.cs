using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexiónBaseDeDatosMenu
{
    public class Beer
    {
        public string name { get; set; }
        public int Id { get; set; }
        public int brandID { get; set; }
        
        
        public Beer(int id, string name, int brandID)
        {
            this.Id = id;
            this.name = name;
            this.brandID = brandID;
        }

        public Beer(string name, int brandID)
        {
            this.name = name;
            this.brandID = brandID;
        }

        public override string ToString()
        {
            //la ,-XX número indican que se impfiman en un espacio de XX números
            // y el menos (-) dice que sea alineado a ala izquierda, si es positivo
            //se alinea a la derecha.
            return $"{Id,-10} {name,-20} {brandID,-10}";
        }
    }
}
