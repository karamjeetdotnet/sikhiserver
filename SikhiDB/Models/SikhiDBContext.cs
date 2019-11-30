using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SikhiDB.Models
{
    public partial class SikhiDBContext : DbContext
    {
        public SikhiDBContext()
        {
        }

        public SikhiDBContext(DbContextOptions<SikhiDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<bani_index> bani_index { get; set; }
        public virtual DbSet<bani_index_range> bani_index_range { get; set; }
        public virtual DbSet<bani_text> bani_text { get; set; }
        public virtual DbSet<bani_text_line> bani_text_line { get; set; }
        public virtual DbSet<db_system_info> db_system_info { get; set; }
        public virtual DbSet<file_source> file_source { get; set; }
        public virtual DbSet<languages> languages { get; set; }
        public virtual DbSet<locale> locale { get; set; }
        public virtual DbSet<source_index> source_index { get; set; }
        public virtual DbSet<source_index_range> source_index_range { get; set; }
        public virtual DbSet<translation_source> translation_source { get; set; }
        public virtual DbSet<writer> writer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=gurbanidb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<bani_index>(entity =>
            {
                entity.ToTable("bani_index", "gurbanidb");

                entity.HasIndex(e => e.file_source_id)
                    .HasName("bani_index_file_source_file_source_id_id_idx");

                entity.HasIndex(e => e.locale_id)
                    .HasName("bani_index_locale_locale_id_id_idx");

                entity.Property(e => e.id).HasColumnType("bigint(20)");

                entity.Property(e => e.file_source_id).HasColumnType("bigint(20)");

                entity.Property(e => e.locale_id).HasColumnType("bigint(20)");

                entity.HasOne(d => d.file_source_)
                    .WithMany(p => p.bani_index)
                    .HasForeignKey(d => d.file_source_id)
                    .HasConstraintName("bani_index_file_source_file_source_id_id");

                entity.HasOne(d => d.locale_)
                    .WithMany(p => p.bani_index)
                    .HasForeignKey(d => d.locale_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bani_index_locale_locale_id_id");
            });

            modelBuilder.Entity<bani_index_range>(entity =>
            {
                entity.ToTable("bani_index_range", "gurbanidb");

                entity.HasIndex(e => e.bani_index_id)
                    .HasName("bani_index_range_bani_index_index_id_id_idx");

                entity.HasIndex(e => e.file_source_id)
                    .HasName("bani_index_range_file_source_file_source_id_id_idx");

                entity.Property(e => e.id).HasColumnType("bigint(20)");

                entity.Property(e => e.bani_index_id).HasColumnType("bigint(20)");

                entity.Property(e => e.end)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.file_source_id).HasColumnType("bigint(20)");

                entity.Property(e => e.start)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.bani_index_)
                    .WithMany(p => p.bani_index_range)
                    .HasForeignKey(d => d.bani_index_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bani_index_range_bani_index_bani_index_id_id");

                entity.HasOne(d => d.file_source_)
                    .WithMany(p => p.bani_index_range)
                    .HasForeignKey(d => d.file_source_id)
                    .HasConstraintName("bani_index_range_file_source_file_source_id_id");
            });

            modelBuilder.Entity<bani_text>(entity =>
            {
                entity.ToTable("bani_text", "gurbanidb");

                entity.HasIndex(e => e.file_source_id)
                    .HasName("bani_text_file_source_file_source_id_id_idx");

                entity.HasIndex(e => e.section_source_id)
                    .HasName("source_index_bani_text_section_source_id_id_idx");

                entity.HasIndex(e => e.subsection_source_id)
                    .HasName("source_index_range_bani_text_id_subsection_source_id_idx");

                entity.HasIndex(e => e.writer_id)
                    .HasName("writer_bani_text_id_writer_id_idx");

                entity.Property(e => e.id).HasColumnType("bigint(20)");

                entity.Property(e => e.file_source_id).HasColumnType("bigint(20)");

                entity.Property(e => e.gurbani_db_id)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.section_source_id).HasColumnType("bigint(20)");

                entity.Property(e => e.sttm_id).HasColumnType("bigint(20)");

                entity.Property(e => e.subsection_source_id).HasColumnType("bigint(20)");

                entity.Property(e => e.writer_id).HasColumnType("bigint(20)");

                entity.HasOne(d => d.file_source_)
                    .WithMany(p => p.bani_text)
                    .HasForeignKey(d => d.file_source_id)
                    .HasConstraintName("bani_text_file_source_file_source_id_id");

                entity.HasOne(d => d.section_source_)
                    .WithMany(p => p.bani_text)
                    .HasForeignKey(d => d.section_source_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("source_index_bani_text_section_source_id_id");

                entity.HasOne(d => d.subsection_source_)
                    .WithMany(p => p.bani_text)
                    .HasForeignKey(d => d.subsection_source_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("source_index_range_bani_text_id_subsection_source_id");

                entity.HasOne(d => d.writer_)
                    .WithMany(p => p.bani_text)
                    .HasForeignKey(d => d.writer_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bani_text_writer_writer_id_id");
            });

            modelBuilder.Entity<bani_text_line>(entity =>
            {
                entity.ToTable("bani_text_line", "gurbanidb");

                entity.HasIndex(e => e.bani_text_id)
                    .HasName("bani_text_line_bani_text_bani_text_id_id_idx");

                entity.HasIndex(e => e.file_source_id)
                    .HasName("bani_text_line_file_source_file_source_id_id_idx");

                entity.Property(e => e.id).HasColumnType("bigint(20)");

                entity.Property(e => e.bani_text_id).HasColumnType("bigint(20)");

                entity.Property(e => e.file_source_id).HasColumnType("bigint(20)");

                entity.Property(e => e.gurbani_db_id)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.gurmukhi).HasColumnType("longtext");

                entity.Property(e => e.pronunciation).HasColumnType("longtext");

                entity.Property(e => e.pronunciation_information).HasColumnType("longtext");

                entity.Property(e => e.source_line).HasColumnType("bigint(20)");

                entity.Property(e => e.source_page).HasColumnType("bigint(20)");

                entity.Property(e => e.translation).HasColumnType("longtext");

                entity.HasOne(d => d.bani_text_)
                    .WithMany(p => p.bani_text_line)
                    .HasForeignKey(d => d.bani_text_id)
                    .HasConstraintName("bani_text_line_bani_text_bani_text_id_id");

                entity.HasOne(d => d.file_source_)
                    .WithMany(p => p.bani_text_line)
                    .HasForeignKey(d => d.file_source_id)
                    .HasConstraintName("bani_text_line_file_source_file_source_id_id");
            });

            modelBuilder.Entity<db_system_info>(entity =>
            {
                entity.ToTable("db_system_info", "gurbanidb");

                entity.Property(e => e.id).HasColumnType("bigint(20)");

                entity.Property(e => e.information).HasColumnType("longtext");
            });

            modelBuilder.Entity<file_source>(entity =>
            {
                entity.ToTable("file_source", "gurbanidb");

                entity.Property(e => e.id).HasColumnType("bigint(20)");

                entity.Property(e => e.content).HasColumnType("longtext");

                entity.Property(e => e.file_name)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.source)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<languages>(entity =>
            {
                entity.ToTable("languages", "gurbanidb");

                entity.HasIndex(e => e.file_source_id)
                    .HasName("languages_file_source_file_source_id_id_idx");

                entity.HasIndex(e => e.locale_id)
                    .HasName("languages_locale_locale_id_id_idx");

                entity.Property(e => e.id).HasColumnType("bigint(20)");

                entity.Property(e => e.file_source_id).HasColumnType("bigint(20)");

                entity.Property(e => e.locale_id).HasColumnType("bigint(20)");

                entity.HasOne(d => d.file_source_)
                    .WithMany(p => p.languages)
                    .HasForeignKey(d => d.file_source_id)
                    .HasConstraintName("languages_file_source_file_source_id_id");

                entity.HasOne(d => d.locale_)
                    .WithMany(p => p.languages)
                    .HasForeignKey(d => d.locale_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("languages_locale_locale_id_id");
            });

            modelBuilder.Entity<locale>(entity =>
            {
                entity.ToTable("locale", "gurbanidb");

                entity.Property(e => e.id).HasColumnType("bigint(12)");

                entity.Property(e => e.english).HasColumnType("longtext");

                entity.Property(e => e.gurmukhi)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.internatinal).HasColumnType("longtext");
            });

            modelBuilder.Entity<source_index>(entity =>
            {
                entity.ToTable("source_index", "gurbanidb");

                entity.HasIndex(e => e.file_source_id)
                    .HasName("source_index_file_source_file_source_id_id_idx");

                entity.HasIndex(e => e.locale_id)
                    .HasName("source_index_locale_locale_id_id_idx");

                entity.Property(e => e.id).HasColumnType("bigint(20)");

                entity.Property(e => e.english_page_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.file_source_id).HasColumnType("bigint(20)");

                entity.Property(e => e.gurmukhi_page_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.length).HasColumnType("int(11)");

                entity.Property(e => e.locale_id).HasColumnType("bigint(20)");

                entity.HasOne(d => d.file_source_)
                    .WithMany(p => p.source_index)
                    .HasForeignKey(d => d.file_source_id)
                    .HasConstraintName("source_index_file_source_file_source_id_id");

                entity.HasOne(d => d.locale_)
                    .WithMany(p => p.source_index)
                    .HasForeignKey(d => d.locale_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("source_index_locale_locale_id_id");
            });
            modelBuilder.Entity<source_index_range>().Ignore(x => x.is_subsection);
            modelBuilder.Entity<source_index_range>(entity =>
            {
                entity.ToTable("source_index_range", "gurbanidb");

                entity.HasIndex(e => e.file_source_id)
                    .HasName("source_index_range_file_source_file_source_id_id_idx");

                entity.HasIndex(e => e.locale_id)
                    .HasName("source_index_locale_id_locale_id_idx");

                entity.HasIndex(e => e.source_index_id)
                    .HasName("source_index_id_source_index_id_idx");

                entity.HasIndex(e => e.source_index_range_id)
                    .HasName("source_index_range_source_index_range_id_id_idx");

                entity.Property(e => e.id).HasColumnType("bigint(20)");

                entity.Property(e => e.description).HasColumnType("longtext");

                entity.Property(e => e.end_page).HasColumnType("bigint(20)");

                entity.Property(e => e.file_source_id).HasColumnType("bigint(20)");

                entity.Property(e => e.locale_id).HasColumnType("bigint(20)");

                entity.Property(e => e.source_index_id).HasColumnType("bigint(20)");

                entity.Property(e => e.source_index_range_id).HasColumnType("bigint(20)");

                entity.Property(e => e.start_page).HasColumnType("bigint(20)");

                entity.HasOne(d => d.file_source_)
                    .WithMany(p => p.source_index_range)
                    .HasForeignKey(d => d.file_source_id)
                    .HasConstraintName("source_index_range_file_source_file_source_id_id");

                entity.HasOne(d => d.locale_)
                    .WithMany(p => p.source_index_range)
                    .HasForeignKey(d => d.locale_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("source_index_locale_id_locale_id");

                entity.HasOne(d => d.source_index_)
                    .WithMany(p => p.source_index_range)
                    .HasForeignKey(d => d.source_index_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("source_index_id_source_index_id");

                entity.HasOne(d => d.source_index_range_)
                    .WithMany(p => p.Inversesource_index_range_)
                    .HasForeignKey(d => d.source_index_range_id)
                    .HasConstraintName("source_index_range_source_index_range_id_id");
            });

            modelBuilder.Entity<translation_source>(entity =>
            {
                entity.ToTable("translation_source", "gurbanidb");

                entity.HasIndex(e => e.file_source_id)
                    .HasName("translation_source_file_source_file_source_id_id_idx");

                entity.HasIndex(e => e.locale_id)
                    .HasName("translation_source_locale_locale_id_id_idx");

                entity.HasIndex(e => e.source_index_id)
                    .HasName("translation_source_source_index_source_id_id_idx");

                entity.Property(e => e.id).HasColumnType("bigint(20)");

                entity.Property(e => e.file_source_id).HasColumnType("bigint(20)");

                entity.Property(e => e.language)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.locale_id).HasColumnType("bigint(20)");

                entity.Property(e => e.source_index_id).HasColumnType("bigint(20)");

                entity.HasOne(d => d.file_source_)
                    .WithMany(p => p.translation_source)
                    .HasForeignKey(d => d.file_source_id)
                    .HasConstraintName("translation_source_file_source_file_source_id_id");

                entity.HasOne(d => d.locale_)
                    .WithMany(p => p.translation_source)
                    .HasForeignKey(d => d.locale_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("translation_source_locale_locale_id_id");

                entity.HasOne(d => d.source_index_)
                    .WithMany(p => p.translation_source)
                    .HasForeignKey(d => d.source_index_id)
                    .HasConstraintName("translation_source_source_index_source_id_id");
            });

            modelBuilder.Entity<writer>(entity =>
            {
                entity.ToTable("writer", "gurbanidb");

                entity.HasIndex(e => e.file_source_id)
                    .HasName("writer_file_source_file_source_id_id_idx");

                entity.HasIndex(e => e.locale_id)
                    .HasName("writer_locale_locale_id_id_idx");

                entity.Property(e => e.id).HasColumnType("bigint(20)");

                entity.Property(e => e.file_source_id).HasColumnType("bigint(20)");

                entity.Property(e => e.locale_id).HasColumnType("bigint(20)");

                entity.HasOne(d => d.file_source_)
                    .WithMany(p => p.writer)
                    .HasForeignKey(d => d.file_source_id)
                    .HasConstraintName("writer_file_source_file_source_id_id");

                entity.HasOne(d => d.locale_)
                    .WithMany(p => p.writer)
                    .HasForeignKey(d => d.locale_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("writer_locale_locale_id_id");
            });
        }
    }
}
