﻿using BusinessLayer.Interfaces;
using DataLayer.Entityes;
using System.Collections.Generic;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BusinessLayer.Implementations
{
    public class EFDirectorysRepository : IDirectorysRepository
    {
        private EFDBContext context;
        public EFDirectorysRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Directory> GetAllDirectorys(bool includeMaterials = false)
        {
            if (includeMaterials)
                return context.Set<Directory>().Include(x => x.Materials).AsNoTracking().ToList();
            else
                return context.Directory.ToList();
        }

        public Directory GetDirectoryById(int directoryId, bool includeMaterials = false)
        {
            if (includeMaterials)
                return context.Set<Directory>().Include(x => x.Materials).AsNoTracking().FirstOrDefault(x => x.Id == directoryId);
            else
                return context.Directory.FirstOrDefault(x => x.Id == directoryId);
        }

        public void SaveDirectory(Directory directory)
        {
            if (directory.Id == 0)
                context.Directory.Add(directory);
            else
                context.Entry(directory).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteDirectory(Directory directory)
        {
            context.Directory.Remove(directory);
            context.SaveChanges();
        }
    }
}
