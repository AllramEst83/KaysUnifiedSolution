﻿using DataBaseAPI.Constants;
using DataBaseAPI.Data.Entities.Context;
using DataBaseAPI.Interfaces;
using DataBaseAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseAPI.DataAccess
{
    public class UnicornRepository : IUnicornRepository
    {
        public UnicornContext _context { get; }

        public UnicornRepository(UnicornContext context)
        {
            _context = context;
        }

        //---

        public async Task<bool> UnicornsExist() => await _context.Unicorns.AnyAsync();

        public async Task<bool> HornTypesExist() => await _context.HornTypes.AnyAsync();

        public async Task<List<Unicorn>> GetAllUnicorns() => await _context.Unicorns.Where(x => x.IsDeleted == CommonConstants.Fasle).Include(x => x.HornType).ToListAsync();

        public async Task<Unicorn> GetUnicornByGuid(Guid id) => await _context.Unicorns.Where(x => x.Id == id).Include(x => x.HornType).FirstOrDefaultAsync();

        public async Task<List<HornType>> GetAllHornTypes() => await _context.HornTypes.ToListAsync();

        public async Task<HornType> GetHornTypeByGuid(Guid id) => await _context.HornTypes.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> UnicornExistsById(Guid id) => await _context.Unicorns.AnyAsync(x => x.Id == id);

        public async Task<bool> HornTypeExistsById(Guid id) => await _context.HornTypes.AnyAsync(x => x.Id == id);

        public async Task<Unicorn> AddUnicorn(Unicorn unicornToAdd)
        {
            unicornToAdd = SetDateOfBirth(unicornToAdd);

            var hornTypeInContext = await _context.HornTypes.FindAsync(unicornToAdd.HornType.Id);
            unicornToAdd.HornType = hornTypeInContext;

            await _context.Unicorns.AddAsync(unicornToAdd);
            await _context.SaveChangesAsync();

            return unicornToAdd;
        }

        public async Task<Unicorn> UpdateUnicorn(Unicorn unicornToUpdate)
        {
            _context.Unicorns.Update(unicornToUpdate);
            await _context.SaveChangesAsync();

            return unicornToUpdate;
        }

        public Unicorn SetDateOfBirth(Unicorn unicornToAdd)
        {
            unicornToAdd.DateOfBirth = DateTime.Now;

            return unicornToAdd;
        }

        public async Task<Unicorn> DeleteUnicorn(Guid Id)
        {
            var unicornToDelete = await _context.Unicorns
                .Where(x => x.Id == Id)
                .Include(x => x.HornType)
                .FirstOrDefaultAsync();

            if (unicornToDelete.IsDeleted == true || unicornToDelete.IsSold == true)
            {
                return unicornToDelete;
            }

            var hornTypeContext = await _context.HornTypes.FindAsync(unicornToDelete.HornType.Id);

            unicornToDelete.HornType = hornTypeContext;
            unicornToDelete.IsDeleted = CommonConstants.True;

            _context.Unicorns.Update(unicornToDelete);
            await _context.SaveChangesAsync();

            return unicornToDelete;
        }


    }
}
