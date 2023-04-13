using NetECommerce.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetECommerce.Entity.Interface
{
    internal interface IEntity<T>
    {
        
        public int Id { get; set; }
        public T MasterId { get; set; }

        //Created
        public DateTime CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedIpAddress { get; set; }

        //Updated
        public DateTime UpdatedDate { get; set; }
        public string UpdatedComputerName { get; set; }
        public string UpdatedIpAddress { get; set; }
        public Status Status { get; set; }

        public bool IsActive { get; set; }

    }
}
