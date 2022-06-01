// See https://aka.ms/new-console-template for more information
Console.WriteLine("\n============Juego de Rol============\n");


int menu()
{
    int opcion = 0;
    Console.WriteLine("********Taberna de la Eleccion********\n");
    do
    {
        Console.WriteLine("1-> Desea que el programa le escoja aleatoriamente la creacion del personaje.");
        Console.WriteLine("2->");
    }while(opcion <= 0 || opcion > 2);
    return opcion;
}