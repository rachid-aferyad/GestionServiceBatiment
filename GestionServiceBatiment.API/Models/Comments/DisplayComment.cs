using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.API.Models.Comments
{
    public class DisplayComment
    {
        public int Id { get; }
        public string Content { get; set; }
        public int Star { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatorId { get; set; }
        public int? CompanyId { get; set; }
        public int? ServiceId { get; set; }
        public int? RequestId { get; set; }
    }
}
