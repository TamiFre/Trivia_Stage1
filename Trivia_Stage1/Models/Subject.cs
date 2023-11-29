using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trivia_Stage1.Models;

public partial class Subject
{
    [Key]
    [Column("SubjectID")]
    public int SubjectId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? SubjectName { get; set; }

    [InverseProperty("Subject")]
    public virtual ICollection<Q> Qs { get; } = new List<Q>();
}
