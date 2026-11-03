# Escenas-Cardboard-Interfaces

## 1. Descripción del proyecto

El proyecto consiste en una escena de realidad virtual desarrollada en Unity para dispositivos Android utilizando Google Cardboard.

La escena utiliza el paquete **Idyllic Fantasy Nature** de la Asset Store, que proporciona el entorno y los elementos del escenario.

El objetivo de la práctica es crear una experiencia en la que el jugador pueda observar el entorno mediante unas gafas de realidad virtual y recoger objetos utilizando la mirada.

Además, se ha incorporado un objeto especial, un imán, que permite atraer los objetos recolectables hacia el jugador al seleccionarlo con la mirada.

## 2. Herramientas utilizadas

- Unity 6.
- Google Cardboard XR Plugin para Unity.
- Paquete Idyllic Fantasy Nature de la Asset Store.
- Android como plataforma de destino.
- C# para los scripts de interacción.

## 3. Funcionamiento

El jugador observa la escena a través de la cámara de Cardboard.

La interacción se realiza mediante un sistema de detección por raycast, que permite comprobar qué objeto está mirando el jugador.

Cuando el jugador mantiene la mirada sobre un objeto interactivo durante un tiempo determinado:

- **Objetos recolectables:** se desplazan automáticamente hacia la cámara del jugador y desaparecen al llegar a ella.
- **Imán:** al seleccionarlo, atrae todos los objetos recolectables de la escena hacia el jugador.

El tiempo necesario para seleccionar un objeto se puede modificar desde el Inspector de Unity.

## 4. Scripts utilizados

### GazeInteraction.cs

Se encarga de detectar los objetos que está mirando el jugador mediante un raycast desde la cámara.

Si el jugador mantiene la mirada durante el tiempo establecido, comprueba si el objeto tiene el componente `Collectible` o `Magnet` y ejecuta la acción correspondiente.

### Collectible.cs

Controla el comportamiento de los objetos recolectables.

Cuando se llama a su función `Recoger()`, el objeto comienza a desplazarse hacia la cámara del jugador. Al llegar a ella, se destruye.

### Magnet.cs

Controla el objeto especial que funciona como imán.

Cuando se activa, busca todos los objetos que contienen el componente `Collectible` y ejecuta su función `Recoger()`, haciendo que todos se desplacen hacia el jugador.

## 5. Configuración de Google Cardboard

Se ha utilizado el paquete Google Cardboard XR Plugin para integrar la realidad virtual en Unity.

El proyecto se ha configurado para Android y se ha incorporado la cámara de Cardboard a la escena del entorno.

En el archivo `CardboardStartup.cs` se ha realizado la modificación indicada en el enunciado para evitar que se ejecute una llamada de inicialización dentro del Editor:

```csharp
#if !UNITY_EDITOR
    Api.UpdateScreenParams();
#endif
```

También se ha configurado el sistema de entrada de Unity como `Both` para permitir la compatibilidad con scripts que utilizan el sistema de entrada antiguo y el nuevo.

## 6. Configuración de los objetos

Para que los objetos puedan detectarse mediante la mirada:

- Los objetos recolectables deben tener un componente `Collectible`.
- El objeto imán debe tener un componente `Magnet`.
- Los objetos interactivos deben disponer de un `Collider`.
- La cámara utilizada para la interacción debe tener el tag `MainCamera`.
- El script `GazeInteraction` debe estar añadido a la cámara del jugador.

## 7. Instalación y ejecución

1. Abrir el proyecto en Unity.
2. Comprobar que Google Cardboard XR Plugin está instalado.
3. Seleccionar Android como plataforma de compilación.
4. Conectar un dispositivo Android compatible.
5. Generar el archivo APK desde Unity.
6. Instalar el APK en el dispositivo móvil.
7. Introducir el teléfono en unas gafas compatibles con Google Cardboard para probar la experiencia.

## 8. Archivos incluidos en la entrega

La entrega incluye:

- El archivo APK generado para Android.
- Los scripts C# utilizados en la práctica.
- Este archivo README.md.

## 9. Conclusión

Con esta práctica se ha desarrollado una pequeña experiencia de realidad virtual utilizando Google Cardboard y Unity.

Se han trabajado conceptos como la configuración de una cámara de realidad virtual, la detección de objetos mediante raycast, el uso de colliders y la programación de interacciones mediante scripts en C#.

El resultado busca permitir al jugador interactuar con los elementos de la escena utilizando únicamente la mirada.
