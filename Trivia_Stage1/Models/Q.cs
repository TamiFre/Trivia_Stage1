using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trivia_Stage1.Models;

public partial class Q
{
    [Key]
    [Column("QID")]
    public int Qid { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Title { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? AnsCorrect { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? A1 { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? A2 { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? A3 { get; set; }

    [Column("PlayerID")]
    public int? PlayerId { get; set; }

    [Column("SubjectID")]
    public int? SubjectId { get; set; }

    [Column("StatusID")]
    public int? StatusId { get; set; }

    [ForeignKey("PlayerId")]
    [InverseProperty("Qs")]
    public virtual Player? Player { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("Qs")]
    public virtual StatusQ? Status { get; set; }

    [ForeignKey("SubjectId")]
    [InverseProperty("Qs")]
    public virtual Subject? Subject { get; set; }
}
