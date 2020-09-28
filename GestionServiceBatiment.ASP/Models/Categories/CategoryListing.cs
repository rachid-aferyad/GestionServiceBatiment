﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.ASP.Models.Categories
{
    public class CategoryListing
    {
        public int Id { get; set; }
        [DisplayName("Catégorie")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }

        public string NavigationName { get { return Name.Replace(' ', '-'); } }
    }
}