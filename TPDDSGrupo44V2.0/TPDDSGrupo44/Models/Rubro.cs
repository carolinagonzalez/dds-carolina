﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPDDSGrupo44.Models
{
    public class Rubro
    {
        public string nombreRubro { get; set; }
        public int radioDeCercania { get; set; }



        //Creo Constructor
        public Rubro(string nombre, int radio)
        {
            this.nombreRubro = nombre;
            this.radioDeCercania = radio;
        }
    }


   

}