﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Views.Requests
{
    public class VRequestListing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURI { get; set; }
        public DateTime CreationDate { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CreatorId { get; set; }
        public string CreatorFirstName { get; set; }
        public string CreatorLastName { get; set; }
    }
}
