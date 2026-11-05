<img width="608" height="281" alt="1000092409 (3) (1)" src="https://github.com/user-attachments/assets/68c857fb-ec36-49a1-8ec8-2cecfa3755c1" />

# Escenas-Cardboard-Interfaces

## Descripción
En esta práctica se ha desarrollado una experiencia de Realidad Virtual desarrollada en Unity utilizando el **Google Cardboard XR Plugin**. El objetivo principal es la recolección de objetos mediante la interacción visual (Gaze Interaction), incluyendo una mecánica especial de "imán" para atraer todos los objetos restantes mirando un objeto determinado.

## Mecánicas Principales
1. **Recolección por mirada:** Al mirar fijamente un objeto durante 2 segundos, este es recolectado (desaparece).
2. **Imán (Magnetismo):** Al mirar fijamente un objeto determinado (una caja), todos los objetos no recolectados del mapa vuelan hacia el jugador.
3. **Marcador UI:** Un panel de texto flotante (World Space) que muestra el progreso de recolección en tiempo real.

## Estructura de Scripts
A continuación se detallan los scripts principales que hacen funcionar el proyecto:

### 1. `GazeInteraction.cs`
Se encarga de detectar hacia dónde está mirando el usuario. Está asociado a la cámara principal (y única).
- **Funcionamiento:** Lanza un rayo (`Raycast`) desde el centro de la cámara. Si el rayo choca con un objeto interactivo (recolectable o imán), inicia un temporizador.
- **Interacción:** Si el jugador mantiene la mirada durante el tiempo establecido (2 segundos), activa la función correspondiente del objeto mirado.

### 2. `Collectible.cs`
Controla el comportamiento individual de cada objeto recolectable, haciendo que desaparezca una vez que se haya mirado al objeto durante 2 segundos.
- **Recolección Normal (`Collect`):** Hace el objeto invisible e intocable al instante (apagando su `Renderer` y `Collider`). 
- **Recolección Magnética (`Magnetize`):** Apaga la colisión del objeto e inicia una Corrutina (`GoToPlayer`) que mueve el objeto suavemente hacia la cámara del jugador usando `Vector3.MoveTowards` antes de destruirlo.

### 3. `RecoverCollected.cs`
Es el script asignado al objeto que va a recolectar (dirigir hacia el jugador) los recolectables restantes (la caja).
- **Funcionamiento:** Cuando el jugador lo activa con la mirada, busca automáticamente todos los objetos en la escena que tengan el script `Collectible.cs` (usando `FindObjectsByType`).
- **Acción:** Llama a la función `Magnetize()` de todos esos objetos para que vuelen hacia el jugador a la vez y avisa al sistema de puntuación para mostrar el mensaje de victoria.

### 4. `TextManager.cs`
Controla el marcador de puntuación flotante (Canvas en World Space usando TextMeshPro).
- **Funcionamiento:** Al arrancar, cuenta cuántos objetos recolectables hay en el mapa.
- **Actualización:** Tiene funciones públicas (`AddObject` y `ShowAllCollected`) a las que llaman los demás scripts para actualizar el texto en pantalla (ej. "Recogidos: 3 / 8").
  
## Resultados
A continuación, se muestra el resultado obtenido tras ejecutar la apk en el móvil (android en mi caso):

<img width="608" height="281" alt="1000092409 (3) (1)" src="https://github.com/user-attachments/assets/8e890a6d-16c9-4ca1-bc0b-e2592331a724" />


*Candela García Cruz*
