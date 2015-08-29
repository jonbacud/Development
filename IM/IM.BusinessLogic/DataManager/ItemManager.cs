using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BLToolkit.Data;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class ItemManager:IBaseManager<Item>
    {
        public int Identity
        {
            get; set;
        }

        public void Save(Item item)
        {
            using (var db = new DbManager())
            {
                if (item.Id>0)
                {
                    Accessor.Query.Update(db, item);
                }
                else
                {
                    Identity = Accessor.Query.InsertAndGetIdentity(db, item);
                }
            }
        }

        public void Save(List<Item> items)
        {
            foreach (var item in items)
            {
                Save(item);
            }
        }

        public void Delete(Item item)
        {
            using (var db = new DbManager())
            {
                Accessor.Query.Delete(db,item);
            }
        }

        public void Delete(List<Item> items)
        {
            foreach (var item in items)
            {
                Delete(item);
            }
        }

        public List<Item> FetchAll()
        {
            return Accessor.Query.SelectAll<Item>() ?? new List<Item>();
        }

        public List<Item> FetchAll(int departmentId)
        {
            return Accessor.Query.SelectAll<Item>()
                .Where(i => i.DepartmentId == departmentId).ToList();
        }

        public List<Item> FetchAll(int departmentId, int classificationId,int typeId)
        {
            return Accessor.Query.SelectAll<Item>()
                .Where(i=>i.DepartmentId.Equals(departmentId) &&
                          i.ClassificationId.Equals(classificationId) && 
                          i.TypeId.Equals(typeId)).ToList();
        }

        public Item FetchById(int key)
        {
            return Accessor.Query.SelectByKey<Item>(key) ?? new Item();
        }

        #region Accessor

        ItemAccessor Accessor
        {
            [DebuggerStepThrough]
            get { return ItemAccessor.CreateInstance(); }
        }
        #endregion
    }
}
