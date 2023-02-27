using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PembelianModel
{
    public class Pembelian
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? NamaBarang { get; set; }
        public string? Nama { get; set; }
        public int? CustomerId { get; set; }
        public int IdOrder { get; set; }
        public int IdBarang { get; set; }
        public int Saldo { get; set; }
        public int HargaBarang { get; set; }
        public string? Product { get; set; }
        public int? Id { get; set; }

    }
}
