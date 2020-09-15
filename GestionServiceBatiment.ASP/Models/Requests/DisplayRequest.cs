using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.ASP.Models.Requests
{
    public class DisplayRequest
    {
        public int Id { get; set;  }
        public string Title { get; set;}
        public string Description { get; set;}
        public string ImageURI { get; set;}
        public DateTime CreationDate { get; set;}
        public int CreatorId { get; set;}
        public int CategoryId { get; set;}
    }
}