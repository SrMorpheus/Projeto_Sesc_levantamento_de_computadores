using Projeto_Inventáro.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Services
{
    public interface IEquipamentoService
    {






        EquipamentoVO Create(EquipamentoVO equipamentoVO);

        EquipamentoVO FindById(int id);

        List<EquipamentoVO> FindAll();

        EquipamentoVO Update(EquipamentoVO equipamentoVO);

        void Delete(int id);







    }
}
