﻿using GerenciadorDoacaoSangue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Core.Repositories
{
    public interface IEstoqueSangueRepository
    {
        Task<List<EstoqueSangue>?> ConsultaTodoEstoqueSangue();

    }
}
