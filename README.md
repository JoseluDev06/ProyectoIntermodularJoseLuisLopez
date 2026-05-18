PROYECTO INTERMODULAR JUEGO DE PELEA GRECAS FIGHTER (TITULO PROVISIONAL)
------------------------------------------------------------------------
DESCRIPCION:
  -JUEGO DE PELEA 2D CLÁSICO ESTILO MORTAL KOMBAT <br />
  -GRAFICOS REALES TANTO PERSONAJES COMO FONDOS (PENDIENTE) <br />
  -MUSICA ORIGINAL (PENDIENTE) <br />

TECNOLOGIAS UTILIZADAS:
  -UNITY <br />
  -C# <br />
  -GIMP <br />
  -AUDACITY <br />

PROCESO DE DESARROLLO:
  2EV:
    Esta evaluación me he enfocado más en aprender lo básico de C# y unity.
    En vez de seguir paso a paso un tutorial de "como hacer un juego" he preferido ver tutoriales más generales, prefiero entender en profundidad los conceptos básicos y los fundamentos, sacar mis propias soluciones a los problemas y ser capaz de hacer lo que yo quiero, no seguir un tutorial.
    Adjunto una prueba muy básica de movimiento de personajes, sin animaciones (estoy viendo tutoriales, pero aun no he trabajado en eso), y multiples assets que usaré como placeholders para el futuro cercano.
    Mis metas para el próximo trimestre son tener un sistema completo de animaciones y una escena básica.
        
  3EV:
    Este trimestre he añadido un sistema básico de animaciones que incluye:
    Un estado base de movimiento que controla el flujo entre animacion estatica, caminar hacia delante/detras y correr.
    Animaciones de salto, ataques y bloqueo.
    Estos sprites y animaciones son un placeholder, no creo que cueste mucho cambiarlas por mis propios sprites (tendre que ajustar la velocidad de las animaciones y cambiar el tiempo casteo/frames de duracion de los ataques)
    Los controles son un placeholder tambien, solo queria poder mover dos personajes a la vez pero no son controles muy comodos, en un futuro quiza aprenda a vincular mandos.
    He empezado a probar a añadir colliders 2d para las hitbox de los ataques(que tendre que ajustar a mis propios sprites).
    Lo siguiente será controlar más estados (stun, en combo, en caida...)
    Por ahora controlo cuando un personaje ataca, bloquea, está en aire, donde mira y si camina hacia delante.
    En un principio mi codigo no permite spamear ataques, moverse mientras bloqueas, correr hacia detrás ni ajustar el movimiento en el aire (todas decisiones de diseño voluntarias).
    Una vez implementados los estados de stun, combo etc. implementar una barra de vida será bastante sencillo.
    Tengo pensado sacar las fotos para los graficos en verano, quiza empiece a hacer un menú.

MAYORES PROBLEMAS ENCONTRADOS:
  -Me ha costado bastante poder programar un sistema de movimiento que tuviese en cuenta cuando estás en movimiento, cuando estás golpeando, cuando estás bloqueando y cuando estás en el aire.
  -Poder correr hacia delante sin poder correr hacia detrás al pulsar ambas teclas.
  -Evitar spameo de ataques.
  -Problemas con el collider 2d.


  

SIGUIENTES MEJORAS: <br /> 
  -GRAFICOS REALES <br />
  -INTERACCION ENTRE LOS PERSONAJES <br />
  -MENU DE SELECCION <br />
  -SONIDO <br />

Jose Luis López <br />
1ºDAM <br /> 
IES el Grao 2025-2026 <br />
