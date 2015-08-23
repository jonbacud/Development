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
            get; set;
        }

        public void Save(Unit unit)
        {
            if (unit.Id>0)
            {
                Accessor.Query.Update(unit);
            }
            else
            {
                Accessor.Query.Insert(unit);
            }
        }

        public void Save(List<Unit> units)
        {
            foreach (var unit in units)
            {
                Save(unit);
            }
        }

        public void Delete(Unit unit)
        {
            Accessor.Query.Delete(unit);
        }

        public void Delete(List<Unit> units)
        {
            foreach (var unit in units)
            {
                Delete(unit);
            }
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
