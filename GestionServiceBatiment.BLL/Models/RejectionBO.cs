using GestionServiceBatiment.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Models
{
    public class RejectionBO
    {
        public int Id { get; set; }
        public DateTime RejectionDate { get; set; }
        public string Comment { get; set; }
        
        public int? RejectorId { get; set; }
        private UserBO _rejector;
        public UserBO Rejector
        {
            get
            { 
                if(_rejector is null)
                {
                    if (!(RejectorId is null))
                    {
                        _rejector = _userService.GetById((int)RejectorId);
                    }
                    else _rejector = null;
                }
                return _rejector; 
            }
            set 
            { 
                Rejector = value; 
            }
        }

        public int? ServiceId { get; set; }
        private ServiceBO _service;
        public ServiceBO Service
        {
            get 
            { 
                if(_service is null)
                {
                    if(!(ServiceId is null))
                    {
                        _service = _serviceService.GetById((int)ServiceId);
                    }
                }
                return _service; 
            }
            set 
            { 
                _service = value; 
            }
        }

        private readonly IUserService _userService;
        private readonly IServiceService _serviceService;
        public RejectionBO(IUserService userService, IServiceService serviceService)
        {
            _userService = userService;
            _serviceService = serviceService;
        }
        public RejectionBO()
        {

        }
    }
}
