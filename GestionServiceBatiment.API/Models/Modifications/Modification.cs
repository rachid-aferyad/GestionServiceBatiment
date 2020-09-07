using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.API.Models.Modifications
{
    public class Modification
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
