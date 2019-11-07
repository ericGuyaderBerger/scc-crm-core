using SccCrmCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SccCrmCore.Services
{
    public interface IPersistanceLayer
    {

        IEnumerable<Siren> getSirens(int page, int pageSize, string numero = null, string nom = null);
        Task<Siren> getSirenFromIdAsync(int id);
        Task<int> insertSirenAsync(Siren siren);
        Task<int> deleteSirenAsync(Siren siren);


        IEnumerable<Siret> getSirets(int page, int pageSize);
        Task<Siret> getSiretFromIdAsync(int id);
        void insertSiret(Siret siret);
        void deleteSiret(int id);

        Task<int> SaveAsync();
    }
}
