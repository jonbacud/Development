using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class BinManager :IBaseManager<Bin>
    {
        public int Identity
        {
            get; set;
        }

        public void Save(Bin bin)
        {
            if (bin.Id>0)
            {
                Accessor.Query.Update(bin);
            }
            else
            {
                Accessor.Query.Insert(bin);
            }
        }

        public void Save(List<Bin> bins)
        {
            foreach (var bin in bins)
            {
                Save(bin);
            }
        }

        public void Delete(Bin bin)
        {
            Accessor.Query.Delete(bin);
        }

        public void Delete(List<Bin> bins)
        {
            foreach (var bin in bins)
            {
                Delete(bin);
            }
        }

        public List<Bin> FetchAll()
        {
            return Accessor.Query.SelectAll<Bin>() ?? new List<Bin>();
        }

        public List<Bin> FetchAll(int departmentId)
        {
            return Accessor.Query.SelectAll<Bin>()
                .Where(b=>b.DepartmentId.Equals(departmentId))
                .OrderBy(b=>b.BinDescription)
                .ToList();
        }

        public Bin FetchById(int key)
        {
            return Accessor.Query.SelectByKey<Bin>(key) ?? new Bin();
        }

        #region Accessor
        BinAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return BinAccessor.CreateInstance(); }
        }
        #endregion
    }
}
