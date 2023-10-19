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
    
    public partial class tb_Cancion
    {
        public tb_Cancion()
        {
            this.tb_Comentarios = new HashSet<tb_Comentarios>();
            this.tb_DisLikeMusic = new HashSet<tb_DisLikeMusic>();
            this.tb_Playlist = new HashSet<tb_Playlist>();
        }
    
        public int ID_CANCION { get; set; }
        public int ID_ARTISTA { get; set; }
        public int ID_ALBUM { get; set; }
        public string Nombre_Cancion { get; set; }
        public Nullable<decimal> Numero_Cancion { get; set; }
        public string Ruta_Audio { get; set; }
        public int Duracion_Cancion { get; set; }
    
        public virtual tb_Album tb_Album { get; set; }
        public virtual tb_Artista tb_Artista { get; set; }
        public virtual ICollection<tb_Comentarios> tb_Comentarios { get; set; }
        public virtual ICollection<tb_DisLikeMusic> tb_DisLikeMusic { get; set; }
        public virtual ICollection<tb_Playlist> tb_Playlist { get; set; }
    }
}
