using System;
using WebSocketSharp;

namespace ClienteWebSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingresa tu nombre de usuario para LOGIN: ");
            string nombreUsuario = Console.ReadLine()?.Trim();

            using (WebSocket ws = new WebSocket("ws://127.0.0.1:7891/Chat"))
            {
                ws.OnMessage += (sender, e) =>
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n==============================");
                    Console.WriteLine($"Respuesta del servidor: {e.Data}");
                    Console.ResetColor();
                };

                ws.OnClose += (sender, e) =>
                {
                    Console.WriteLine("\nConexión cerrada por el servidor.");
                };

                ws.Connect();

                string login = $"De: {nombreUsuario}\nLOGIN";
                ws.Send(login);

                Console.WriteLine("\nEscribe tus mensajes (deja campos vacíos o escribe 'salir' para terminar la escritura):");

                while (true)
                {
                    Console.WriteLine("\n======= NUEVO MENSAJE =======");
                    Console.WriteLine($"De: {nombreUsuario}");

                    Console.Write("Para: ");
                    string para = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(para) || para.Equals("salir", StringComparison.OrdinalIgnoreCase))
                        break;

                    Console.Write("\nMensaje: ");
                    string mensaje = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(mensaje) || mensaje.Equals("salir", StringComparison.OrdinalIgnoreCase))
                        break;

                    Console.WriteLine("\n[ENVIAR] Presiona Enter para enviar...");
                    Console.ReadLine();

                    string mensajeCompleto = $"De: {nombreUsuario}\nPara: {para}\nMensaje: {mensaje}";
                    ws.Send(mensajeCompleto);

                    System.Threading.Thread.Sleep(200);
                }

                Console.WriteLine("\nConexión finalizada manualmente. Presiona cualquier tecla para cerrar...");
                Console.ReadKey();
            }
        }
    }
}