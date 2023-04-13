using NetECommerce.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetECommerce.BLL.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        //List
        IEnumerable<T> GetAll();

        //Create
        string Create(T entity);

        //Update
        string Update(T entity);    

        //Delete
        string Delete(T entity);

        //Find
        T GetById(int id);
    }
}
