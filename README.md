# WebScrappingITLA

Este proyecto es una aplicación de consola desarrollada en .NET que permite hacer web scraping del portal virtual del ITLA para obtener tareas pendientes desde el calendario del estudiante.

## 🧩 Características

- Autenticación en el portal virtual del ITLA.
- Extracción de tareas pendientes, incluyendo:
  - Título de la tarea.
  - Fecha de vencimiento.
  - Materia asociada.
- Interfaz de línea de comandos (CLI).
- Ejecutable único, auto-contenido.

---

## 🚀 Requisitos

- .NET SDK 8.0 o superior
- Windows (actualmente soportado como plataforma de destino)

---

## ⚙️ Configuración del proyecto

### 1. Clonar y configurar credenciales 

```bash
# Clonar el repositorio
git clone https://github.com/Edward2323/WebScrappingITLA

# Entrar en el directorio del proyecto
cd WebScrappingITLA
```

1. Abre el proyecto

2. Establezca sus credenciales en el archivo ```credential.JSON```

### 2. Generar ejecutable

```bash
# Publicar el proyecto como archivo ejecutable único
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o ./publish

# Renombrar el ejecutable, le puedes poner cualquier nombre (Opcional)
ren .\publish\WebScrappingITLA.exe itlatasks.exe
```


### 3. Ejecutar desde cualquier lugar 

1. Copia el ejecutable itlatasks.exe a una carpeta permanente, por ejemplo:
```C:\Tools\```

2. Abre el menú Inicio y busca "variables de entorno" → entra en "Editar las variables de entorno del sistema".

2. Haz clic en "Variables de entorno…".

3. En la sección de variables de usuario, selecciona Path → Editar.

4. Haz clic en Nuevo y agrega la ruta donde copiaste el ejecutable:

6. Guarda los cambios y reinicia la terminal.

## Uso
Abre la terminal y simplemente escribe:
```bash
itlatasks # Si renombraste el ejecutable con otro nombre, utiliza ese
```
