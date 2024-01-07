using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Badges.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; } = null!;
        public virtual DbSet<AssignmentsTrainee> AssignmentsTrainees { get; set; } = null!;
        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<AttendanceTrainee> AttendanceTrainees { get; set; } = null!;
        public virtual DbSet<Badge> Badges { get; set; } = null!;
        public virtual DbSet<BadgesTrainee> BadgesTrainees { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseTrainee> CourseTrainees { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=C##React;PASSWORD=123;DATA SOURCE=LAPTOP-7QQ9D99B:1521/xe;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##REACT")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(e => e.Assignmentsid)
                    .HasName("SYS_C008430");

                entity.ToTable("ASSIGNMENTS");

                entity.Property(e => e.Assignmentsid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ASSIGNMENTSID");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Datecreate)
                    .HasColumnType("DATE")
                    .HasColumnName("DATECREATE");

                entity.Property(e => e.Deadline)
                    .HasColumnType("DATE")
                    .HasColumnName("DEADLINE");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Mark)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MARK");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.Courseid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008431");
            });

            modelBuilder.Entity<AssignmentsTrainee>(entity =>
            {
                entity.HasKey(e => e.Atid)
                    .HasName("SYS_C008433");

                entity.ToTable("ASSIGNMENTS_TRAINEE");

                entity.Property(e => e.Atid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ATID");

                entity.Property(e => e.Assignmentsid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ASSIGNMENTSID");

                entity.Property(e => e.Assignmenturl)
                    .IsUnicode(false)
                    .HasColumnName("ASSIGNMENTURL");

                entity.Property(e => e.Mark)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MARK");

                entity.Property(e => e.Submitdate)
                    .HasColumnType("DATE")
                    .HasColumnName("SUBMITDATE");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Assignments)
                    .WithMany(p => p.AssignmentsTrainees)
                    .HasForeignKey(d => d.Assignmentsid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008435");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AssignmentsTrainees)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008434");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("ATTENDANCE");

                entity.Property(e => e.Attendanceid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ATTENDANCEID");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("COURSEID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.Courseid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008428");
            });

            modelBuilder.Entity<AttendanceTrainee>(entity =>
            {
                entity.HasKey(e => e.Atid)
                    .HasName("SYS_C008453");

                entity.ToTable("ATTENDANCE_TRAINEE");

                entity.Property(e => e.Atid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ATID");

                entity.Property(e => e.Attendanceid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ATTENDANCEID");

                entity.Property(e => e.Attendantedate)
                    .HasColumnType("DATE")
                    .HasColumnName("ATTENDANTEDATE");

                entity.Property(e => e.Checkat)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHECKAT");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Attendance)
                    .WithMany(p => p.AttendanceTrainees)
                    .HasForeignKey(d => d.Attendanceid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008455");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AttendanceTrainees)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008454");
            });

            modelBuilder.Entity<Badge>(entity =>
            {
                entity.HasKey(e => e.Badgesid)
                    .HasName("SYS_C008437");

                entity.ToTable("BADGES");

                entity.Property(e => e.Badgesid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BADGESID");

                entity.Property(e => e.Activecriteria)
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVECRITERIA");

                entity.Property(e => e.Criteria)
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasColumnName("CRITERIA");

                entity.Property(e => e.Image)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Text)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("TEXT");

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<BadgesTrainee>(entity =>
            {
                entity.HasKey(e => e.Btid)
                    .HasName("SYS_C008447");

                entity.ToTable("BADGES_TRAINEE");

                entity.Property(e => e.Btid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BTID");

                entity.Property(e => e.Assignmentsid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ASSIGNMENTSID");

                entity.Property(e => e.Badgesid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("BADGESID");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Assignments)
                    .WithMany(p => p.BadgesTrainees)
                    .HasForeignKey(d => d.Assignmentsid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008449");

                entity.HasOne(d => d.Badges)
                    .WithMany(p => p.BadgesTrainees)
                    .HasForeignKey(d => d.Badgesid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008451");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.BadgesTrainees)
                    .HasForeignKey(d => d.Courseid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008450");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BadgesTrainees)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008448");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("COURSE");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Coursenum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COURSENUM");

                entity.Property(e => e.Datefrom)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEFROM");

                entity.Property(e => e.Dateto)
                    .HasColumnType("DATE")
                    .HasColumnName("DATETO");

                entity.Property(e => e.Duration)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATION");

                entity.Property(e => e.Image)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Sectionnum)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SECTIONNUM");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008416");
            });

            modelBuilder.Entity<CourseTrainee>(entity =>
            {
                entity.HasKey(e => e.Ctid)
                    .HasName("SYS_C008418");

                entity.ToTable("COURSE_TRAINEE");

                entity.Property(e => e.Ctid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CTID");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Mark)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MARK");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseTrainees)
                    .HasForeignKey(d => d.Courseid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008420");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CourseTrainees)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008419");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Image)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008413");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
