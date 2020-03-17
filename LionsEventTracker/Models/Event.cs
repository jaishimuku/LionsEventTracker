using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LionsEventTracker.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Date is required.")]
        public string Date { get; set; }
       [Required(ErrorMessage = "Time is required.")]       
        public string Time { get; set; }
        [Required(ErrorMessage = "Venue is required.")]
        public string Venue { get; set; }
        [Required(ErrorMessage = "Venue is required.")]
        public string Description { get; set; }
        public string Organization { get; set; }
        public List<EventUser> eventUsers { get; set; }
    }
}
