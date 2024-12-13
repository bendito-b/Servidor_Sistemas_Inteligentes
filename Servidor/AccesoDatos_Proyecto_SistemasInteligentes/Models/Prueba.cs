using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos_Proyecto_SistemasInteligentes.Models;

[Table("prueba")]
public partial class Prueba
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
}
