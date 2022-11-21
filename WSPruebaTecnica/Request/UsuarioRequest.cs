using Microsoft.VisualBasic;

namespace WSPruebaTecnica.Request
{
    public class UsuarioRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Password { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
