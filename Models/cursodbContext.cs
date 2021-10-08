using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


#nullable disable

namespace CentroNet.Models
{
    public partial class cursodbContext : DbContext
    {
        public cursodbContext()
        {
        }

        public cursodbContext(DbContextOptions<cursodbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calificacion> Calificacions { get; set; }
        public virtual DbSet<DatosPadre> DatosPadres { get; set; }
        public virtual DbSet<DatosTutor> DatosTutors { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<FichaMedicaEstudiante> FichaMedicaEstudiantes { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Incripcion> Incripcions { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }
        public virtual DbSet<Matricula> Matriculas { get; set; }
        public virtual DbSet<NivelEstudio> NivelEstudios { get; set; }
        public virtual DbSet<Periodo> Periodos { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=cursodb;Trusted_Connection=False;User Id=sa;Password=J03l21212028");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Calificacion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Calificacion");

                entity.Property(e => e.Course)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("course");

                entity.Property(e => e.Idiscription).HasColumnName("idiscription");

                entity.Property(e => e.Month)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("month");

                entity.Property(e => e.Quantification).HasColumnName("quantification");

                entity.HasOne(d => d.IdiscriptionNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idiscription)
                    .HasConstraintName("FK__Calificac__idisc__151B244E");
            });

            modelBuilder.Entity<DatosPadre>(entity =>
            {
                entity.ToTable("Datos_padres");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirstFather)
                    .HasColumnType("date")
                    .HasColumnName("birst_father");

                entity.Property(e => e.BirstMother)
                    .HasColumnType("date")
                    .HasColumnName("birst_mother");

                entity.Property(e => e.CityFather)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city_father");

                entity.Property(e => e.CityMother)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city_mother");

                entity.Property(e => e.ConditionFather)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("condition_father");

                entity.Property(e => e.ConditionMother)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("condition_mother");

                entity.Property(e => e.ContryFather)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contry_father");

                entity.Property(e => e.ContryMother)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contry_mother");

                entity.Property(e => e.DescribesConditionFather)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("describes_condition_father");

                entity.Property(e => e.DescribesConditionMother)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("describes_condition_mother");

                entity.Property(e => e.IdFather)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id_father");

                entity.Property(e => e.IdMother)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id_mother");

                entity.Property(e => e.LastnameFather)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastname_father");

                entity.Property(e => e.LastnameMother)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastname_mother");

                entity.Property(e => e.NameFather)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_father");

                entity.Property(e => e.NameMother)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_mother");

                entity.Property(e => e.OcupationFather)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ocupation_father");

                entity.Property(e => e.OcupationMother)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ocupation_mother");

                entity.Property(e => e.PhoneFather)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone_father");

                entity.Property(e => e.PhoneMother).HasColumnName("phone_mother");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<DatosTutor>(entity =>
            {
                entity.ToTable("Datos_tutor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressLives)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address_lives");

                entity.Property(e => e.Birt)
                    .HasColumnType("date")
                    .HasColumnName("birt");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Condition)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("condition");

                entity.Property(e => e.Contry)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contry");

                entity.Property(e => e.DescribeCondition)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("describe_condition");

                entity.Property(e => e.IdTutor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id_tutor");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.LevelStudent)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("level_student");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.NumberChildren).HasColumnName("number_children");

                entity.Property(e => e.NumberHouse)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("number_house");

                entity.Property(e => e.Ocupation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ocupation");

                entity.Property(e => e.Phone)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.PhoneCel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone_cel");

                entity.Property(e => e.Sector)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sector");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.ToTable("Estudiante");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("date")
                    .HasColumnName("create_at");

                entity.Property(e => e.IdDatospadre).HasColumnName("idDatospadre");

                entity.Property(e => e.Idgenero).HasColumnName("idgenero");

                entity.Property(e => e.Idtutor).HasColumnName("idtutor");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.Lastnames)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastnames");

                entity.Property(e => e.Names)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("names");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("date")
                    .HasColumnName("update_at");

                entity.HasOne(d => d.IdDatospadreNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdDatospadre)
                    .HasConstraintName("FK__Estudiant__idDat__36B12243");

                entity.HasOne(d => d.IdgeneroNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Idgenero)
                    .HasConstraintName("FK__Estudiant__idgen__02FC7413");

                entity.HasOne(d => d.IdtutorNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Idtutor)
                    .HasConstraintName("FK__Estudiant__idtut__37A5467C");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Estudiant__iduse__267ABA7A");
            });

            modelBuilder.Entity<FichaMedicaEstudiante>(entity =>
            {
                entity.ToTable("Ficha_medica_estudiante");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Allergy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("allergy");

                entity.Property(e => e.Disease)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("disease");

                entity.Property(e => e.GroupBlood)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("group_blood");

                entity.Property(e => e.HealthSystem)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("health_system");

                entity.Property(e => e.Height)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("height");

                entity.Property(e => e.Idstuden).HasColumnName("idstuden");

                entity.Property(e => e.MedicalTreatment)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("medical_treatment");

                entity.Property(e => e.Observartion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("observartion");

                entity.Property(e => e.SurgicalIntervention)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("surgical_intervention");

                entity.Property(e => e.TreatmentAllergy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("treatment_allergy");

                entity.Property(e => e.TypeFeeding)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type_feeding");

                entity.Property(e => e.Weight)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("weight");

                entity.HasOne(d => d.IdstudenNavigation)
                    .WithMany(p => p.FichaMedicaEstudiantes)
                    .HasForeignKey(d => d.Idstuden)
                    .HasConstraintName("FK__Ficha_med__idstu__34C8D9D1");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.ToTable("Genero");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gender");
            });

            modelBuilder.Entity<Incripcion>(entity =>
            {
                entity.ToTable("Incripcion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodeLevel).HasColumnName("code_level");

                entity.Property(e => e.CodeMatricula).HasColumnName("code_matricula");

                entity.Property(e => e.Idperiodo).HasColumnName("idperiodo");

                entity.HasOne(d => d.CodeMatriculaNavigation)
                    .WithMany(p => p.Incripcions)
                    .HasForeignKey(d => d.CodeMatricula)
                    .HasConstraintName("FK__Incripcio__code___5BE2A6F2");
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Materias__357D4CF85DEE7A82");

                entity.Property(e => e.Code)
                    .ValueGeneratedNever()
                    .HasColumnName("code");

                entity.Property(e => e.CodeLevel).HasColumnName("code_level");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("date")
                    .HasColumnName("create_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.NameCourse)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_course");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("date")
                    .HasColumnName("update_at");

                entity.Property(e => e.UserCreate).HasColumnName("user_create");

                entity.Property(e => e.UserUpdate).HasColumnName("user_update");

                entity.HasOne(d => d.CodeLevelNavigation)
                    .WithMany(p => p.Materia)
                    .HasForeignKey(d => d.CodeLevel)
                    .HasConstraintName("FK__Materias__code_l__403A8C7D");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Matricul__357D4CF8260CA8C2");

                entity.ToTable("Matricula");

                entity.Property(e => e.Code)
                    .ValueGeneratedNever()
                    .HasColumnName("code");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("date")
                    .HasColumnName("create_at");

                entity.Property(e => e.Idstuden).HasColumnName("idstuden");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.IdstudenNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.Idstuden)
                    .HasConstraintName("FK__Matricula__idstu__59063A47");
            });

            modelBuilder.Entity<NivelEstudio>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Nivel_es__357D4CF886CFC697");

                entity.ToTable("Nivel_estudio");

                entity.Property(e => e.Code)
                    .ValueGeneratedNever()
                    .HasColumnName("code");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("date")
                    .HasColumnName("create_at");

                entity.Property(e => e.NameLevel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_level");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("date")
                    .HasColumnName("update_at");

                entity.Property(e => e.UserCreate).HasColumnName("user_create");

                entity.Property(e => e.UserUpdate).HasColumnName("user_update");
            });

            modelBuilder.Entity<Periodo>(entity =>
            {
                entity.ToTable("Periodo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FromYear)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("from_year");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UntilYear)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("until_year");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("date")
                    .HasColumnName("create_at");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("date")
                    .HasColumnName("update_at");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("date")
                    .HasColumnName("create_at");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.Passwords)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("passwords");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("date")
                    .HasColumnName("update_at");

                entity.Property(e => e.Users)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("users");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__Usuario__id_rol__5EBF139D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
