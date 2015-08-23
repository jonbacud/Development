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
            get; set;
        }

        public void Save(Location location)
        {
            if (location.Id>0)
            {
                Accessor.Query.Update(location);
            }
            else
            {
                Accessor.Query.Insert(location);
            }
        }

        public void Save(List<Location> locations)
        {
            foreach (var location in locations)
            {
                Save(location);
            }
        }

        public void Delete(Location location)
        {
            Accessor.Query.Delete(location);
        }

        public void Delete(List<Location> locations)
        {
            foreach (var location in locations)
            {
                Delete(location);
            }
        }

        public List<Location> FetchAll()
        {
            return Accessor.Query.SelectAll<Location>() ?? new List<Location>();
        }

        public Location FetchById(int key)
        {
            return Accessor.Query.SelectByKey<Location>(key) ?? new Location();
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
