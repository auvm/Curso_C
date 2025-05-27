using System;
using System.Collections.Generic;

namespace EntityFrameWorkBaseDeDatos;

public partial class Beer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int BrandId { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public override string ToString()
    {
        //la ,-XX número indican que se impfiman en un espacio de XX números
        // y el menos (-) dice que sea alineado a ala izquierda, si es positivo
        //se alinea a la derecha.
        return $"{Id,-10} {Name,-20} {BrandId,-10}";
    }
}
