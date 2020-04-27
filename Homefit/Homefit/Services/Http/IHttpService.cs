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
        Task<APIResponse<Utilisateur>> GetUtilisateursAsync();
        Task<APIResponse<ProgrammeSportif>> GetProgrammeSportifAsync();
        Task<APIResponse<Entrainement>> GetEntrainementAsync(int id);
        Task<bool> SaveUtilisateurAsync( Utilisateur utilisateur, bool isNew = false,int id = 0);
        Task<APIResponse<Repas>> GetRepasAsync();
        Task<APIResponse<Materiel>> GetMaterielsAsync();
        Task<APIResponse<Defis>> GetDefisAsync();
        Task<APIResponse<RepasCategorie>> GetRepasCategorieAsync(int id);
        Task<APIResponse<Materiel>> GetUtilisateurMaterielsAsync(int idUtilisateur);

        Task<bool> ParticipeProgrammeSportifAsync(ParticiperProgrammeSportif participerProgrammeSportif);

        Task<APIResponse<Classement>> GetClassement(int idDefis);
    }
}
