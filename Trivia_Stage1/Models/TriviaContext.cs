using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Trivia_Stage1.Models;

public partial class TriviaContext : DbContext
{
    public TriviaContext()
    {
    }

    public TriviaContext(DbContextOptions<TriviaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Darga> Dargas { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Q> Qs { get; set; }

    public virtual DbSet<StatusQ> StatusQs { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = localhost\\SQLEXPRESS; Database=TriviaDB; Trusted_Connection=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Darga>(entity =>
        {
            entity.HasKey(e => e.DargaId).HasName("PK__Darga__8AF63CB889A6FF34");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("PK__Players__4A4E74A85F9B5A32");

            entity.HasOne(d => d.Darga).WithMany(p => p.Players).HasConstraintName("FK__Players__DargaID__3C69FB99");
        });

        modelBuilder.Entity<Q>(entity =>
        {
            entity.HasKey(e => e.Qid).HasName("PK__Qs__CAB147CB50A67F0E");

            entity.HasOne(d => d.Player).WithMany(p => p.Qs).HasConstraintName("FK__Qs__PlayerID__52593CB8");

            entity.HasOne(d => d.Status).WithMany(p => p.Qs).HasConstraintName("FK__Qs__StatusID__5441852A");

            entity.HasOne(d => d.Subject).WithMany(p => p.Qs).HasConstraintName("FK__Qs__SubjectID__534D60F1");
        });

        modelBuilder.Entity<StatusQ>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__StatusQs__C8EE20432708FDAB");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__AC1BA388D7133186");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
