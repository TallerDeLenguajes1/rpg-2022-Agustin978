// See https://aka.ms/new-console-template for more information
using JuegoRol.Personaje_modelo;

List<Personaje> personajes = new List<Personaje>();
//List<Personaje> PersonajesContinuan = new List<Personaje>();
main();

int main()
{
    int peleador1, peleador2, numeroCombate = 0;
    Personaje personajeAleatorio;
    Console.WriteLine("\n============Torneo de Rol============\n");
    Console.WriteLine("Juego en el que cada uno de los personajes de este epico mundo\n lucharan a muerte en diferentes rondas por avanzar y ser consagrados\n como el gran campeon del torneo.");
    Console.WriteLine("\n\nMODALIDAD DE JUEGO: El mismo se basa en un conjunto de peleas por tres turnos cada oponente,\n en la cual quien gane recibira mejoras considerables y avnazara en el torneo,\n" +
                        "mientras que el perdedor sera elimindo completamente del torneo.\nLe deseamos la mejor de las suertes!!!");


    if ( menu() == 1)
    {
        Personaje personajePersonal = creaPersonajeManual();
        //Personaje personajeAleatorio;
        personajes.Add(personajePersonal);
        //Console.WriteLine(personajes.Count());

        while (personajes.Count() < 9)
        {
            personajeAleatorio = CreaPersonajeAleatorio();
            if(controlaPersonaje(personajeAleatorio) == 0)
            {
                personajes.Add(personajeAleatorio);
            }
        }
        Console.WriteLine("Los personajes se crearon correctamente.");

    }
    else
    {
        //Personaje personajeAleatorio;
        while (personajes.Count() < 10)
        {
            personajeAleatorio = CreaPersonajeAleatorio();
            if (controlaPersonaje(personajeAleatorio) == 0)
            {
                personajes.Add(personajeAleatorio);
            }
            //Console.WriteLine(personajes.Count());
        }
        Console.WriteLine("Los personajes se crearon correctamente.");
    }


    //Console.WriteLine($"El personaje seleccionado es:\n{personajes[seleccionaPersonaje()].ToString()}");
    Console.WriteLine(personajes.Count);
    while (personajes.Count() > 1)
    {
        numeroCombate++;
        peleador1 = seleccionaPersonajeAPelear();
        do
        {
            peleador2 = seleccionaPersonajeAPelear();
        } while (peleador1 == peleador2);
        Combates(personajes[peleador1], personajes[peleador2], numeroCombate);
    }

    Console.WriteLine("Campeon final de las peleas:\n");
    muestraPersonajes();
    /*
    do
    {
        Personaje personajeElimina = personajes[seleccionaPersonaje()-1];
        //Eliminar
        personajes.Remove(personajeElimina);
        //seleccionaPersonaje();
    }while(personajes.Any());
    */
    

    return 0;
}

int menu()
{
    int opcion;
    Console.WriteLine("********Taberna de la Eleccion********\n");
    do{
        Console.WriteLine("0-> Desea que el programa le escoja aleatoriamente la creacion del personaje.\n");
        Console.WriteLine("1-> Desea crear manualmente a su personaje.\n");
        Console.WriteLine("Ingrese una opcion:");
        opcion = Convert.ToInt32(Console.ReadLine());
    }while(opcion < 0 || opcion > 1);
    return opcion;
}

Personaje creaPersonajeManual()
{
    int opcionTipo = 0, nivel;
    double salud, velocidad, destreza, fuerza, armadura;
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
    /*
    try
    {
        do
        {
            Console.WriteLine("*******Ingrese la fecha de nacimineto de su personaje (yy/mm/dd)*******\n");
            fechaNacimiento = DateTime.Parse(Console.ReadLine());
        } while (CompruebaEdad(fechaNacimiento));

    }catch(Exception)
    {
        Console.WriteLine("La fecha de nacimiento debe tener formato yy/mm/dd\nY asegurese de que su personaje no tenga mas de 300 anos.\nIntente nuevamente.");
    }*/

    do
    {
        Console.WriteLine("*******Ingrese la fecha de nacimineto de su personaje (yy/mm/dd)*******\n");
        fechaNacimiento = new DateTime(1700, 1, 1);
        try
        {
            fechaNacimiento = DateTime.Parse(Console.ReadLine());
        }catch(Exception)
        {
            Console.WriteLine("La fecha de nacimiento debe tener formato yy/mm/dd\nY asegurese de que su personaje no tenga mas de 300 anos.\nIntente nuevamente.");
        }
    } while (CompruebaEdad(fechaNacimiento));

    salud = Math.Round(rand.NextDouble() * 90 + 10, 3);
    velocidad = Math.Round(rand.NextDouble() * 9 + 1, 3);
    destreza = Math.Round(rand.NextDouble() * 4 + 1, 3);
    fuerza = Math.Round(rand.NextDouble() * 9 + 1, 3);
    nivel = rand.Next(1, 11);
    armadura = Math.Round(rand.NextDouble() * 9 + 1, 3);

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

    Personaje personaje = new(tipoPersonaje, nombre, apodo, fechaNacimiento, salud, velocidad, destreza, fuerza, nivel, armadura);
    Console.WriteLine("Personaje creado con exito :)");
    return personaje;
}

Personaje CreaPersonajeAleatorio()
{
    Random rand = new Random();
    int opcionTipo, opcionNombre, opcionApodo, nivel;
    double salud, velocidad, destreza, fuerza, armadura;
    Tipo tipo;
    Nombre nombre;
    Apodo apodo;
    DateTime fechaNacimiento;
    Personaje personaje;
    opcionTipo = rand.Next(11);
    opcionNombre = rand.Next(8);
    opcionApodo = rand.Next(5);

    tipo = (Tipo)opcionTipo;
    nombre = (Nombre)opcionNombre;
    apodo = (Apodo)opcionApodo;
    salud = Math.Round(rand.NextDouble() * 90 + 10, 3);
    velocidad = Math.Round(rand.NextDouble() * 9 + 1, 3);
    destreza = Math.Round(rand.NextDouble() * 4 + 1, 3);
    fuerza = Math.Round(rand.NextDouble() * 9 + 1, 3);
    nivel = rand.Next(0, 11);
    armadura = Math.Round(rand.NextDouble() * 9 + 1, 3);
    //Math.Round(salud, 3);
    /*
    salud = aleatorioA100();
    velocidad = aleatorioA10();
    destreza = aleatorioA5();
    fuerza = aleatorioA10();
    nivel = aleatorioA10();
    armadura = aleatorioA10();
    */
    fechaNacimiento = fechaRandom();
    personaje = new Personaje(tipo, nombre.ToString(), apodo.ToString(), fechaNacimiento, salud, velocidad, destreza, fuerza, nivel, armadura);

    return personaje;
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

DateTime fechaRandom()
{
    DateTime fechaNace;
    Random rand = new Random();
    DateTime start = new DateTime(1722, 1, 1);
    int range = (DateTime.Today - start).Days;
    
    do
    {
        fechaNace = start.AddDays(rand.Next(range));
        //Console.WriteLine(fechaNace.ToString());
    } while (!CompruebaEdad(fechaNace));

    return fechaNace;
}

int controlaPersonaje(Personaje personajeControla)
{
    foreach(var personaje in personajes)
    {
        if(personaje.GetNombre() == personajeControla.GetNombre() && personaje.GetApodo() == personajeControla.GetApodo() && personaje.GetTipo() == personajeControla.GetTipo())
        {
            return 3;
        }else
        {
            if(personaje.GetNombre() == personajeControla.GetNombre() && personaje.GetApodo() == personajeControla.GetApodo())
            {
                return 2;
            }
            
            return 0;
        }
    }
    return 0;
}
/*
int seleccionaPersonaje()
{
    int contador = 1;

    do
    {
        Console.Clear();
        Console.WriteLine("\n********Ingrese el personaje con el que desea participar********");
        Console.WriteLine("\n\n");
        foreach (var personaje in personajes)
        {
            Console.WriteLine($"{++contador})-> " + personaje.ToString() + "\n");
        }
        contador = Convert.ToInt32(Console.ReadLine());
    } while (contador <= 1);

    return contador;
}
*/
void muestraPersonajes()
{
    //Console.Clear();
    Console.WriteLine("\n********Personajes en combate********");
    Console.WriteLine("\n\n");
    foreach (var personaje in personajes)
    {
        Console.WriteLine($"-> " + personaje.ToString() + "\n");
    }
}

void muestraPersonaje(Personaje personajeMuestra)
{
    Console.WriteLine("\n");
    personajeMuestra.ToString();
}

int seleccionaPersonajeAPelear()
{
    Random rand = new Random();
    int peleador = rand.Next(0, personajes.Count()); //Selecciona un personaje aleatorio del listado
    return peleador;
}

//Funciones para las peleas aleatorias
void Combates(Personaje peleador1, Personaje peleador2, int numeroPelea)
{
    double danioProvocado;
    /*
    Random rand = new Random();
    int peleador1, peleador2;
    peleador1 = rand.Next(0,personajes.Count()+1); //Selecciona un personaje aleatorio del listado
    do
    {
        peleador2 = rand.Next(0, 11);
    } while (peleador1 == peleador2);
    */

    for(int i = 0; i < 6; i++)
    {
        if(i%2 == 0)
        {
            danioProvocado = danioProvoca(peleador1, peleador2);
            peleador2.actualizaSalud(danioProvocado);

            if(peleador2.GetSalud() < 0)
            {
                Console.WriteLine($"Campeon de la pelea {numeroPelea}:\n");
                muestraPersonaje(peleador1);
                //PersonajesContinuan.Add(peleador1); //Agrego a una nueva lista a los que van ganando
                //eliminaPersonaje(peleador1); //Elimino de la lista de peleadores pendientes tanto al campeon como al perdedor
                eliminaPersonaje(peleador2);
            } 
        }else
        {
            danioProvocado = danioProvoca(peleador2, peleador1);
            peleador1.actualizaSalud(danioProvocado);

            if(peleador1.GetSalud() < 0)
            {
                Console.WriteLine($"Campeon de la pelea {numeroPelea}:\n");
                muestraPersonaje(peleador2);
                //PersonajesContinuan.Add(peleador2); //Agrego a una nueva lista a los que van ganando
                //eliminaPersonaje(peleador2); //Elimino de la lista de peleadores pendientes tanto al campeon como al perdedor
                eliminaPersonaje(peleador1);
            }
        }
    }

    if(peleador1.GetSalud() > peleador2.GetSalud())
    {
        Console.WriteLine($"Campeon de la pelea {numeroPelea}:\n");
        muestraPersonaje(peleador1);
        //PersonajesContinuan.Add(peleador1);
        //eliminaPersonaje(peleador1);
        eliminaPersonaje(peleador2);
    }else if(peleador1.GetSalud() < peleador2.GetSalud())
    {
        Console.WriteLine($"Campeon de la pelea {numeroPelea}:\n");
        muestraPersonaje(peleador2);
        //PersonajesContinuan.Add(peleador2);
        //eliminaPersonaje(peleador2);
        eliminaPersonaje(peleador1);
    }else
    {
        Console.WriteLine("\n******Se produjo un empate*****\n");
        Console.WriteLine("Los competidores volveran a realizar los combates hasta que uno sea derrotado >:-)");
        Combates(peleador1, peleador2, numeroPelea);
    }
}

double danioProvoca(Personaje DaGolpe, Personaje RecibeGolpe)
{
    double danio = ((DaGolpe.valorAtaque() * DaGolpe.efectividaDisparo()) - RecibeGolpe.poderDefensa()) / DaGolpe.maximoDanio;
    return danio * 100;
}

void eliminaPersonaje(Personaje personajeElimina)
{
    //Personaje personajeAEliminar = personajes[personajeElimina];
    personajes.Remove(personajeElimina);
}