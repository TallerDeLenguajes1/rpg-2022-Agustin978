// See https://aka.ms/new-console-template for more information
using JuegoRol.Personaje.modelo;

Console.WriteLine("\n============Torneo de Rol============\n");
Console.WriteLine("Juego en el que cada uno de los personajes de este epico mundo\n lucharan a muerte en diferentes rondas por avanzar y ser consagrados\n como el gran campeon del torneo.");
Console.WriteLine("\n\nMODALIDAD DE JUEGO: El mismo se basa en un conjunto de peleas por tres turnos cada oponente,\n en la cual quien gane recibira mejoras considerables y avnazara en el torneo,\n" +
                    "mientras que el perdedor sera elimindo completamente del torneo.\nLe deseamos la mejor de las suertes!!!");

foreach (var nombre in Enum.GetValues(typeof(Nombre)))
{
    Console.WriteLine(nombre);
}

Console.WriteLine("\n" + Nombre.Dahinia);
//Personaje personaje1 = new Personaje();

int menu()
{
    int opcion = 0;
    Console.WriteLine("********Taberna de la Eleccion********\n");
    do
    {
        Console.WriteLine("1-> Desea que el programa le escoja aleatoriamente la creacion del personaje.\n");
        Console.WriteLine("2-> Desea crear manualmente a su personaje.\n");
        Console.WriteLine("Ingrese una opcion:");
        opcion = int.Parse(Console.ReadLine());
    }while(opcion != 1 || opcion != 2);
    return opcion;
}

/*
Personaje creaPersonajeManual()
{
    Console.WriteLine("\n------Sea bienvenido a la creacion de su personaje------\n");
    Console.WriteLine("Usted podra escoger los aspectos basicos de su personaje (Nombre, Apodo, Tipo, Nacimiento)");
    foreach (var nombre in Enum.GetValues(typeof(Nombre)))
    {
        Console.WriteLine(nombre);
    }
}*/