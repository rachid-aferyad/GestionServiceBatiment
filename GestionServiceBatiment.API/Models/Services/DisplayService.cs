using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.API.Models.Services
{
    public class DisplayService
    {
        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public string ImageURI { get; }
        public DateTime CreationDate { get; }
        public string CompanyName { get; }
        public string CategoryName { get; }
    }
}