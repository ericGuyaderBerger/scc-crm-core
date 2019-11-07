using Microsoft.Extensions.Configuration;
using SccCrmCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SccCrmCore.Services
{
    public class SqlServerPersistenceLayer : IPersistanceLayer
    {
        private CrmDbContext _context;
        private IConfiguration _config;


        public SqlServerPersistenceLayer(CrmDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<int> deleteSirenAsync(Siren siren)
        {
            _context.Sirens.Remove(siren);
            return await SaveAsync();
        }

        public void deleteSiret(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Siren> getSirens(int page, int pageSize, string numero = null, string nom = null)
        {
            int pageSizeLimit = Convert.ToInt32(_config["Paging:pageSizeLimit"]);
            pageSize = (pageSize > pageSizeLimit) ? pageSizeLimit : pageSize;

            IQueryable<Siren> query = _context.Sirens;
            if ( numero != null )
            {
                query = query.Where(s => s.Numero == numero);
            }

            if (nom != null)
            {
                query = query.Where(s => s.Nom.Contains(nom, StringComparison.CurrentCultureIgnoreCase));
            }

            return query
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<Siret> getSirets(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<Siren> getSirenFromIdAsync(int id)
        {
            return await _context.Sirens.FindAsync(id);
        }

        public async Task<Siret> getSiretFromIdAsync(int id)
        {
            return await _context.Sirets.FindAsync(id);
        }

        public async Task<int> insertSirenAsync(Siren siren)
        {
            await _context.Sirens.AddAsync(siren);
            return await SaveAsync();
        }

        public void insertSiret(Siret siret)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }


    }
}
