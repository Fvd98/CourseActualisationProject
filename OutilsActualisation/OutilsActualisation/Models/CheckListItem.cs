using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutilsActualisation.Models
{
    public class CheckListItem<TypeItem>
    {
        public bool Checked { get; set; }
        public TypeItem Item { get; set; } 
    }
}
