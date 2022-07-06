using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoRol.Personaje_modelo
{
    internal class Personaje : Datos
    {

        public double velocidad, destreza, fuerza, armadura, PD;
        public int maximoDanio = 50000;
        public int nivel;

        //Constructor de la clase personaje
        public Personaje(Tipo tipo, string nombre, string apodo, DateTime fechaNacimiento, double salud, double velocidad, double destreza, double fuerza, int nivel, double armadura) : base(tipo, nombre, apodo, fechaNacimiento, salud)
        {
            this.velocidad = velocidad;
            this.destreza = destreza;
            this.fuerza = fuerza;
            this.nivel = nivel;
            this.armadura = armadura;
            this.PD = poderDisparo();
            //this.efectividad = efectividaDisparo();
        }

        //Metodos getter para obtener la ingormacion del personaje
        public double GetVelocidad() => this.velocidad;
        public double GetDestreza() => this.destreza;
        public double GetFuerza() => this.fuerza;
        public int GetNivel() => this.nivel;
        public double GetArmadura() => this.armadura;

        //Metodos setter para ingresar los datos luego de la pelea
        public double SetFuerza(double fuerzaActualizada) => this.fuerza = Math.Round(fuerzaActualizada,3);
        public int SetNivel(int aumentaNivel) => this.nivel = aumentaNivel;
        public double SetVelocidad(double aumentaVelocidad) => this.velocidad = Math.Round(aumentaVelocidad,3);

        //Funciones para pelea

        public double poderDisparo() => Math.Round(this.destreza * this.fuerza * this.nivel , 3);

        public int efectividaDisparo()
        {
            Random rand = new Random();
            int efectividad = rand.Next(0,101);
            return efectividad;
        }

        public double valorAtaque() => Math.Round(this.PD * this.efectividaDisparo(),3);
        public double poderDefensa() => Math.Round(this.armadura * this.velocidad,3);

        public void actualizaSalud(double danioRecibido)
        {
            double saludActualizada = this.GetSalud();
            saludActualizada -= danioRecibido;
            this.SetSalud(saludActualizada);
        }

        public override string ToString() => $"| Nombre: {GetNombre()} | Apodo: {GetApodo()} | Tipo: {GetTipo()} | Edad: {GetEdad()} Años| Salud: {GetSalud()} | Velocidad: {this.velocidad} | Destreza: {this.destreza} | Fuerza: {this.fuerza} | Nivel: {this.nivel} | Armadura: {this.armadura}";

    }
}
