using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            using (DbManager db = new DbManager())
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

        public void Delete(Item model)
        {
            throw new NotImplementedException();
        }

        public void Delete(List<Item> collection)
        {
            throw new NotImplementedException();
        }

        public List<Item> FetchAll()
        {
            return Accessor.Query.SelectAll<Item>() ?? new List<Item>();
        }

        public List<Item> FetchAll(int departmentId, int classificationId,int typeId)
        {
            return Accessor.Query.SelectAll<Item>()
                .Where(i=>i.DepartmentId.Equals(departmentId) &&
                    i.ClassificationId.Equals(classificationId) && 
                    i.TypeId.Equals(typeId)).ToList()
                ?? new List<Item>();
        }

        public Item FetchById(int key)
        {
            return Accessor.Query.SelectByKey<Item>(key) ?? new Item();
        }

        #region Accessor

        ItemAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ItemAccessor.CreateInstance(); }
        }
        #endregion
    }
}
