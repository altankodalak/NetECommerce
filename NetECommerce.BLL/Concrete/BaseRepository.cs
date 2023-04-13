using Microsoft.EntityFrameworkCore;
using NetEcommerce.DAL.Context;
using NetECommerce.BLL.Abstract;
using NetECommerce.Common;
using NetECommerce.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace NetECommerce.BLL.Concrete
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {


        private ProjectContext _context;
        private DbSet<T> _entities;
      
        public BaseRepository(ProjectContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
            

        }


        public string Create(T entity)
        {
            try
            {
                entity.CreatedComputerName=WindowsIdentity.GetCurrent().Name;
                entity.CreatedIpAddress=IpAddressFinder.GetHostName();
                entity.Status = Entity.Enum.Status.Inserted;
                _entities.Add(entity);

                _context.SaveChanges();
                return "veri kaydedildi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
           
        }

        public string Delete(T entity)
        {
            try
            {
              
                var deleted = _entities.Find(entity.Id);
                deleted.Status = Entity.Enum.Status.Deleted;
                //entity.State = EntityState.Deleted;
                _context.SaveChanges();
                return "veri silindi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.Where(x => x.Status == Entity.Enum.Status.Inserted || x.Status == Entity.Enum.Status.Updated).AsEnumerable();
        }

        public T GetById(int id)
        {
            var entity = _entities.Find(id);
            return entity;
        }

        public string Update(T entity)
        {
            string result = "";
            try
            {
                switch (entity.Status)
                {
                   
                    case Entity.Enum.Status.Updated:
                        entity.Status = Entity.Enum.Status.Updated;
                        _context.Entry(entity).State= EntityState.Modified;
                        _context.SaveChanges();
                        result = "veri güncellendi";
                        break;
                    case Entity.Enum.Status.Deleted:
                        entity.Status = Entity.Enum.Status.Deleted;
                        _context.SaveChanges();
                        result = "veri silindi!";
                        break;
                 
                }
                return result;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
