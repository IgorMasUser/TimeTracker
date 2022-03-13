using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TimeTracker.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; } 

        public int UserId{ get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime Started { get; set; }

        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime Finished { get; set; }

        //[DisplayFormat(DataFormatString = "{0:t}")]
        //public DateTime Break { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime TotalWorked { get; set; } 
    }
}
