using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoRol.Personaje_modelo
{
    internal class Personaje : Datos
    {

        private int velocidad, destreza, fuerza, nivel, armadura;

        //Constructor de la clase personaje
        public Personaje(Tipo tipo, string nombre, string apodo, DateTime fechaNacimiento, int salud, int velocidad, int destreza, int fuerza, int nivel, int armadura) : base(tipo, nombre, apodo, fechaNacimiento, salud)
        {
            this.velocidad = velocidad;
            this.destreza = destreza;
            this.fuerza = fuerza;
            this.nivel = nivel;
            this.armadura = armadura;
        }

        public override string ToString() => $"| Velocidad: {this.velocidad} | Destreza: {this.destreza} | Fuerza: {this.fuerza} | Nivel: {this.nivel} | Armadura: {this.armadura}";

    }
}
