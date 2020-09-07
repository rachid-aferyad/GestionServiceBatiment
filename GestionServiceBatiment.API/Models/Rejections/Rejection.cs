﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.API.Models.Rejections
{
    public class Rejection
    {
        public int Id { get; set; }
        public int RejectorId { get; set; }
        public int ServiceId { get; set; }
        public DateTime RejectionDate { get; set; }
        public string Comment { get; set; }
    }
}
