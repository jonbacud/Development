using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class CategoryManager:IBaseManager<Category>
    {
        #region Accessor
        CategoryAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return CategoryAccessor.CreateInstance(); }
        }
        #endregion

        public int Identity
        {
            get; set;
        }

        public void Save(Category category)
        {
            if (category.Id>0)
            {
                Accessor.Query.Update(category);
            }
            else
            {
                Accessor.Query.Insert(category);
            }
        }

        public void Save(List<Category> categories)
        {
            foreach (var category in categories)
            {
                Save(category);
            }
        }

        public void Delete(Category category)
        {
            Accessor.Query.Delete(category);
        }

        public void Delete(List<Category> categories)
        {
            foreach (var category in categories)
            {
                Delete(category);
            }
        }

        public List<Category> FetchAll()
        {
            return Accessor.Query.SelectAll<Category>() ?? new List<Category>();
        }

        public Category FetchById(int key)
        {
            return Accessor.Query.SelectByKey<Category>(key) ?? new Category();
        }
    }
}
