using Homefit.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Homefit.Services.Data
{
    public interface IDataBase
    {
        #region Utilisateur
        Task<Utilisateur> GetUtilisateurAsync(string email);
        Task<int> SaveUtilisateurAsync(Utilisateur utilisateur);
        Task<int> UpdateUtilisateurAsync(Utilisateur utilisateur);
        Task<Utilisateur> GetUtilisateurIsConnect();
        Task<int> DeleteUtilisateurAsync(Utilisateur utilisateur);
        #endregion

        #region Materiel
        Task<List<Materiel>> GetMaterielsAsync();
        Task<int> SaveMaterielAsync(Materiel materiel);

        #endregion

        #region Aliment
        Task<int> DeleteAlimentAsync(Aliment aliment);
        Task<List<Aliment>> GetAlimentsAsync(string alimRecherche);
        Task<int> SaveAlimentAsync(Aliment aliment);

        #endregion
    }
}
