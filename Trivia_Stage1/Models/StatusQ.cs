using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trivia_Stage1.Models;

public partial class StatusQ
{
    [Key]
    [Column("StatusID")]
    public int StatusId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? StatusName { get; set; }

    [InverseProperty("Status")]
    public virtual ICollection<Q> Qs { get; } = new List<Q>();
}
