using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    [Table("ZipCode")]
    public class ZipCode
    {
        [Key]
        public int NO { get; set; }

        public int Code { get; set; }

        public string City { get; set; }

        public string Area { get; set; }
    }
}
