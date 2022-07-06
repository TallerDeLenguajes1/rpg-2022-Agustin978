// See https://aka.ms/new-console-template for more information
using JuegoRol.Personaje_modelo;
using JuegoRol.funciones_personaje;
using Newtonsoft.Json;

List<Personaje> personajes = new List<Personaje>();
//List<Personaje> PersonajesContinuan = new List<Personaje>();
main();

int main()
{
    int peleador1, peleador2, numeroCombate = 0;
    Personaje personajeAleatorio;
    string path = @"C:\Cursos\Programacion_en_C_UNT\Taller_de_Lenguajes\rpg-2022-Agustin978\JuegoRol\JuegoRol\jugadores";
    string formato = ".json";
    string personajesAlmacenados;
    Console.WriteLine("\n============Torneo de Rol============\n");
    Console.WriteLine("Juego en el que cada uno de los personajes de este epico mundo\n lucharan a muerte en diferentes rondas por avanzar y ser consagrados\n como el gran campeon del torneo.");
    Console.WriteLine("\n\nMODALIDAD DE JUEGO: El mismo se basa en un conjunto de peleas por tres turnos cada oponente,\n en la cual quien gane recibira mejoras considerables y avnazara en el torneo,\n" +
                        "mientras que el perdedor sera elimindo completamente del torneo.\n");


    if (menu(path, formato) == 1)
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
    else if(menu(path, formato) == 0)
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
    }else
    {
        //Colocar funciones para cargar los personajes desde el archivo json
        personajesAlmacenados = Funciones.GetObjectJsonFromFile(path, formato);
        cargaDesdeJson(personajesAlmacenados);
    }

    //Almaceno los personajes creados en archivo jugadores.json
    Funciones.SerializeObjectJson(personajes, path, formato);

    Console.WriteLine("\n********Personajes en combate********\n");
    muestraPersonajes();
    Console.WriteLine("\n\n");

    while (personajes.Count() > 1)
    {
        numeroCombate++;
        peleador1 = seleccionaPersonajeAPelear();
        do
        {
            peleador2 = seleccionaPersonajeAPelear();
        } while (peleador1 == peleador2);
        //Console.WriteLine("\n***Personajes que pelearan***\n");
        //muestraPersonaje(personajes[peleador1]);
        //muestraPersonaje(personajes[peleador2]);
        Combates(personajes[peleador1], personajes[peleador2], numeroCombate);
    }

    Console.WriteLine("\n\n=========================Campeon final de los combates=========================\n");
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

int menu(string path, string formato)
{
    int opcion;
    Console.WriteLine("********Taberna de la Eleccion********\n");
    do{
        Console.WriteLine("0-> Desea que el programa le escoja aleatoriamente la creacion del personaje.\n");
        Console.WriteLine("1-> Desea crear manualmente a su personaje.\n");
        if(File.Exists(path+formato))
        {
            Console.WriteLine("2-> Desea que se carguen los personajes almacenados anteriormente.\n");
        }
        Console.WriteLine("Ingrese una opcion:");
        opcion = Convert.ToInt32(Console.ReadLine());
    }while(opcion < 0 || opcion > 2);
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

    salud = 100;
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
    salud = 100.0;
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
    Console.WriteLine("\n");
    foreach (var personaje in personajes)
    {
        Console.WriteLine($"-> " + personaje.ToString() + "\n");
    }
}

void muestraPersonaje(Personaje personajeMuestra)
{
    Console.WriteLine("\n");
    Console.WriteLine($"-> {personajeMuestra.ToString()}");
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

            if(peleador2.GetSalud() <= 0)
            {
                Console.WriteLine($"\n=============Campeon de la pelea {numeroPelea}=============\n");
                muestraPersonaje(peleador1);
                aplicaBonus(peleador1);
                //PersonajesContinuan.Add(peleador1); //Agrego a una nueva lista a los que van ganando
                //eliminaPersonaje(peleador1); //Elimino de la lista de peleadores pendientes tanto al campeon como al perdedor
                Console.WriteLine("\n***Perdedor del combate***");
                muestraPersonaje(peleador2);
                eliminaPersonaje(peleador2);
                return;
            } 
        }else
        {
            danioProvocado = danioProvoca(peleador2, peleador1);
            peleador1.actualizaSalud(danioProvocado);

            if(peleador1.GetSalud() <= 0)
            {
                Console.WriteLine($"\n=============Campeon de la pelea {numeroPelea}=============\n");
                muestraPersonaje(peleador2);
                aplicaBonus(peleador2);
                //PersonajesContinuan.Add(peleador2); //Agrego a una nueva lista a los que van ganando
                //eliminaPersonaje(peleador2); //Elimino de la lista de peleadores pendientes tanto al campeon como al perdedor
                Console.WriteLine("\n***Perdedor del combate***");
                muestraPersonaje(peleador1);
                eliminaPersonaje(peleador1);
                return;
            }
        }
    }

    if(peleador1.GetSalud() > peleador2.GetSalud())
    {
        Console.WriteLine($"\n=============Campeon de la pelea {numeroPelea}=============\n");
        muestraPersonaje(peleador1);
        aplicaBonus(peleador1);
        //PersonajesContinuan.Add(peleador1);
        //eliminaPersonaje(peleador1);
        Console.WriteLine("\n***Perdedor del combate***");
        muestraPersonaje(peleador2);
        eliminaPersonaje(peleador2);
        return;
    }
    else if(peleador1.GetSalud() < peleador2.GetSalud())
    {
        Console.WriteLine($"\n=============Campeon de la pelea {numeroPelea}=============\n");
        muestraPersonaje(peleador2);
        aplicaBonus(peleador2);
        //PersonajesContinuan.Add(peleador2);
        //eliminaPersonaje(peleador2);
        Console.WriteLine("\n***Perdedor del combate***");
        muestraPersonaje(peleador1);
        eliminaPersonaje(peleador1);
        return;
    }
    else
    {
        Console.WriteLine("\n******Se produjo un empate*****\n");
        Console.WriteLine("Los competidores volveran a realizar los combates hasta que uno sea derrotado >:-)");
        Combates(peleador1, peleador2, numeroPelea);
    }
}

double danioProvoca(Personaje DaGolpe, Personaje RecibeGolpe)
{
    double danio = ((DaGolpe.valorAtaque() * DaGolpe.efectividaDisparo()) - RecibeGolpe.poderDefensa()) / DaGolpe.maximoDanio;
    return Math.Round(danio,3);
}

void eliminaPersonaje(Personaje personajeElimina)
{
    //Personaje personajeAEliminar = personajes[personajeElimina];
    personajes.Remove(personajeElimina);
}

void aplicaBonus(Personaje campeon)
{
    double salud, fuerzaMejorada, velocidadMejorada;
    if(campeon.GetSalud() < 50) //En caso de tener menos de la mitad de la vida se le da un bonus de 20 puntos de vida mas
    {
        salud = campeon.GetSalud() + 20;
        campeon.SetSalud(salud);
    }

    fuerzaMejorada = campeon.GetFuerza() + (campeon.GetFuerza() * 5) / 100;  //Tiene un incremento del 5% en la fuerza del personaje
    campeon.SetFuerza(fuerzaMejorada);

    if(campeon.GetNivel() < 10)  //En caso de no haber llegado al maximo nivel, se le incrementa 1 nivel mas, y con ello mejora el poder de disparo y por lo tanto el valor del ataque
    {
        campeon.SetNivel(campeon.GetNivel() + 1);
    }

    velocidadMejorada = campeon.GetVelocidad() + (campeon.GetVelocidad() * 10) / 100; //Tiene un incremento del 10% en la velocidad y por lo tanto un pequeño incremento al defenderse
    campeon.SetVelocidad(velocidadMejorada);
}

void cargaDesdeJson(string elementosJson)
{
    List<Personaje> lista = JsonConvert.DeserializeObject<List<Personaje>>(elementosJson);
    foreach(var elemento in lista)
    {
        personajes.Add(elemento);
    }
    lista.Clear(); //Libero la memoria que use para crear la lista
}