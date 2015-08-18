using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public  class LocationManager :IBaseManager<Location>
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

        public void Save(Location model)
        {
            throw new NotImplementedException();
        }

        public void Save(List<Location> collection)
        {
            throw new NotImplementedException();
        }

        public void Delete(Location model)
        {
            throw new NotImplementedException();
        }

        public void Delete(List<Location> collection)
        {
            throw new NotImplementedException();
        }

        public List<Location> FetchAll()
        {
            throw new NotImplementedException();
        }

        public Location FetchById(int key)
        {
            throw new NotImplementedException();
        }

        #region Accessor
        LocationAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return LocationAccessor.CreateInstance(); }
        }
        #endregion
    }
}
