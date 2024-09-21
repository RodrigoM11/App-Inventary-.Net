using DdataAccess;
using Eentities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Bbusiness
{
    public class B_WhereHouse
    {

        public static List<WhereHouseEntity> WherehouseList()
        {
            using (var db = new InventaryContext())
            {
                return db.Wherehouses.ToList();
            }
        }

        public static void CreateWherehouse(WhereHouseEntity oWarehouse)
        {
            using (var db = new InventaryContext())
            {
                db.Wherehouses.Add(oWarehouse);
                db.SaveChanges();
            }
        }

        public static void UpdateWherehouse(WhereHouseEntity oWarehouse)
        {
            using (var db = new InventaryContext())
            {
                db.Wherehouses.Update(oWarehouse);
                db.SaveChanges();
            }
        }

    }
}
