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
        Task<ProgrammeSportifResponse> GetProgrammeSportifAsync();
        Task<EntrainementResponse> GetEntrainementAsync(int id);
        Task<bool> SaveUtilisateurAsync( Utilisateur utilisateur, bool isNew = false,int id = 0);
        Task<RepasResponse> GetRepasAsync();
        Task<MaterielResponse> GetMaterielsAsync();
        Task<DefisResponse> GetDefisAsync();
        Task<RepasCategorieResponse> GetRepasCategorieAsync(int id);
        Task<MaterielResponse> GetUtilisateurMaterielsAsync(int idUtilisateur);


    }
}
