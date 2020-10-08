using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herencia
{
    abstract class Inmueble
    {
        private string direccion = string.Empty;
        private string estado = string.Empty;
        private float mts2 = 0.0f;

        public string Direccion { get => direccion; set => direccion = value; }
        public string Estado { get => estado; set => estado = value; }
        public float Mts2 { get => mts2; set => mts2 = value; }

        public virtual float Calcular(float precioBase)
        {
            float precio = 0.0f;

            if (this.estado == "Nuevo")
                precio = precioBase - (precioBase * 0.1f);
            else
                precio = precioBase - (precioBase * 0.2f);

            return precio;
        }
    }
}
