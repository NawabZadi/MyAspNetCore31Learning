using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Three_Hours_Course.Models
{
    public class Category
    {
        [Key]//
        //inside our models folder, we have created 4 rows of 1 table
        //in models folder we create database files
        public int Id { get; set; } //write prop and click tab 2 times it will create property itself
        [Required]//name is not a nullable poperty
        //[Range(1,100,ErrorMessage ="Display order must be between 1 and 100.")]
        public String Name { get; set; }
        public int displayOrder { get; set; }
        [DisplayName("Display Order")]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;



    }
}
