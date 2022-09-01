# Uso de la carpeta Static

Cada carpeta lleva el nombre de los Sprite o Scripts que se necesiten específicamente para un tipo de interacción, o para un objeto en especial.

Animations
    Animaciones de botones y ventana.

Audio
    Botón para activar el audio en interacciones que lo necesiten.

AudioPlayer
    Prefab del Audioplayer, el prefab se encuentra dentro de la carpeta AudioPlayer/Structure

Background
    Prefab del Background con text, el prefab se encuentra dentro de la carpeta Background/Structure

ChainPoints
    Sprites para el Unir con lineas

BuiltButton
    Sprites para el botón checker e integrador y su respectivo prefab, el prefab se encuentra dentro de la carpeta Checker/Structure

Galería
    Sprites para la galería de imágenes.

Mec
    Sprites para el MEC

MultipleSelection
    Sprites para la selección Multiple.

Popup
    Sprites para los PopUp, o ventanas que salgan con información adicional.

Scripts
    Scripts para funcionalidades generales.

Feedback
    Ventana de retroalimentiación para las respuestas incorrectas.

Video
    Sprites para los videos.

# Reglas

- No hacer override a los prefabs, es decir agregar componentes o cambiar variables y agregarlos al prefab base.

- Para modificar los Prefabs, dele Click derecho en el Prefab agregado en la escena, luego de click al apartado de Prefab y una vez allí de click en Unpack. Tenga cuidado y no de click en Unpack Completely pues este afecta el Prefab guardado en el projecto.

- Si desea agregar scripts para varias interacciones, agréguelos en la carpeta de Scripts.

- Si desea añadir carpetas, tenga en cuenta si esta va a contener próximos Sprites o Scripts necesarios para las demás producciones y avísele al integrador.

## Por notar

Si usted ve una carpeta vacía, significa que los assets para esa interacción no han sido todavía exportador por el diseñador.