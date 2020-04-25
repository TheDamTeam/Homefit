using Homefit.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Homefit.Services.Http
{
    public interface IHttpService
    {
        Task<UtilisateurResponse> GetUtilisateursAsync();
        Task<bool> SaveUtilisateurAsync(Utilisateur utilisateur, bool isNew = false);
    }
}
