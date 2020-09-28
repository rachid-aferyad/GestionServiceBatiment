using GestionServiceBatiment.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Models
{
    public class ModificationBO
    {
        public int Id { get; set; }
        public DateTime ModificationDate { get; set; }
        public int? ServiceId { get; set; }
        public ServiceBO Service { get; set; }
    }
}
