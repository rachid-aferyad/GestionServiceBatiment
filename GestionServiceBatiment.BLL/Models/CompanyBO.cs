﻿using GestionServiceBatiment.BLL.Services.Implementations;
using GestionServiceBatiment.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Models
{
    public class CompanyBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VatNumber { get; set; }
        public string AddressStreet { get; set; }
        public int AddressNumber { get; set; }
        public string AddressMailBox { get; set; }
        public string AddressCity { get; set; }
        public int AddressZipCode { get; set; }
        public string AddressCountry { get; set; }
        public int ContractorId { get; set; }
        public UserBO Contractor { get; set; }
    }
}
