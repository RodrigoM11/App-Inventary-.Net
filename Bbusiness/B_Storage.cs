using DdataAccess;
using Eentities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Bbusiness
{
    public class B_Storage
    {
        public static List<StorageEntity> StorageList()
        {
            using (var db = new InventaryContext())
            {
                return db.Storages
                    .Include(s => s.Product)
                    .Include(s => s.WhereHouse)
                    .ToList();
            }
        }

        public static void CreateStorage(StorageEntity oStorage)
        {
            using (var db = new InventaryContext())
            {
                
                
                db.Storages.Add(oStorage);
                db.SaveChanges();

                //return GetStorageById(oStorage.StorageId);
            }
        }

        public static StorageEntity GetStorageById(string id)
        {
            using (var db = new InventaryContext())
            {
                var storage = db.Storages
             .Include(s => s.Product)
             .Include(s => s.WhereHouse)
             .ToList()
             .LastOrDefault(s => s.StorageId == id);

                if (storage == null)
                {
                    throw new InvalidOperationException($"No se encontró el almacenamiento con ID {id}.");
                }

                return storage;


            }
        }

        public static bool IsProductInWarehouse(string id)
        {
            using (var db = new InventaryContext())
            {
                var product = db.Storages.ToList()
                    .Where(p => p.StorageId == id);

                return product.Any();
            }
        }

        public static List<StorageEntity> StorageListByWarehouse(string idWarehouse)
        {
            using (var db = new InventaryContext())
            {
                return db.Storages
                    .Include(s => s.Product)
                    .Include(s => s.WhereHouse)
                    .Where(s => s.WhereHouseId == idWarehouse)
                    .ToList();
            }
        }

        public static void UpdateStorage(StorageEntity oStorage)
        {
            oStorage.LastUpdate = DateTime.Now;

            using (var db = new InventaryContext())
            {
                db.Storages.Update(oStorage);
                db.SaveChanges();
            }
        }

    }
}
