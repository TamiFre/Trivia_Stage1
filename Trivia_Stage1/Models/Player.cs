using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trivia_Stage1.Models;

public partial class Player
{
    [Key]
    [Column("PlayerID")]
    public int PlayerId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Mail { get; set; }

    [StringLength(20)]
    public string? Pass { get; set; }

    public int? Points { get; set; }

    [StringLength(70)]
    public string? PlayerName { get; set; }

    [Column("DargaID")]
    public int? DargaId { get; set; }

    [ForeignKey("DargaId")]
    [InverseProperty("Players")]
    public virtual Darga? Darga { get; set; }

    [InverseProperty("Player")]
    public virtual ICollection<Q> Qs { get; } = new List<Q>();
}
