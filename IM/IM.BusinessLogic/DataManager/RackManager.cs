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
            get; set;
        }

        public void Save(Rack rack)
        {
            if (rack.Id>0)
            {
                Accessor.Query.Update(rack);
            }
            else
            {
                Accessor.Query.Insert(rack);
            }
        }

        public void Save(List<Rack> racks)
        {
            foreach (var rack in racks)
            {
                Save(rack);
            }
        }

        public void Delete(Rack rack)
        {
            Accessor.Query.Delete(rack);
        }

        public void Delete(List<Rack> racks)
        {
            foreach (var rack in racks)
            {
                Delete(rack);
            }
        }

        public List<Rack> FetchAll()
        {
            return Accessor.Query.SelectAll<Rack>() ?? new List<Rack>();
        }

        public List<Rack> FetchAll(int departmentId)
        {
            return Accessor.Query.SelectAll<Rack>()
                .Where(r => r.DepartmentId.Equals(departmentId))
                .OrderBy(r => r.Description)
                .ToList();
        }

        public Rack FetchById(int key)
        {
            return Accessor.Query.SelectByKey<Rack>(key) ?? new Rack();
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
