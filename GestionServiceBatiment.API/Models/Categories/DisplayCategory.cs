using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.API.Models.Categories
{
    public class DisplayCategory
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
    }
}
