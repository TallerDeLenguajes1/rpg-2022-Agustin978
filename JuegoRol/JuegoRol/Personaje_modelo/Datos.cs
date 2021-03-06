using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoRol.Personaje_modelo
{
    internal class Datos
    {
        public Tipo tipo;
        public string nombre, apodo;
        public DateTime fechaNacimiento;
        public int edad;
        public double salud;

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

        //Metodos getter para obtener informacion del personaje
        public Tipo GetTipo() => this.tipo;
        public string GetNombre() => this.nombre;
        public string GetApodo() => this.apodo;
        public int GetEdad() => this.edad;
        public double GetSalud() => this.salud;


        //Metodos Setter
        public double SetSalud(double nuevaSalud) => this.salud = Math.Round(nuevaSalud,3);

        //public override string ToString() => $"| Nombre: {this.nombre} | Apodo: {this.apodo} | Tipo: {this.apodo} | Edad: {this.edad} | Salud: {this.salud}";
    }
}
