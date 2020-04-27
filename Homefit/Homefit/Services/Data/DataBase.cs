using Homefit.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Homefit.Services.Data
{
    public class DataBase : IDataBase
    {
        readonly SQLiteAsyncConnection _dataBase;

        public DataBase()
        {
            _dataBase = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            _dataBase.CreateTablesAsync(CreateFlags.None, typeof(Utilisateur), typeof(Materiel)).ConfigureAwait(false);
        }

        public Task<List<Materiel>> GetMaterielsAsync()
        {
            return _dataBase.Table<Materiel>().ToListAsync();
        }

        public Task<int> SaveMaterielAsync(Materiel materiel)
        {
            if (materiel.Id != 0)
            {
                return _dataBase.UpdateAsync(materiel);
            }
            else
            {
                return _dataBase.InsertAsync(materiel);
            }
        }
        public Task<int> DeleteAlimentAsync(Aliment aliment)
        {
            throw new NotImplementedException();
        }
        public Task<List<Aliment>> GetAlimentsAsync(string alimRecherche)
        {
            throw new NotImplementedException();
        }
        public Task<int> SaveAlimentAsync(Aliment aliment)
        {
            throw new NotImplementedException();
        }
        public Task<Utilisateur> GetUtilisateurAsync(string email)
        {
            return _dataBase.Table<Utilisateur>()
               .Where(i => i.Email == email)
               .FirstOrDefaultAsync();
        }
        public Task<int> SaveUtilisateurAsync(Utilisateur utilisateur)
        {

            return _dataBase.InsertAsync(utilisateur);
        }
        public Task<int> UpdateUtilisateurAsync(Utilisateur utilisateur)
        {
            return _dataBase.UpdateAsync(utilisateur);
        }
        public Task<Utilisateur> GetUtilisateurIsConnect()
        {
            return _dataBase.Table<Utilisateur>()
               .Where(i => i.IsConnect == 1)
               .FirstOrDefaultAsync();
        }
        public Task<int> DeleteUtilisateurAsync(Utilisateur utilisateur)
        {
            return _dataBase.DeleteAsync(utilisateur);
        }
    }
}
