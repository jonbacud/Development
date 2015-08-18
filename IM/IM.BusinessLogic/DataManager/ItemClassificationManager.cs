using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class ItemClassificationManager:IBaseManager<ItemClassification>
    {
       

        #region Accessor
        ItemClassificationAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ItemClassificationAccessor.CreateInstance(); }
        }
        #endregion

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

        public void Save(ItemClassification model)
        {
            throw new NotImplementedException();
        }

        public void Save(List<ItemClassification> collection)
        {
            throw new NotImplementedException();
        }

        public void Delete(ItemClassification model)
        {
            throw new NotImplementedException();
        }

        public void Delete(List<ItemClassification> collection)
        {
            throw new NotImplementedException();
        }

        public List<ItemClassification> FetchAll()
        {
            return Accessor.Query.SelectAll<ItemClassification>().OrderBy(ic => ic.ClassificationName).ToList() ??
                   new List<ItemClassification>();
        }

        public List<ItemClassification> FetchAll(int departmentId)
        {
            return Accessor.Query.SelectAll<ItemClassification>()
                .Where(ic=>ic.DepartmentId.Equals(departmentId)).ToList() ??
                   new List<ItemClassification>();
        }

        public ItemClassification FetchById(int key)
        {
            return Accessor.Query.SelectByKey<ItemClassification>(key) ?? new ItemClassification();
        }
    }
}
