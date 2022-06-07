// See https://aka.ms/new-console-template for more information
using JuegoRol.Personaje_modelo;

Console.WriteLine("\n============Torneo de Rol============\n");
Console.WriteLine("Juego en el que cada uno de los personajes de este epico mundo\n lucharan a muerte en diferentes rondas por avanzar y ser consagrados\n como el gran campeon del torneo.");
Console.WriteLine("\n\nMODALIDAD DE JUEGO: El mismo se basa en un conjunto de peleas por tres turnos cada oponente,\n en la cual quien gane recibira mejoras considerables y avnazara en el torneo,\n" +
                    "mientras que el perdedor sera elimindo completamente del torneo.\nLe deseamos la mejor de las suertes!!!");

/*
foreach (var nombre in Enum.GetValues(typeof(Tipo)))
{
    Console.WriteLine($"{(int)nombre}-> {nombre}");
}*/

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


Personaje creaPersonajeManual()
{
    int opcionTipo = 0, salud, velocidad, destreza, fuerza, nivel, armadura;
    Random rand = new Random();
    DateTime fechaNacimiento;
    string nombre, apodo;
    Tipo tipoPersonaje;
    Console.WriteLine("\n------Sea bienvenido a la creacion de su personaje------\n");
    Console.WriteLine("Usted podra escoger los aspectos basicos de su personaje (Nombre, Apodo, Tipo, Nacimiento)");
    do
    {
        Console.WriteLine("*******Escoja un nombre para su personaje*******\n");
        nombre = Console.ReadLine();
    } while (string.IsNullOrEmpty(nombre));

    do
    {
        Console.WriteLine("*******Escoja un apodo para su personaje*******\n");
        apodo = Console.ReadLine();
    } while (string.IsNullOrEmpty(apodo));

    do
    {
        Console.WriteLine("*******Escoja un Tipo para su personaje*******\n");
        foreach (var tipo in Enum.GetValues(typeof(Tipo)))
        {
            Console.WriteLine($"{(int)tipo}-> {tipo}");
        }
        opcionTipo = Convert.ToInt32(Console.ReadLine());
    } while (opcionTipo < 1 || opcionTipo > 10);

    tipoPersonaje = (Tipo)opcionTipo;

    do
    {
        Console.WriteLine("*******Ingrese la fecha de nacimineto de su personaje (yy/dd/mm)*******\n");
        fechaNacimiento = DateTime.Parse(Console.ReadLine());
    } while (CompruebaEdad(fechaNacimiento));

    salud = rand.Next(10, 101);
    velocidad = rand.Next(1, 11);
    destreza = rand.Next(1, 6);
    fuerza = rand.Next(1, 11);
    nivel = rand.Next(1, 11);
    armadura = rand.Next(1, 11);

    /*
    do
    {
        Console.WriteLine("*******Escoja un apodo para su personaje*******\n");
        foreach(var apodo in Enum.GetValues(typeof(Apodo)))
        {
            Console.WriteLine($"{(int)apodo}-> {apodo}");
        }
        Console.WriteLine("Opcion:");
        opcionApodo = int.Parse(Console.ReadLine());
    } while(opcionApodo < 1 || opcionApodo > 4);
    */

    //Armo el personaje
    Personaje personaje = new Personaje(tipoPersonaje, nombre, apodo, fechaNacimiento, salud, velocidad, destreza, fuerza, nivel, armadura);
    return personaje;
}

Personaje personajeAleatorio()
{
    Random rand = new Random();
    int opcionTipo, opcionNombre, opcionApodo, salud, velocidad, destreza, fuerza, nivel, armadura;
    DateTime fechaNacimiento;
    Personaje personaje;
    //A continuar ._.
}

bool CompruebaEdad(DateTime fechaNace)
{
    int edad = DateTime.Today.AddTicks(-fechaNace.Ticks).Year - 1;
    if (edad > 300)
    {
        return false;
    }
    return true;
}

int aleatorioA5()
{
    Random rand = new Random();
    return rand.Next(1, 6);
}

int aleatorioA10()
{
    Random rand = new Random();
    return rand.Next(1, 11);
}

int aleatorioA100()
{
    Random rand = new Random();
    return rand.Next(1, 101);
}

DateTime fechaRandom()
{
    DateTime fechaNace;
    Random rand = new Random();
    DateTime start = new DateTime(1722, 1, 1);
    int range = (DateTime.Now - start).Days;
    do
    {
        fechaNace = start.AddDays(rand.Next(range));
    } while (CompruebaEdad(fechaNace));

    return fechaNace;
}