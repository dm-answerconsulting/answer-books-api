using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BooksApi.Data.Models.Mapping
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Books");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.PublishDate).HasColumnName("PublishDate");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.AuthorId).HasColumnName("AuthorId");
            this.Property(t => t.GenreId).HasColumnName("GenreId");

            // Relationships
            this.HasRequired(t => t.Author)
                .WithMany(t => t.Books)
                .HasForeignKey(d => d.AuthorId);
            this.HasRequired(t => t.Genre)
                .WithMany(t => t.Books)
                .HasForeignKey(d => d.GenreId);

        }
    }
}
