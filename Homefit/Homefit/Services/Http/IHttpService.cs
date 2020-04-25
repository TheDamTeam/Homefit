using Homefit.Models;
using Homefit.Models.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Homefit.Services.Http
{
    public interface IHttpService
    {
        Task<UtilisateurResponse> GetUtilisateursAsync();
        Task<bool> SaveUtilisateurAsync( Utilisateur utilisateur, bool isNew = false,int id = 0);

        Task<MaterielResponse> GetMaterielsAsync();

        Task<MaterielResponse> GetUtilisateurMaterielsAsync(int idUtilisateur);

    }
}
