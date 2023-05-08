# Scripting_Parcial3
Por:
- Sebastián Franco Cataño
- Emmanuel Echeverri Sepulveda

Cambios en el repo
- Para RefactoredGameController, se cambio la clase para que fuera un singleton, y los accesores que tienen override también se instanciaron como singletons.
- Se agrego para poder utilizar el Command
- Para RefactoredPlayerController, también se añadió el patron de singleton y se modificó para utilizar el patrón de Command para cuando se deba ejecutar la acción de disparar y cambiar arma.
- En RefactoredUIManager, se añadió el singleton también, no hubo muchos cambios.
- En RefactoredObstacleSpawner, tenemos la implementación del spawn de los obtaculos usando el pool de objetos, pues este spawn depende de un numero aleatorio.
- Para PoolBase, se completó la implementación del patrón de pool de objetos, se modifico el uso de la lista para gestionar el pool por una cola en su lugar, pues permite mejor gestión de los objetos de la misma.
- Para PoolBase, se completó la implementación del patrón de piscina de objetos, se modifico el uso de la lista para gestionar el pool por una cola en su lugar, pues permite mejor gestión de los objetos de la misma.
