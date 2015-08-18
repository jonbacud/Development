using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class UnitManager:IBaseManager<Unit>
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

        public void Save(Unit model)
        {
            throw new NotImplementedException();
        }

        public void Save(List<Unit> collection)
        {
            throw new NotImplementedException();
        }

        public void Delete(Unit model)
        {
            throw new NotImplementedException();
        }

        public void Delete(List<Unit> collection)
        {
            throw new NotImplementedException();
        }

        public List<Unit> FetchAll()
        {
            return Accessor.Query.SelectAll<Unit>() ?? new List<Unit>();
        }

        public List<Unit> FetchAll(int departmentId)
        {
            return Accessor.Query.SelectAll<Unit>()
                .Where(u=>u.DepartmentId.Equals(departmentId))
                .OrderBy(u=>u.Description)
                .ToList() ?? new List<Unit>();
        }

        public Unit FetchById(int key)
        {
            return Accessor.Query.SelectByKey<Unit>(key) ?? new Unit();
        }

        #region Accessor
        UnitAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return UnitAccessor.CreateInstance(); }
        }
        #endregion
    }
}
