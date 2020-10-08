using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herencia
{
    sealed class Piso : Inmueble
    {
        private int nroPiso = 0;

        public int NroPiso { get => nroPiso; set => nroPiso = value; }

        public override float Calcular(float precioBase)
        {
            float precioInmueble = 0.0f;

            precioInmueble = base.Calcular(precioBase);

            if (this.nroPiso >= 3)
                precioInmueble = precioInmueble + (precioInmueble * 0.3f);

            return precioInmueble;
        }
    }
}
