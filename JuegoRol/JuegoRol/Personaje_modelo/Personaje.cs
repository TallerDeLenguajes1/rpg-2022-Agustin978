﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoRol.Personaje_modelo
{
    internal class Personaje : Datos
    {

        private double velocidad, destreza, fuerza, nivel, armadura;

        //Constructor de la clase personaje
        public Personaje(Tipo tipo, string nombre, string apodo, DateTime fechaNacimiento, double salud, double velocidad, double destreza, double fuerza, double nivel, double armadura) : base(tipo, nombre, apodo, fechaNacimiento, salud)
        {
            this.velocidad = velocidad;
            this.destreza = destreza;
            this.fuerza = fuerza;
            this.nivel = nivel;
            this.armadura = armadura;
        }

        //Metodos getter para obtener la ingormacion del personaje
        public double GetVelocidad() => this.velocidad;
        public double GetDestreza() => this.destreza;
        public double GetFuerza() => this.fuerza;
        public double GetNivel() => this.nivel;
        public double GetArmadura() => this.armadura;

        //Metodos setter para ingresar los datos luego de la pelea
        //public void SetVelocidad()=> 

        public override string ToString() => $"| Velocidad: {this.velocidad} | Destreza: {this.destreza} | Fuerza: {this.fuerza} | Nivel: {this.nivel} | Armadura: {this.armadura}";

    }
}
