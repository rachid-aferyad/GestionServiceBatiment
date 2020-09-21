using GestionServiceBatiment.ASP.Models.Categories;
using GestionServiceBatiment.ASP.Models.Comments;
using GestionServiceBatiment.ASP.Models.Companies;
using GestionServiceBatiment.ASP.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.ASP.Models.Requests
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
        public User Creator { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}