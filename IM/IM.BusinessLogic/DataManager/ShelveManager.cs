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
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void Save(Shelve model)
        {
            throw new NotImplementedException();
        }

        public void Save(List<Shelve> collection)
        {
            throw new NotImplementedException();
        }

        public void Delete(Shelve model)
        {
            throw new NotImplementedException();
        }

        public void Delete(List<Shelve> collection)
        {
            throw new NotImplementedException();
        }

        public List<Shelve> FetchAll()
        {
            throw new NotImplementedException();
        }

        public Shelve FetchById(int key)
        {
            throw new NotImplementedException();
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
