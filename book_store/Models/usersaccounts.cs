using MessagePack;
using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;//data annotations
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace book_store.Models
{
    public class usersaccounts
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [StringLength (25)]
        [System.ComponentModel.DataAnnotations.Required]
        public string name { get; set; }



        [DataType(DataType.Password)]
        ////[Range(1, 10)]
        ////[MaxLength(50)]
        public string pass { get; set; }

        
        public string role { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        //[Range(1, 100)]
        
        [System.ComponentModel.DataAnnotations.Required]
        public string email { get; set; }
        
      



    }
}
