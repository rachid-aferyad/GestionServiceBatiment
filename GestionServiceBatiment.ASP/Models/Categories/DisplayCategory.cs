using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.ASP.Models.Categories
{
    public class DisplayCategory
    {
        public int Id { get; }
        //[DisplayName("Nom")]
        public string Name { get; }
        public string Description { get; }
    }
}
