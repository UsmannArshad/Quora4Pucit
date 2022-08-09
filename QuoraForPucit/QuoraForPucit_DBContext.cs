﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QuoraForPucit.Models;

namespace QuoraForPucit
{
    public partial class QuoraForPucit_DBContext : DbContext
    {
        public QuoraForPucit_DBContext()
        {
        }

        public QuoraForPucit_DBContext(DbContextOptions<QuoraForPucit_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AComment> AComments { get; set; } = null!;
        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<QComment> QComments { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QuoraForPucit_DB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AComment>(entity =>
            {
                entity.ToTable("A_Comments");

                entity.Property(e => e.Comment).IsUnicode(false);

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.AComments)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_A_Comments_Answers");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AComments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_A_Comments_Users");
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.AnswerDescription).IsUnicode(false);

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.Property(e => e.Upvote).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Answerer)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.AnswererId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answers_Users");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answers_Questions");
            });

            modelBuilder.Entity<QComment>(entity =>
            {
                entity.ToTable("Q_Comments");

                entity.Property(e => e.Comment).IsUnicode(false);

                entity.Property(e => e.QCommenterId).HasColumnName("Q_CommenterId");

                entity.HasOne(d => d.QCommenter)
                    .WithMany(p => p.QComments)
                    .HasForeignKey(d => d.QCommenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Q_Comments_Users");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QComments)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Q_Comments_Questions");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Upvote).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Questionaire)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuestionaireId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Questions_ToTable");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Github).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Twitter).IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Website).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}