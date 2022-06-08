using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoRol.Personaje_modelo
{
    internal class Datos
    {
        Tipo tipo;
        string nombre, apodo;
        DateTime fechaNacimiento;
        int edad;
        double salud;

        public Datos(Tipo tipo, string nombre, string apodo, DateTime fechaNacimiento, double salud)
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
            int edad = DateTime.Today.AddTicks(-this.fechaNacimiento.Ticks).Year - 1;
            return edad;
        }
        /*
        public bool controlaEdad(DateTime fechaNacimiento)
        {
            int edad = DateTime.Today.AddTicks(-this.fechaNacimiento.Ticks).Year - 1;
            if(edad > 300)
            {
                return false;
            }
            return true;
        }*/

        public Tipo GetTipo()
        {
            return this.tipo;
        }

        //Metodos getter para obtener informacion del personaje
        public string GetNombre() => this.nombre;
        public string GetApodo() => this.apodo;
        public int GetEdad() => this.edad;
        public double GetSalud() => this.salud;


        public override string ToString() => $"| Nombre: {this.nombre} | Apodo: {this.apodo} | Tipo: {this.apodo} | Edad: {this.edad} | Salud: {this.salud}";
    }
}
