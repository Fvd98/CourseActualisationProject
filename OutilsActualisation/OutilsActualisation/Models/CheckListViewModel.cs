using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutilsActualisation.Models
{
    public class CheckListViewModel<TypeItem,TypeParent>
    {
        public TypeParent Parent { get; set; }
        public List<CheckListItem<TypeItem>> Items { get; set; }
    }
}
