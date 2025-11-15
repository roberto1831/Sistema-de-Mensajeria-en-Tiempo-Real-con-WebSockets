# 🧩 Sistema de Mensajería en Tiempo Real con WebSockets  
### Cliente Web + Cliente Consola + Servidor WebSocket (C# / .NET 8)

Este proyecto implementa un sistema completo de mensajería punto a punto (P2P) utilizando **WebSocketSharp**, con tres componentes:

- **Servidor WebSocket** (C# – .NET 8)
- **Cliente de Consola WebSocket** (C# – .NET 8)
- **Cliente Web** (HTML + JavaScript)

Permite enviar mensajes entre usuarios conectados mediante un modelo simple basado en:
```
De: usuario
Para: destinatario
Mensaje: texto...
```

---

## 📁 Estructura del Proyecto

```
Cliente_web/
│
├── ClienteConsolaWebSocket/
│   ├── ClienteConsolaWebSocket.sln
│   └── ClienteConsolaWebSocket/
│       ├── Program.cs
│       └── ClienteConsolaWebSocket.csproj
│
├── ClienteWeb/
│   └── cliente.html
│
└── ServidorWebSocket/
    ├── ServidorWebSocket.sln
    └── ServidorWebSocket/
        ├── Program.cs
        ├── ServidorWebSocket.csproj
        └── Usuario.cs
```

---

## 🚀 Funcionalidades

### 🖥️ Servidor WebSocket
- Manejo de múltiples usuarios con diccionario concurrente.
- Sistema de LOGIN basado en “De:”.
- Envío directo entre usuarios.
- Consola interactiva para listar usuarios y enviar mensajes.
- Logs completos.

### 💬 Cliente Consola
- Solicita usuario.
- Hace LOGIN automático.
- Envío de mensajes entre usuarios.
- Respuestas en color.

### 🌐 Cliente Web
- Cliente HTML funcional.
- Se conecta automáticamente.
- Muestra mensajes del servidor.

---

## ⚙️ Requisitos

- .NET 8 SDK  
- Navegador Web  
- Paquetes NuGet:  
  - websocket-sharp-Net6.0  
  - websocket-sharp-net7  

---

## ▶️ Ejecución

### 1. Iniciar Servidor
```
cd ServidorWebSocket/ServidorWebSocket
dotnet run
```

### 2. Ejecutar Cliente Consola
```
cd ClienteConsolaWebSocket/ClienteConsolaWebSocket
dotnet run
```

### 3. Abrir Cliente Web
Abrir:

```
ClienteWeb/cliente.html
```

---

## 📡 Protocolo

### LOGIN
```
De: Usuario
LOGIN
```

### MENSAJE
```
De: Usuario
Para: Destinatario
Mensaje: Contenido
```

---

## 👨‍💻 Autor
**Ing. Roberto Toapanta**  
Quito – Ecuador
