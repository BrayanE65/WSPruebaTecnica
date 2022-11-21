namespace WSPruebaTecnica.Request
{
    public class PersonasRequest
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int NIP { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string TipoNIP { get; set; }
        public string Email { get; set; }
    }
}
