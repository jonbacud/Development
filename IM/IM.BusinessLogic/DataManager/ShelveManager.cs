using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class ShelveManager:IBaseManager<Shelve>
    {
        public int Identity
        {
            get; set;
        }

        public void Save(Shelve shelf)
        {
            if (shelf.Id>0)
            {
                Accessor.Query.Update(shelf);
            }
            else
            {
                Accessor.Query.Insert(shelf);
            }
        }

        public void Save(List<Shelve> shelves)
        {
            foreach (var shelf in shelves)
            {
                Save(shelf);
            }
        }

        public void Delete(Shelve shelf)
        {
            Accessor.Query.Delete(shelf);
        }

        public void Delete(List<Shelve> shelves)
        {
            foreach (var shelf in shelves)
            {
                Delete(shelf);
            }
        }

        public List<Shelve> FetchAll()
        {
            return Accessor.Query.SelectAll<Shelve>() ?? new List<Shelve>();
        }

        public Shelve FetchById(int key)
        {
            return Accessor.Query.SelectByKey<Shelve>(key) ?? new Shelve();
        }

        #region Accessor
        ShelveAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ShelveAccessor.CreateInstance(); }
        }
        #endregion

    }
}
