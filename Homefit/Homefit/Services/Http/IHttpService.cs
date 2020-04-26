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
        Task<bool> ParticipeProgrammeSportifAsync(ParticiperProgrammeSportif participerProgrammeSportif);
        Task<bool> SaveUtilisateurAsync(Utilisateur utilisateur, bool isNew = false);
    }
}
