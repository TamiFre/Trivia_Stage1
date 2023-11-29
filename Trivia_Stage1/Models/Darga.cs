using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trivia_Stage1.Models;

[Table("Darga")]
public partial class Darga
{
    [Key]
    [Column("DargaID")]
    public int DargaId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? DargaName { get; set; }

    [InverseProperty("Darga")]
    public virtual ICollection<Player> Players { get; } = new List<Player>();
}
