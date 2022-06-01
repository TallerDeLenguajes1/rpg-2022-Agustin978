using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoRol.Personaje.modelo
{
    internal class Datos
    {
        Tipo tipo;
        string nombre, apodo;
        DateTime fechaNacimiento;
        int edad, salud;

        public Datos(Tipo tipo, string nombre, string apodo, DateTime fechaNacimiento, int salud)
        {
            this.tipo = tipo;
            this.nombre = nombre;
            this.apodo = apodo;
            this.fechaNacimiento = fechaNacimiento;
            this.edad = obtenerEdad();
            this.salud = salud;
        }

        private int obtenerEdad()
        {
            int edad = DateTime.Today.AddTicks(-fechaNacimiento.Ticks).Year - 1;
            return edad;
        }

        public bool controlaEdad(DateTime fechaNacimiento)
        {
            int edad = DateTime.Today.AddTicks(-fechaNacimiento.Ticks).Year - 1;
            if(edad > 300)
            {
                return false;
            }
            return true;
        }
    }
}
