using System;
using System.Collections.Generic;

namespace AccesoDatos_Proyecto_SistemasInteligentes.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }


    public string LogiUsuario { get; set; } = null!;

    public string PassUsuario { get; set; } = null!;

    public string? NombUsuario { get; set; } = null!;

    public string? AppUsuario { get; set; } = null!;

    public string? ApmaUsuario { get; set; } = null!;

    public string? RolUsuario { get; set; } = null!;
}
