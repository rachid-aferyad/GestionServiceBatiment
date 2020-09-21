﻿using GestionServiceBatiment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Views.Services
{
    public class VServiceDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURI { get; set; }
        public bool Active { get; set; }
        public bool ActivatedForValidation { get; set; }
        public string categoryName { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
