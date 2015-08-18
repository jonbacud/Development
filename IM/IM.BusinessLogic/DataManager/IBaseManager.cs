using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IM.BusinessLogic.DataManager
{
    public interface IBaseManager<TE> where TE : class
    {
        int Identity { get; set; }
        void Save(TE model);
        void Save(List<TE> collection);
        void Delete(TE model);
        void Delete(List<TE> collection);
        List<TE> FetchAll();
        TE FetchById(int key);
    }
}
