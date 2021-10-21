﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Projeto_Inventáro.Models;


namespace Projeto_Inventáro.Services
{
   public interface IUsuarioService


    {



        UsuarioVO Create(UsuarioVO usuario);

        UsuarioVO FindById(int id);

        List<UsuarioVO> FindAll();

        UsuarioVO Update(UsuarioVO usuario);

        void Delete(int id);

        List<UsuarioVO> SetorPesquisar(int id);

        List<UsuarioVO> ComputadorPesquisar(int id);







    }
}
