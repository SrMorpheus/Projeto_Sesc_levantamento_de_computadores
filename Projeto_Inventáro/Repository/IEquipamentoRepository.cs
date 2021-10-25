using Projeto_Inventáro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Repository
{
        public  interface IEquipamentoRepository
    {


        Equipamento Create(Equipamento equipamento);

        Equipamento FindById(int id);

        List<Equipamento> FindAll();

        Equipamento Update(Equipamento equipamento);

        void Delete(int id);

        bool Exists(int id);




    }
}
