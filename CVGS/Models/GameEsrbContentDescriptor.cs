using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class GameEsrbContentDescriptor
    {
        public Guid GameGuid { get; set; }
        public int EsrbContentDescriptorId { get; set; }
        public string UserName { get; set; }

        public virtual EsrbContentDescriptor EsrbContentDescriptor { get; set; }
        public virtual Game GameGu { get; set; }
    }
}
