﻿namespace data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("pidev.ticketOcr")]
    public class TicketOcr
    {
        [Key]
        public int Id { get; set; }

        public string Date { get; set; }
        public string ArticlesDetails { get; set; }
        public string Totale { get; set; }
    }
}
