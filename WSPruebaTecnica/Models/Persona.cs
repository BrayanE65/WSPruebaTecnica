using System;
using System.Collections.Generic;

namespace WSPruebaTecnica.Models;

public partial class Persona
{
    public long Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public int Nip { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string Email { get; set; } = null!;

    public string TipoNip { get; set; } = null!;
}
