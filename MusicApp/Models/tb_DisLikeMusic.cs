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
    
    public partial class tb_DisLikeMusic
    {
        public int ID_DISLIKES { get; set; }
        public int ID_USUARIO { get; set; }
        public int ID_CANCION { get; set; }
    
        public virtual tb_Cancion tb_Cancion { get; set; }
        public virtual tb_Usuario tb_Usuario { get; set; }
    }
}
