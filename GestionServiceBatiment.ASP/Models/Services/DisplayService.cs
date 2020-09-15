using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.ASP.Models.Services
{
    public class DisplayService
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURI { get; }
        public DateTime CreationDate { get; set; }
        public string CompanyName { get; set; }
        public string CategoryName { get; set; }
    }
}