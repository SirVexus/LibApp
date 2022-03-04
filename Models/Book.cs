using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Models
{
    public class Book
    {
        public int Id { get; set; }
<<<<<<< Updated upstream
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		[Required]
		public string AuthorName { get; set; }
		[Required]
		public Genre Genre { get; set; }
		[Required]
		[Display(Name="Genre")]
		public byte GenreId { get; set; }
		public DateTime DateAdded { get; set; }
		[Display(Name="Release Date")]
		public DateTime ReleaseDate { get; set; }
		[Display(Name = "Number in Stock")]
		public int NumberInStock { get; set; }
		public int NumberAvailable { get; set; }
=======
		[Required(ErrorMessage = "This field is required")]
		[StringLength(255)]
		public string Name { get; set; }
		[Required(ErrorMessage = "This field is required")]
		public string AuthorName { get; set; }
		[Required]
		public Genre Genre { get; set; }
		[Required(ErrorMessage = "This field is required")]
		public byte GenreId { get; set; }
		[Required(ErrorMessage = "This field is required")]
		[DataType(DataType.Date)]
		public DateTime DateAdded { get; set; }
		[Required(ErrorMessage = "This field is required")]
		[DataType(DataType.Date)]
		public DateTime ReleaseDate { get; set; }
		[Required(ErrorMessage = "This field is required")]
		[Range(1, 20, ErrorMessage = "Value must be in range 1-20")]
		public int NumberInStock { get; set; }
>>>>>>> Stashed changes
	}
      
}
