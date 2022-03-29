using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Contracts
{
    public class Show
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public String Title { get; set; }
        public ShowGenre Genre { get; set; }
        public String DistributionList { get; set; }
        public int NumberOfTickets { get; set; }
        
        [InverseProperty("Show")]
        public List<Ticket> Tickets { get; set; }
    }
    public enum ShowGenre
    {
        Opera = 0,
        Ballet = 1
    }
}
