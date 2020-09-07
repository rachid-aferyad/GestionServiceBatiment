using GestionServiceBatiment.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Models
{
    public class ModificationBO
    {
        public int Id { get; set; }
        public DateTime ModificationDate { get; set; }
        
        private int? ServiceId { get; set; }
        private ServiceBO _service;
        public ServiceBO Service
        {
            get 
            { 
                if(_service is null)
                {
                    if (!(ServiceId is null))
                    {
                        _service = _serviceService.GetById((int)ServiceId);
                    }
                    else _service = null;
                }
                return _service; 
            }
            set 
            { 
                ServiceId = value.Id; 
            }
        }

        private readonly IServiceService _serviceService;
        public ModificationBO(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        public ModificationBO()
        {

        }
    }
}
