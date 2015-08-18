using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class ItemTypeManager:IBaseManager<ItemType>
    {
        public int Identity
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Save(ItemType model)
        {
            throw new NotImplementedException();
        }

        public void Save(List<ItemType> collection)
        {
            throw new NotImplementedException();
        }

        public void Delete(ItemType model)
        {
            throw new NotImplementedException();
        }

        public void Delete(List<ItemType> collection)
        {
            throw new NotImplementedException();
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
