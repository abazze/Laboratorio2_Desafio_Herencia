using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herencia
{
    sealed class Local : Inmueble
    {
        private int nroVentanas = 0;

        public int NroVentanas { get => nroVentanas; set => nroVentanas = value; }

        public override float Calcular(float precioBase)
        {
            float precioInmueble = 0.0f;

            precioInmueble = base.Calcular(precioBase);

            if (this.Mts2 > 50)
                precioInmueble = precioInmueble + (precioInmueble * 0.1f);

            if (this.nroVentanas <= 1)
                precioInmueble = precioInmueble - (precioInmueble * 0.2f);

            if (this.nroVentanas > 4)
                precioInmueble = precioInmueble + (precioInmueble * 0.2f);

            return precioInmueble;
        }
    }
}
