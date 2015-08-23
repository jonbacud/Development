using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class ItemTypeManager:IBaseManager<ItemType>
    {
        public int Identity
        {
            get; set; 
        }

        public void Save(ItemType itemType)
        {
            using (DbManager db = new DbManager())
            {
                if (itemType.Id>0)
                {
                    Accessor.Query.Update(db, itemType); 
                }
                else
                {
                    Accessor.Query.Insert(db, itemType);
                }
            }
        }

        public void Save(List<ItemType> itemTypes)
        {
            foreach (var itemType in itemTypes)
            {
                Save(itemType);
            }
        }

        public void Delete(ItemType itemType)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, itemType);
            }
        }

        public void Delete(List<ItemType> itemTypes)
        {
            foreach (var itemType in itemTypes)
            {
                Delete(itemType);
            }
        }

        public List<ItemType> FetchAll()
        {
            return Accessor.Query.SelectAll<ItemType>().OrderBy(it => it.ItemDesciption).ToList() ??
                   new List<ItemType>();
        }

        public List<ItemType> FetchAll(int departmentId)
        {
            return Accessor.Query.SelectAll<ItemType>()
                .Where(it=>it.DepartmentId.Equals(departmentId))
                .OrderBy(it => it.ItemDesciption).ToList() ??
                   new List<ItemType>();
        }

        public ItemType FetchById(int key)
        {
            return Accessor.Query.SelectByKey<ItemType>(key) ?? new ItemType();
        }

        #region Accessor
        ItemTypeAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ItemTypeAccessor.CreateInstance(); }
        }
        #endregion
    }
}
