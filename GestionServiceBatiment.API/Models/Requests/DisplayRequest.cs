using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.API.Models.Requests
{
    public class DisplayRequest
    {
        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public string ImageURI { get; }
        public DateTime CreationDate { get; }
        public int CreatorId { get; }
        public int CategoryId { get; }
    }
}