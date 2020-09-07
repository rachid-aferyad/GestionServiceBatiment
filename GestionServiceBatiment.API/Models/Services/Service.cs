using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.API.Models.Services
{
    public class Service
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURI { get; set; }
        public bool Active { get; set; }
        public bool ActivedForValidation { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ValidationDate { get; set; }
        public int CompanyId { get; set; }
        public int? ValidatorId { get; set; }
        public int CategoryId { get; set; }
    }
}