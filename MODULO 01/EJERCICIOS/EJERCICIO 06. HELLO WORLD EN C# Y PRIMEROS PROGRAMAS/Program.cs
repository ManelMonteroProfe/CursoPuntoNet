// Este Código Muestra ejemplos de nuestros primeros 
// Programas realizados en el curso de PUNTO NET

// Llamada a las librerias necesarias
using System.Net.Sockets;

// Declaramos variable
int numero;

// Primer programa realizado
Console.WriteLine("Inicio de Programa");
Console.WriteLine("Hola Mundo");
Console.WriteLine("Fin de Programa");



// Siguiente Programa
Console.WriteLine("MULTIPLICADOR POR DOS");

Console.WriteLine("Dime un número");
numero = int.Parse(Console.ReadLine());

// multiplicamos por dos
numero = numero * 2;

//Mostramos resultado
Console.WriteLine("El resultado es");
Console.WriteLine(numero);


// Programa que ilustra el uso del bucle FOR

Console.WriteLine("EJEMPLO DE BUCLE FOR");
// Ejemplo de bucle for
// Un programa que imprima del 1 al 10
for (int i = 1; i <= 10; i++) 
{
    // comentario 
    Console.WriteLine(i);
}

// Programa que ilustra uso de la condición SI ...ENTONCES ...SINO

double ventas = 0;
bool bonus;
if (ventas > 10000)
{
    // Acciones
    bonus = true;
}
else
{
    // Otras acciones
    bonus = false;
}


// Programa que ilustra el uso de la Estructura MIENTRAS
// Programa que ilustra el uso de la Estructura WHILE ...DO

// Hacemos acciones hasta las 22 horas
int horaActual = 14;
while ( horaActual < 22)
{
    // Acciones a relizar
    horaActual++;
}


// Programa que pide un número e imprime su tabla de multiplicar
int tabla;
int producto;
Console.WriteLine("PROGRAMA TABLA DE MULTIPLICAR");

Console.WriteLine("Dime LA TABLA");
tabla = int.Parse(Console.ReadLine());

for (int i = 1; i<=10; i++)
{
    // Una forma de hacerlo
    Console.WriteLine(tabla + " x " + i + " = " + tabla * i);
    
    // otra forma de hacerlo
    producto = tabla * i;
    Console.WriteLine(" {0} x {1}  = {2}", tabla, i, producto);
}



// Programa que ENCUENTRA EL MAYOR DE 3 NUMEROS que se piden
Console.WriteLine("VAMOS A HALLAR EL MAXIMO DE 3 NUMEROS");

// Definimos variables
int numero1;
int numero2;
int numero3;

Console.WriteLine("Dime El NUMERO 1");
numero1 = int.Parse(Console.ReadLine());
Console.WriteLine("Dime El NUMERO 2");
numero2 = int.Parse(Console.ReadLine());
Console.WriteLine("Dime El NUMERO 3");
numero3 = int.Parse(Console.ReadLine());

if (numero1 >= numero2 && numero1 >= numero3)
{
    Console.WriteLine("El mayor es el {0}",numero1);
}
else
{
    if (numero2 >= numero3)
    {
        Console.WriteLine("El mayor es el {0}", numero2);
    }
    else
    {
        Console.WriteLine("El mayor es el {0}", numero3);
    }
}


// Comando para leer. Lo ponemos al final de código 
Console.WriteLine("FIN DE LOS PROGRAMAS. Pulsa tecla para salir");
Console.ReadLine();
