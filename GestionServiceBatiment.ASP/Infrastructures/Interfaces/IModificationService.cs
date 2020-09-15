using GestionServiceBatiment.ASP.Models;
using GestionServiceBatiment.ASP.Models.Modifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionServiceBatiment.ASP.Infrastructures.Interfaces
{
    public interface IModificationService : IService<int, Modification>
    {
    }
}