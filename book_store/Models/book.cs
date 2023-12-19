using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace book_store.Models
{
    public class book
    {
       
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]

        public string title { get; set; }


        [DataType(DataType.Text)]

        [Required]
        public string info { get; set; }

        //[Range(1, 100)]
        //[MaxLength(100)]
        //[System.ComponentModel.DataAnnotations.Required]
        public int bookquantity { get; set; }

        public int price { get; set; }


        public int cataid { get; set; }


        //[DataType(DataType.Text)]
        //[StringLength(40)]
        public string author { get; set; }
        
        public string imgfile { get; set; }

    }
}
