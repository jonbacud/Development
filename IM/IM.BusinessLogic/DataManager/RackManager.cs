using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class RackManager: IBaseManager<Rack>
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

        public void Save(Rack model)
        {
            throw new NotImplementedException();
        }

        public void Save(List<Rack> collection)
        {
            throw new NotImplementedException();
        }

        public void Delete(Rack model)
        {
            throw new NotImplementedException();
        }

        public void Delete(List<Rack> collection)
        {
            throw new NotImplementedException();
        }

        public List<Rack> FetchAll()
        {
            throw new NotImplementedException();
        }

        public Rack FetchById(int key)
        {
            throw new NotImplementedException();
        }

        #region Accessor
        RackAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return RackAccessor.CreateInstance(); }
        }
        #endregion
    }
}
