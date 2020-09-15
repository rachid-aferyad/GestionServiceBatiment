using GestionServiceBatiment.ASP.Models;
using GestionServiceBatiment.ASP.Models.Rejections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionServiceBatiment.ASP.Infrastructures.Interfaces
{
    public interface IRejectionService : IService<int, Rejection>
    {
    }
}