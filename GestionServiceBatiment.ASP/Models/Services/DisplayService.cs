using GestionServiceBatiment.ASP.Models.Categories;
using GestionServiceBatiment.ASP.Models.Comments;
using GestionServiceBatiment.ASP.Models.Companies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.ASP.Models.Services
{
    public class DisplayService
    {
        public int Id { get; set; }
        [DisplayName("Titre du service")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURI { get; set; }
        [DisplayName("Date de publication")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreationDate { get; set; }
        public DisplayCompany Company { get; set; }
        public DisplayCategory Category { get; set; }
        public IEnumerable<DisplayComment> Comments { get; set; }
    }
}