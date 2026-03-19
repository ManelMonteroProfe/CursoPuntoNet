using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculadora_sinobjetos
{
    internal class Program
    {
        static void Main(string[] args)
        {
                // Variables para guardar los números del usuario.
                // Usamos double si queremos permitir decimales. El examen se puede hacer con enteros solo
                double numero1 = 0;
                double numero2 = 0;

                // Para saber si el usuario ya introdujo números.
                bool numerosCargados = false;

                // 4) Bucle principal: se repite hasta que el usuario elija "t"
                bool salir = false;
                while (!salir)
                {
                // 2) Menú principal
                    Console.WriteLine("=====================================");
                    Console.WriteLine("      CALCULADORA CURSO PUNTO NET     ");
                    Console.WriteLine("=====================================");
                    Console.WriteLine();
                    Console.WriteLine("Introduzca la operación deseada:");
                    Console.WriteLine("  (n) Introducir números");
                    Console.WriteLine("  (+) Suma");
                    Console.WriteLine("  (-) Resta");
                    Console.WriteLine("  (*) Producto");
                    Console.WriteLine("  (/) División");
                    Console.WriteLine("  (t) Terminar");
                    Console.Write("Pulse Opción: ");

                    // Leemos la opción 
                    string opcion = Console.ReadLine();


                   //y la normalizamos Control de errores (trim y minúscula)
                   //if (opcion == null) opcion = "";
                   //opcion = opcion.Trim().ToLower();

                // Decidimos qué hacer según la opción
                switch (opcion)
                    {
                        case "n":
                            // a) Introducir números (n)
                            // Pedimos numero1 y numero2 validando la entrada
                            numero1 = LeerDouble("Numero1: ");
                            numero2 = LeerDouble("Numero2: ");
                            numerosCargados = true;

                            Console.WriteLine("Números Cargados.");
                            Console.WriteLine($"Numero1 = {numero1} | Numero2 = {numero2}");
                            break;

                        case "+":
                        case "-":
                        case "*":
                        case "/":
                            // b) Operación matemática
                            // Antes de operar, comprobamos que haya números cargados
                            if (!numerosCargados)
                            {
                                Console.WriteLine("Primero debe introducir los números con la opción (n).");
                                break;
                            }

                            // 3) Realizamos la operación y mostramos el resultado
                            RealizarOperacion(opcion, numero1, numero2);
                            break;

                        case "t":
                            // c) Terminar (t)
                            salir = true;
                            Console.WriteLine("Aplicación finalizada... ¡FIN DEL PROGRAMA!");
                            break;

                        default:
                            // Opción no reconocida
                            Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                            break;
                    }
                }  // fin del while
        } // FIN DEL PROGRAMA MAIN

        /// Lee un número double desde consola, repitiendo hasta que sea válido.
        static double LeerDouble(string mensaje)
        {
                while (true)
                {
                    Console.Write(mensaje);
                    string texto = Console.ReadLine();

                    // Intentamos convertir el texto a double
                    // Si falla, avisamos y repetimos.
                    double valor;
                    if (double.TryParse(texto, out valor))
                        return valor;

                    Console.WriteLine("Entrada inválida. Escriba un número válido.");
                }
        } // fin metodo leer_double

        /// Realiza la operación indicada con los dos números y muestra el resultado.
        /// Incluye control para división entre cero.
        static void RealizarOperacion(string operador, double a, double b)
        {
                double resultado;

                switch (operador)
                {
                    case "+":
                        resultado = a + b;
                        Console.WriteLine($"Resultado: {a} + {b} = {resultado}");
                        break;

                    case "-":
                        resultado = a - b;
                        Console.WriteLine($"Resultado: {a} - {b} = {resultado}");
                        break;

                    case "*":
                        resultado = a * b;
                        Console.WriteLine($"Resultado: {a} * {b} = {resultado}");
                        break;

                    case "/":
                        // Control de división por cero
                        if (b == 0)
                        {
                            Console.WriteLine("No se puede dividir entre cero.");
                        }
                        else
                        {
                            resultado = a / b;
                            Console.WriteLine($"Resultado: {a} / {b} = {resultado}");
                        }
                        break;
                }
        } // Fin Metodo Realizar Operación

    }
}
