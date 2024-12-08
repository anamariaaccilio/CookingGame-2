# Cooking Express VR: ¡Ratatouille! 🍲🎮

## Descripción del Proyecto 📝  
*Cooking Express VR* es un juego de simulación de cocina en realidad virtual, diseñado para ofrecer una experiencia inmersiva en una cocina profesional. Los jugadores deben interactuar con diversos ingredientes y utensilios para cocinar y completar pedidos bajo presión de tiempo. Con mecánicas arcade y entornos dinámicos, este proyecto es ideal para los que buscan retos rápidos y precisos.

## Características Principales ⚙️

- **Interacción VR:** Manipula ingredientes, utensilios y objetos dentro de la cocina usando tecnología de realidad virtual.
- **Escenas del Juego:**
  - **1 Start Scene:** Pantalla inicial del juego.
  - **2 Game Scene:** Escena principal donde ocurre toda la acción del juego.

Recuerda que debes empezar por la **1 start scene**, la cual te guiará a la **2 game scene**, donde podrás interactuar con los objetos y completar las tareas culinarias.

## Instalación y Configuración 🚀


### 1. Clonar el Repositorio

Primero, necesitas clonar el repositorio en tu máquina local para obtener todos los archivos del proyecto. Abre tu terminal y ejecuta el siguiente comando:
```bash
git clone https://github.com/anamariaaccilio/CookingGame-2.git
```

```bash
cd CookingGame-2
```

Este comando descargará todo el código fuente del proyecto desde GitHub y cambiará el directorio a la carpeta del proyecto clonado.

### 2. Abrir el Proyecto en Unity

Una vez que hayas clonado el repositorio, necesitas abrir el proyecto en Unity para comenzar a trabajar con él:

- **Instalar Unity:** Asegúrate de tener Unity instalado en tu máquina. Se recomienda usar la versión **2022.3.31f1** (o la versión compatible que se menciona en el archivo `ProjectSettings`).
- **Usar Unity Hub:** Abre **Unity Hub**, y selecciona la opción **Add Project**.
- **Añadir el Proyecto:** Navega hasta la carpeta donde clonaste el repositorio y selecciona el directorio del proyecto.
- **Abrir Proyecto:** Haz clic en el proyecto y selecciona **Open**.

### 3. Instalar Dependencias Necesarias

El proyecto utiliza varias dependencias y paquetes para que funcione correctamente en un entorno VR. Sigue estos pasos para instalar las dependencias:

1. Abre el proyecto en Unity.
2. Ve a **Window > Package Manager** para acceder al gestor de paquetes de Unity.
3. Busca e instala el siguiente paquete:
   - **Meta XR SDK** (o el que se mencione como necesario en el proyecto).
4. Si hay dependencias adicionales, Unity las indicará y podrás instalarlas desde este mismo gestor.

**Nota:** Asegúrate de que las dependencias estén correctamente instaladas, ya que son esenciales para las interacciones en VR y otros componentes del juego.

### 4. Configurar el Entorno de Desarrollo para VR

El siguiente paso es asegurarte de que Unity esté configurado correctamente para trabajar con VR. Aquí se configura el sistema de plugins de VR:

1. Ve a **Edit > Project Settings** en Unity.
2. En el menú de configuración, selecciona **XR Plugin Management**.
3. Activa el plugin de VR correspondiente a tu dispositivo (por ejemplo, **Oculus**, **OpenXR**, **Windows Mixed Reality**, etc.).
4. Asegúrate de que todos los componentes necesarios para el dispositivo que estás utilizando estén habilitados.

Esto habilitará el soporte necesario para que el proyecto funcione correctamente en un entorno de VR.


## Instrucciones de Uso 🖥️

### 1. Iniciar el Juego

Para probar el juego:

1. Asegúrate de que las escenas **1 start scene**, **2 game scene** están correctamente configuradas en **Build Settings** (`File > Build Settings`).
2. Abre la escena **1 start scene** (`Assets/Scenes/1 Start Scene`).
3. Después, serás llevado automáticamente a la **2 game scene**, donde podrás empezar a interactuar con los ingredientes y utensilios.

### 2. Resolver los Desafíos

Durante el juego, interactúa con los elementos de la escena:

- Explora la cocina y usa los utensilios y los ingredientes para completar los pedidos.
- Cambia entre las escenas utilizando los controles integrados en el juego.
- Administra el tiempo para cumplir con los objetivos y obtener la mejor puntuación.


## ¡Contribuye a *Cooking Express VR*! 🌱 🎮

¡Nos encantaría que formaras parte de la comunidad de *Cooking Express VR*! Si tienes ideas para mejorar el juego, agregar nuevas características o corregir errores, ¡estás en el lugar correcto! 🚀 Para contribuir, solo sigue estos pasos:

### 1. Haz un Fork del Repositorio
Haz un fork del proyecto en GitHub para obtener tu propia copia del código y empezar a trabajar.

### 2. Crea una Rama para tus Cambios
Crea una nueva rama para trabajar en tu funcionalidad o corrección de errores. Mantén tu trabajo organizado y separado de la rama principal.

```bash
git checkout -b feature-nueva-funcionalidad
```

### 3. Realiza y Confirma los Cambios
Haz tus cambios y, cuando estés listo, confirma los cambios con un mensaje descriptivo. ¡Hazlo brillante!

```bash
git commit -m "Agregar nueva funcionalidad a Cooking Express"
```

### 4. Sube los Cambios a tu Repositorio
Sube tu rama con los cambios al repositorio de tu fork para que todos puedan ver tu genialidad.

```bash
git push origin feature-nueva-funcionalidad
```

### 5. Abre un Pull Request

Abre un Pull Request desde tu rama hacia el repositorio principal de Cooking Express VR para que podamos revisar y fusionar tus cambios.


## ¡Gracias por ser parte de este proyecto!🎉

¡Juntos podemos cocinar algo increíble! 🍳👩‍🍳

