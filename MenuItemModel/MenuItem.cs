using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.MenuItemModel
{
    public class MenuItem
    {
        public int IdBarang { get; set; }
        public string? NamaBarang { get; set; }
        public int? JumlahBarang { get; set; }
        public decimal? HargaBarang { get; set; }
        public DateTime? CreatedBarang { get; set; }
        public DateTime? UpdatedBarang { get; set; }
    }
}
