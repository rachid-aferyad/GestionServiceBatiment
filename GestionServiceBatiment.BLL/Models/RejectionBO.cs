using GestionServiceBatiment.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Models
{
    public class RejectionBO
    {
        public int Id { get; set; }
        public DateTime RejectionDate { get; set; }
        public string Comment { get; set; }
        public int? RejectorId { get; set; }
        public UserBO Rejector { get; set; }

        public int? ServiceId { get; set; }
        public ServiceBO Service { get; set; }
    }
}
