using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.API.Models.Requests
{
    public class Request
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURI { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatorId { get; set; }
        public int CategoryId { get; set; }
    }
}