using System;
using System.Collections.Concurrent;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace ServidorWebSocket
{
    public class Usuario : WebSocketBehavior
    {
        private static readonly ConcurrentDictionary<string, Usuario> usuarios = new();
        private string nombreUsuario = "";

        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine($"[Recibido] {e.Data}");

            if (e.Data.StartsWith("De:") && e.Data.Contains("LOGIN"))
            {
                string[] lineas = e.Data.Split('\n');
                foreach (string linea in lineas)
                {
                    if (linea.StartsWith("De:"))
                    {
                        nombreUsuario = linea.Substring(3).Trim();
                        usuarios[nombreUsuario] = this;
                        Console.WriteLine($"Usuario conectado: {nombreUsuario}");
                        Send($"Bienvenido, {nombreUsuario}");
                        return;
                    }
                }
            }
            else if (e.Data.StartsWith("De:") && e.Data.Contains("Para:") && e.Data.Contains("Mensaje:"))
            {
                string[] partes = e.Data.Split('\n');
                string de = "", para = "", mensaje = "";

                foreach (var linea in partes)
                {
                    if (linea.StartsWith("De:")) de = linea.Substring(3).Trim();
                    if (linea.StartsWith("Para:")) para = linea.Substring(5).Trim();
                    if (linea.StartsWith("Mensaje:")) mensaje = linea.Substring(8).Trim();
                }

                if (!string.IsNullOrWhiteSpace(para) && usuarios.ContainsKey(para))
                {
                    usuarios[para].Send($"[Mensaje de {de}]: {mensaje}");
                    Send("Mensaje entregado al destinatario.");
                    Console.WriteLine($"[Enviado] {de} → {para}: {mensaje}");
                }
                else
                {
                    Send($"[Servidor]: Usuario {para} no esta conectado.");
                    Console.WriteLine($"[Fallo] Usuario {para} no conectado.");
                }
            }
            else
            {
                Send("[Servidor]: Formato invalido.");
            }
        }

        protected override void OnClose(CloseEventArgs e)
        {
            if (!string.IsNullOrEmpty(nombreUsuario))
            {
                usuarios.TryRemove(nombreUsuario, out _);
                Console.WriteLine($"Usuario desconectado: {nombreUsuario}");
            }
        }

        public static void EnviarMensaje(string destino, string contenido)
        {
            if (usuarios.ContainsKey(destino))
            {
                usuarios[destino].Send($"[Servidor]: {contenido}");
                Console.WriteLine($"[Servidor] Mensaje enviado a {destino}");
            }
            else
            {
                Console.WriteLine($"[Servidor] Usuario {destino} no esta conectado.");
            }
        }

        public static void ListarUsuarios()
        {
            Console.WriteLine("Usuarios conectados:");
            foreach (var kvp in usuarios)
            {
                Console.WriteLine("- " + kvp.Key);
            }

            if (usuarios.IsEmpty)
            {
                Console.WriteLine("[Ninguno conectado]");
            }
        }
    }
}
