using GestionServiceBatiment.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Models
{
    public class CommentBO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Star { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CompanyId { get; set; }
        public int? ServiceId { get; set; }
        public int? RequestId { get; set; }
        public int? ParentId { get; set; }
        public int CreatorId { get; set; }
        public UserBO Creator { get; set; }
    }
}
