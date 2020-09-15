using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Models
{
    public class CommentBO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Star { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatorId { get; set; }
        public int? CompanyId { get; set; }
        public int? ServiceId { get; set; }
        public int? RequestId { get; set; }

        //private int? CompanyId { get; set; }
        //private CompanyBO _company;
        //public CompanyBO Company
        //{
        //    get
        //    {
        //        if (_company is null)
        //        {
        //            if (!(CompanyId is null))
        //            {
        //                _company = _companyService.GetById((int)CompanyId);
        //            }
        //            else _company = null;
        //        }
        //        return _company;
        //    }
        //    set
        //    {
        //        CompanyId = value.Id;
        //    }
        //}

        //public int? CreatorId { get; set; }
        //private UserBO _creator;
        //public UserBO Creator
        //{
        //    get
        //    {
        //        if (_creator is null)
        //        {
        //            if (!(CreatorId is null))
        //            {
        //                _creator = _userService.GetById((int)CreatorId);
        //            }
        //            else _creator = null;
        //        }
        //        return _creator;
        //    }
        //    set
        //    {
        //        CreatorId = value.Id;
        //    }
        //}

        //private int? ServiceId { get; set; }
        //private ServiceBO _service;
        //public ServiceBO Service
        //{
        //    get
        //    {
        //        if (_service is null)
        //        {
        //            if (!(ServiceId is null))
        //            {
        //                _service = _serviceService.GetById((int)ServiceId);
        //            }
        //            else _service = null;
        //        }
        //        return _service;
        //    }
        //    set
        //    {
        //        ServiceId = value.Id;
        //    }
        //}

        //private int? RequestId { get; set; }
        //private RequestBO _request;
        //public RequestBO Request
        //{
        //    get
        //    {
        //        if (_request is null)
        //        {
        //            if (!(RequestId is null))
        //            {
        //                _request = _requestService.GetById((int)RequestId);
        //            }
        //            else _request = null;
        //        }
        //        return _request;
        //    }
        //    set
        //    {
        //        RequestId = value.Id;
        //    }
        //}

        //private readonly ICompanyService _companyService;
        //private readonly IUserService _userService;
        //private readonly IServiceService _serviceService;
        //public ServiceBO(ICompanyService companyService, IUserService userService, IServiceService serviceService)
        //{
        //    _companyService = companyService;
        //    _userService = userService;
        //    _serviceService = serviceService;
        //}
        //public ServiceBO()
        //{

        //}
    }
}
