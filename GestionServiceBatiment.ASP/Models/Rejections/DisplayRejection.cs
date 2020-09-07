using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.ASP.Models.Rejections
{
    public class DisplayRejection
    {
        public int Id { get; set; }
        public string RejectorName { get; set; }
        public string ServiceName { get; set; }
        public DateTime RejectionDate { get; set; }
        public string Comment { get; set; }
    }
}
