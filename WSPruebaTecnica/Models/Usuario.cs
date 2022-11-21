using System;
using System.Collections.Generic;

namespace WSPruebaTecnica.Models;

public partial class Usuario
{
    public long Id { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }
}
