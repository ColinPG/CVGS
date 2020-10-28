using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class EsrbContentDescriptor
    {
        public EsrbContentDescriptor()
        {
            GameEsrbContentDescriptor = new HashSet<GameEsrbContentDescriptor>();
        }

        public int Id { get; set; }
        public string EnglishDescriptor { get; set; }
        public string FrenchDescriptor { get; set; }

        public virtual ICollection<GameEsrbContentDescriptor> GameEsrbContentDescriptor { get; set; }
    }
}
