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
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void Save(Category model)
        {
            throw new NotImplementedException();
        }

        public void Save(List<Category> collection)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category model)
        {
            throw new NotImplementedException();
        }

        public void Delete(List<Category> collection)
        {
            throw new NotImplementedException();
        }

        public List<Category> FetchAll()
        {
            return Accessor.Query.SelectAll<Category>() ?? new List<Category>();
        }

        public Category FetchById(int key)
        {
            throw new NotImplementedException();
        }
    }
}
