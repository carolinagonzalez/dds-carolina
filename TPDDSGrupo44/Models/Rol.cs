﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPDDSGrupo44.Models
{
    public class Rol
    {
        string nombre { get; set; }

        public List<FuncionalidadUsuario> funcionalidades { get; set; }
    }
}