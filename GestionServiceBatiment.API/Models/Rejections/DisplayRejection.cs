using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.API.Models.Rejections
{
    public class DisplayRejection
    {
        public int Id { get; }
        public string RejectorName { get; }
        public string ServiceName { get; }
        public DateTime RejectionDate { get; }
        public string Comment { get; }
    }
}
