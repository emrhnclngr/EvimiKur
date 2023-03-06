using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get => _createDate; set => _createDate = value; }

        private DateTime _createDate = DateTime.Now;

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool Status { get; set; }
    }
}
