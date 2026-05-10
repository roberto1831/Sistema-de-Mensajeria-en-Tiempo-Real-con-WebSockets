# 🧩 Sistema de Mensajería en Tiempo Real – WebSockets

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET_8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![WebSockets](https://img.shields.io/badge/WebSockets-Real--Time-FF6B6B?style=for-the-badge)
![HTML](https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black)

> Sistema completo de mensajería punto a punto (P2P) en tiempo real usando **WebSocketSharp** con tres componentes: servidor WebSocket, cliente de consola y cliente web.

---

## 🏗️ Arquitectura del Sistema

```
┌─────────────────┐         WebSocket          ┌──────────────────────┐
│  Cliente Web    │◀──────────────────────────▶│                      │
│  HTML + JS      │                            │   Servidor WebSocket  │
└─────────────────┘                            │   C# / .NET 8         │
                                               │   (Diccionario        │
┌─────────────────┐         WebSocket          │    Concurrente)       │
│ Cliente Consola │◀──────────────────────────▶│                      │
│ C# / .NET 8     │                            └──────────────────────┘
└─────────────────┘
```

### Modelo de Mensajes

```
De: usuario
Para: destinatario
Mensaje: texto...
```

---

## 🚀 Componentes y Funcionalidades

### 🖥️ Servidor WebSocket (C# – .NET 8)
- Manejo de múltiples usuarios con **diccionario concurrente**
- Sistema de autenticación basado en `LOGIN`
- Enrutamiento de mensajes directo entre usuarios (P2P)
- Consola interactiva para listar usuarios conectados
- Logs completos de actividad

### 💬 Cliente Consola (C# – .NET 8)
- Registro de usuario con `LOGIN` automático al conectar
- Envío de mensajes entre usuarios conectados
- Respuestas en color para mejor legibilidad

### 🌐 Cliente Web (HTML + JavaScript)
- Conexión automática al servidor WebSocket
- Interfaz funcional en el navegador
- Visualización de mensajes en tiempo real

---

## 📁 Estructura del Proyecto

```
Cliente_web/
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

## ⚙️ Requisitos

- .NET 8 SDK
- Navegador Web moderno
- Paquetes NuGet:
  - `websocket-sharp-Net6.0`
  - `websocket-sharp-net7`

---

## ▶️ Ejecución

### 1. Iniciar el Servidor

```bash
cd ServidorWebSocket/ServidorWebSocket
dotnet run
```

### 2. Ejecutar Cliente Consola

```bash
cd ClienteConsolaWebSocket/ClienteConsolaWebSocket
dotnet run
```

### 3. Abrir Cliente Web

```bash
# Abrir directamente en el navegador
ClienteWeb/cliente.html
```

> ⚠️ Inicia siempre el servidor **antes** que los clientes.

---

## 📡 Protocolo de Comunicación

### LOGIN — Registro de usuario

```
De: Usuario
LOGIN
```

### MENSAJE — Envío punto a punto

```
De: UsuarioOrigen
Para: UsuarioDestino
Mensaje: Contenido del mensaje
```

### Ejemplo de flujo completo

```
1. Cliente A conecta → envía LOGIN
2. Cliente B conecta → envía LOGIN
3. Servidor registra ambos usuarios
4. Cliente A envía mensaje a Cliente B
5. Servidor enruta directamente → Cliente B recibe en tiempo real
```

---

## 👤 Autor

**Ing. Roberto Toapanta**  
📍 Quito, Ecuador  
🔗 [GitHub](https://github.com/roberto1831) · [LinkedIn](https://linkedin.com/in/roberto1831)

---

## 📄 Licencia

Uso académico / demostrativo. No apto para producción sin revisión de seguridad.
---

## 👨‍💻 Autor
**Ing. Roberto Toapanta**  
Quito – Ecuador
