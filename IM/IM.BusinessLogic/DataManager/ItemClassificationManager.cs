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
            get; set;
        }

        public void Save(ItemClassification itemClassification)
        {
            if (itemClassification.Id>0)
            {
                Accessor.Query.Update(itemClassification);
            }
            else
            {
                Accessor.Query.Insert(itemClassification);
            }
        }

        public void Save(List<ItemClassification> itemClassifications)
        {
            foreach (var itemClassification in itemClassifications)
            {
                Save(itemClassification);
            }
        }

        public void Delete(ItemClassification itemClassification)
        {
            Accessor.Query.Delete(itemClassification);
        }

        public void Delete(List<ItemClassification> itemClassifications)
        {
            foreach (var itemClassification in itemClassifications)
            {
                Delete(itemClassification);
            }
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
