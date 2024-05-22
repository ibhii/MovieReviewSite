using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MovieReviewSite.DataBase;

namespace MovieReviewSite.DataBase.Contexts;

public partial class ReviewSiteContext : DbContext
{
    public ReviewSiteContext(DbContextOptions<ReviewSiteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgeRate> AgeRates { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Crew> Crews { get; set; }

    public virtual DbSet<CrewType> CrewTypes { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieCrew> MovieCrews { get; set; }

    public virtual DbSet<MovieGenre> MovieGenres { get; set; }

    public virtual DbSet<MovieStatus> MovieStatuses { get; set; }

    public virtual DbSet<Password> Passwords { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ReviewScore> ReviewScores { get; set; }

    public virtual DbSet<ReviewTag> ReviewTags { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserMovie> UserMovies { get; set; }

    public virtual DbSet<UserPassword> UserPasswords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgeRate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("AgeRate_pk");

            entity.ToTable("AgeRate", "ReviewSite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("Description ");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Comment_pk");

            entity.ToTable("Comment", "ReviewSite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.Comment1).HasColumnName("Comment");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

            entity.HasOne(d => d.Author).WithMany(p => p.Comments)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("Comment_User_ID_fk");

            entity.HasOne(d => d.Review).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ReviewId)
                .HasConstraintName("Comment_Review_ID_fk");
        });

        modelBuilder.Entity<Crew>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Crew_pk");

            entity.ToTable("Crew", "ReviewSite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.CompleteFullName)
                .HasMaxLength(152)
                .HasComputedColumnSql("(concat([FirstName],' ',[MiddleName],' ',[LastName]))", false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DeathDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.FullName)
                .HasMaxLength(101)
                .HasComputedColumnSql("(concat([FirstName],' ',[LastName]))", false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
        });

        modelBuilder.Entity<CrewType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("CrewType_pk");

            entity.ToTable("CrewType", "ReviewSite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Genre_pk");

            entity.ToTable("Genre", "ReviewSite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Movie_pk");

            entity.ToTable("Movie", "ReviewSite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AgeRateId).HasColumnName("AgeRateID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.RealeaseDate).HasColumnType("datetime");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.StreamId).HasColumnName("StreamID");
            entity.Property(e => e.TypeId).HasColumnName("TypeID");

            entity.HasOne(d => d.AgeRate).WithMany(p => p.Movies)
                .HasForeignKey(d => d.AgeRateId)
                .HasConstraintName("Movie_AgeRate_ID_fk");

            entity.HasOne(d => d.Status).WithMany(p => p.Movies)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("Movie_Status_ID_fk");
        });

        modelBuilder.Entity<MovieCrew>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MovieCrew_pk");

            entity.ToTable("MovieCrew", "ReviewSite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CrewId).HasColumnName("CrewID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");

            entity.HasOne(d => d.Crew).WithMany(p => p.MovieCrews)
                .HasForeignKey(d => d.CrewId)
                .HasConstraintName("MovieCrew_Crew_ID_fk");

            entity.HasOne(d => d.CrewTypeCodeNavigation).WithMany(p => p.MovieCrews)
                .HasForeignKey(d => d.CrewTypeCode)
                .HasConstraintName("MovieCrew_CrewType_ID_fk");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieCrews)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("MovieCrew_Movie_ID_fk");
        });

        modelBuilder.Entity<MovieGenre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MovieGenre_pk");

            entity.ToTable("MovieGenre", "ReviewSite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");

            entity.HasOne(d => d.Genre).WithMany(p => p.MovieGenres)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("MovieGenre_Genre_ID_fk");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieGenres)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("MovieGenre_Movie_ID_fk");
        });

        modelBuilder.Entity<MovieStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MovieStatus_pk");

            entity.ToTable("MovieStatus", "ReviewSite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Title).HasMaxLength(1);
        });

        modelBuilder.Entity<Password>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Password_pk");

            entity.ToTable("Password", "ReviewSite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LastPassword).HasMaxLength(1);
            entity.Property(e => e.Password1).HasColumnName("Password");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Passwords)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Password_User_ID_fk");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Review_pk");

            entity.ToTable("Review", "ReviewSite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.Review1).HasColumnName("Review");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Author).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("Review_User_ID_fk");

            entity.HasOne(d => d.Movie).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Review_Movie_ID_fk");

            entity.HasOne(d => d.ScoreCodeNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ScoreCode)
                .HasConstraintName("Review___fk");
        });

        modelBuilder.Entity<ReviewScore>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("ReviewScore_pk");

            entity.ToTable("ReviewScore", "ReviewSite");
        });

        modelBuilder.Entity<ReviewTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ReviewTags_pk");

            entity.ToTable("ReviewTag", "ReviewSite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.TagId).HasColumnName("TagID");

            entity.HasOne(d => d.Review).WithMany(p => p.ReviewTags)
                .HasForeignKey(d => d.ReviewId)
                .HasConstraintName("ReviewTags_Review_ID_fk");

            entity.HasOne(d => d.Tag).WithMany(p => p.ReviewTags)
                .HasForeignKey(d => d.TagId)
                .HasConstraintName("ReviewTags_User_ID_fk");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("Role_pk");

            entity.ToTable("Role", "ReviewSite");

            entity.Property(e => e.Code).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Status_pk");

            entity.ToTable("Status", "ReviewSite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Tag_pk");

            entity.ToTable("Tag", "ReviewSite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Tags)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("Tag_User_ID_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pk");

            entity.ToTable("User", "ReviewSite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.FullName)
                .HasMaxLength(101)
                .HasComputedColumnSql("(concat([FirstName],' ',[LastName]))", false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.LockOutEnd).HasColumnType("datetime");
            entity.Property(e => e.PasswordId).HasColumnName("PasswordID");
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.RoleCodeNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleCode)
                .HasConstraintName("User_Role_Code_fk");
        });

        modelBuilder.Entity<UserMovie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("UserMovie_pk");

            entity.ToTable("UserMovie", "ReviewSite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Movie).WithMany(p => p.UserMovies)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserMovie_Movie_ID_fk");

            entity.HasOne(d => d.User).WithMany(p => p.UserMovies)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserMovie_User_ID_fk");
        });

        modelBuilder.Entity<UserPassword>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ID");

            entity.ToTable("UserPassword", "ReviewSite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PasswordId).HasColumnName("PasswordID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Password).WithMany(p => p.UserPasswords)
                .HasForeignKey(d => d.PasswordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserPassword_Password_ID_fk");

            entity.HasOne(d => d.User).WithMany(p => p.UserPasswords)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserPassword_User_ID_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
