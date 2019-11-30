namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    [Table("pidevrh.calendar")]
    public class calendar
{

    public int CalendarId { get; set; }
    public String NomEvent { get; set; }
    [DataType(DataType.Date)]
    public DateTime DateDebut { get; set; }
    [DataType(DataType.Date)]
    public DateTime DateFin { get; set; }
        
    }
}
