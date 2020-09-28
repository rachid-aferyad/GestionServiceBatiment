using GestionServiceBatiment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Views.Comments
{
    public class VComment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Star { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CompanyId { get; set; }
        public int? ServiceId { get; set; }
        public int? RequestId { get; set; }
        public int? ParentId { get; set; }

        // Contractor
        public int CreatorId { get; set;}
        public string Login {get; set;}
        public string Email {get; set;}
        public string LastName {get; set;}
        public string FirstName {get; set; }

    }
}
