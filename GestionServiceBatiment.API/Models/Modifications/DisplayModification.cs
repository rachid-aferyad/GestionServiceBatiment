using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.API.Models.Modifications
{
    public class DisplayModification
    {
        public int Id { get; }
        public string ServiceName { get; }
        public DateTime ModificationDate { get; }
    }
}
