using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pidev.Models
{
    public class FormateurModel
    {
    public int id { get; set; }
    public string name { get; set; }
    public string specialite { get; set; }
    public int number { get; set; }
    public string disponibilite { get; set; }

}
}