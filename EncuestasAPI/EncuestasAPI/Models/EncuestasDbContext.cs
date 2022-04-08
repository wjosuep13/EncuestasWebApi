using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EncuestasAPI.Models
{
    public partial class EncuestasDbContext : DbContext
    {
        public EncuestasDbContext()
        {
        }

        public EncuestasDbContext(DbContextOptions<EncuestasDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Campo> Campos { get; set; }
        public virtual DbSet<EncuestaTable> EncuestaTables { get; set; }
        public virtual DbSet<RespuestasEncuestum> RespuestasEncuesta { get; set; }
        public virtual DbSet<TipoCampo> TipoCampos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=GT3140615W1\\SQLEXPRESS; Initial Catalog=Encuestas; Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campo>(entity =>
            {
                entity.HasKey(e => e.IdCampo)
                    .HasName("PK__Campo__C1F0647E44EFBC24");

                entity.ToTable("Campo");

                entity.Property(e => e.IdCampo).HasColumnName("id_campo");

                entity.Property(e => e.EsRequerido).HasColumnName("es_requerido");

                entity.Property(e => e.IdEncuesta).HasColumnName("id_encuesta");

                entity.Property(e => e.IdTipoCampo).HasColumnName("id_tipo_campo");

                entity.Property(e => e.NombreCampo)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre_campo");

                entity.Property(e => e.TituloCampo)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("titulo_campo");

                entity.HasOne(d => d.IdEncuestaNavigation)
                    .WithMany(p => p.Campos)
                    .HasForeignKey(d => d.IdEncuesta)
                    .HasConstraintName("FK_Encuesta_Campo");

                entity.HasOne(d => d.IdTipoCampoNavigation)
                    .WithMany(p => p.Campos)
                    .HasForeignKey(d => d.IdTipoCampo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoCampo");
            });

            modelBuilder.Entity<EncuestaTable>(entity =>
            {
                entity.HasKey(e => e.IdEncuesta)
                    .HasName("PK__Encuesta__013535C33480E3DA");

                entity.ToTable("EncuestaTable");

                entity.Property(e => e.IdEncuesta).HasColumnName("id_encuesta");

                entity.Property(e => e.DescripcionEncuesta)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion_encuesta");

                entity.Property(e => e.Link)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("link");

                entity.Property(e => e.NombreEncuesta)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre_encuesta");
            });

            modelBuilder.Entity<RespuestasEncuestum>(entity =>
            {
                entity.HasKey(e => e.IdRespuesta)
                    .HasName("PK__Respuest__14E55589C5D9D2EB");

                entity.Property(e => e.IdRespuesta).HasColumnName("id_respuesta");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdEncuesta).HasColumnName("id_encuesta");

                entity.Property(e => e.Respuestas)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("respuestas");

                entity.HasOne(d => d.IdEncuestaNavigation)
                    .WithMany(p => p.RespuestasEncuesta)
                    .HasForeignKey(d => d.IdEncuesta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Respuesta_Encuesta");
            });

            modelBuilder.Entity<TipoCampo>(entity =>
            {
                entity.HasKey(e => e.IdTipoCampo)
                    .HasName("PK__TipoCamp__5F5F2007BA886044");

                entity.ToTable("TipoCampo");

                entity.Property(e => e.IdTipoCampo).HasColumnName("id_tipo_campo");

                entity.Property(e => e.DescripcionTipo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("descripcion_tipo");

                entity.Property(e => e.TipoHtml)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("tipo_html");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
