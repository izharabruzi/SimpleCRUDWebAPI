using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model.DataPelangganModel
{
    public class DataPelanggan
    {
        public int Id { get; set; }
        public string? Nama { get; set; }
        public bool? Kelamin { get; set; }
        public decimal? Saldo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
