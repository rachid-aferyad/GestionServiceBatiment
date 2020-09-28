using GestionServiceBatiment.BLL.Services.Implementations;
using GestionServiceBatiment.BLL.Services.Interfaces;
using GestionServiceBatiment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Models
{
    public class ServiceBO
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
        public CompanyBO Company { get; set; }
        public int? ValidatorId { get; set; }
        public UserBO Validator { get; set; }
        public int CategoryId { get; set; }
        public CategoryBO Category { get; set; }

        public IEnumerable<CommentBO> Comments { get; set; }
    }
}
