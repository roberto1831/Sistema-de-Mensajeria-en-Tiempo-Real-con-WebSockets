using System;
using WebSocketSharp.Server;

namespace ServidorWebSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            var wssv = new WebSocketServer("ws://127.0.0.1:7891");
            wssv.AddWebSocketService<Usuario>("/Chat");
            wssv.Start();
            Console.WriteLine("Servidor WebSocket iniciado en ws://127.0.0.1:7891/Chat");

            while (true)
            {
                Console.WriteLine("\n[Selecciona una opcion]");
                Console.WriteLine("1. Listar usuarios");
                Console.WriteLine("2. Enviar mensaje a usuario");
                Console.WriteLine("3. Salir");
                Console.Write(">> ");

                var opcion = Console.ReadLine();
                if (opcion == "1")
                {
                    Usuario.ListarUsuarios();
                }
                else if (opcion == "2")
                {
                    Console.Write("Para: ");
                    var destino = Console.ReadLine();
                    Console.Write("Mensaje: ");
                    var mensaje = Console.ReadLine();
                    Usuario.EnviarMensaje(destino, mensaje);
                }
                else if (opcion == "3")
                {
                    break;
                }
            }

            wssv.Stop();
            Console.WriteLine("Servidor detenido.");
        }
    }
}
