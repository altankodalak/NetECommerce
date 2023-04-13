using Microsoft.EntityFrameworkCore;
using NetECommerce.Entity.Enum;
using NetECommerce.Entity.Interface;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetECommerce.Entity.Base
{
    public abstract class BaseEntity : IEntity<Guid>
    {
        public BaseEntity()
        {
            IsActive = true;
           
            CreatedDate = DateTime.Now;
        }
        public int Id { get ; set ; }

        //todo: Master id doldurulacak.
        public Guid MasterId { get ; set ; }

        public DateTime CreatedDate { get ; set ; }
        //todo: bilgisayar adı veri eklendiğinde otomatik alınacak.
        public string CreatedComputerName { get ; set ; }
        //todo: Ip adresi veri eklendiğinde otomatik alınacak.
        public string CreatedIpAddress { get ; set ; }
        //todo: veri güncellendiğinde tarih doldurulacak.
        public DateTime UpdatedDate { get ; set ; }
        //todo: veri güncellendiğinde bilgisayar adı doldurulacak.
        public string UpdatedComputerName { get ; set ; }
        //todo: veri güncellendiğinde ip adresi doldurulacak.
        public string UpdatedIpAddress { get ; set ; }
        public bool IsActive { get ; set ; }

        public Status Status { get; set; }

        [NotMapped]
        public EntityState State { get; set; }
    }
}
