using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPelangganModel;
using Model.DataPelangganModel;

namespace IService
{
    public interface IDataPelangganService
    {
        Task<List<DataPelanggan>> GetAllPelanggan();
        Task Insert(DataPelangganSubmitModel model);
        Task Delete(int id);
        Task Update(int id, DataPelangganSubmitModel model);
        Task<DataPelanggan> SelectById(int id);

    }
}
