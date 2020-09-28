using GestionServiceBatiment.ASP.Models.Categories;
using GestionServiceBatiment.ASP.Models.Comments;
using GestionServiceBatiment.ASP.Models.Companies;
using GestionServiceBatiment.ASP.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.ASP.Models.Requests
{
    public class DisplayRequest
    {
        public int Id { get; set; }
        [DisplayName("Titre de la demande")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURI { get; set; }
        [DisplayName("Date de publication")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreationDate { get; set; }
        public int CreatorId { get; set; }
        public DisplayUser Creator { get; set; }
        public int CategoryId { get; set; }
        public DisplayCategory Category { get; set; }
        public IEnumerable<DisplayComment> Comments { get; set; }
        public IEnumerable<CategoryListing> SubCategories { get; set; }
    }
}