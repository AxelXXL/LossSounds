//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_Album
    {
        public tb_Album()
        {
            this.tb_Cancion = new HashSet<tb_Cancion>();
        }
    
        public int ID_ALBUM { get; set; }
        public int ID_ARTISTA { get; set; }
        public string Nombre_album { get; set; }
        public string Genero { get; set; }
        public int Año_Album { get; set; }
    
        public virtual tb_Artista tb_Artista { get; set; }
        public virtual ICollection<tb_Cancion> tb_Cancion { get; set; }
    }
}
