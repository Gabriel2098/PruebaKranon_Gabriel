# PruebaKranon_Gabriel
Instrucciones:

1.- Clonar el repositorio y abrir la solución.

2.- En caso de no existir el paquete NuGet "NewtonSoft.Json", instalarlo unicamente en la capa de Datos.

3.- En caso de no existir referencia hacia los proyectos en alguna capa, hacer lo siguiente:        
     - Agregar una referencia al proyecto de Entidades en la capa de Datos.        
     - Agregar referencias a los proyectos de Entidades y Datos en la capa de Negocio.        
     - Agregar referencias a los proyectos de Entidades y Negocio en la capa de Presentación.        
     
3.- Definir como proyecto de inicio a la capa de Presentación.

4.- Ejecutar el proyecto y copiar la URL local en la que se ejecute.

5.- Importar en PostMan el archivo "KranonAPI Test.postman_collection.json" con los datos de la colección de las pruebas.

6.- En el apartado de variables pegar la URL Local que se copio anteriormente en los valores para base_url.

7.- Ejecutar cada uno de los request.
