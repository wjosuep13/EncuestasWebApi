# Pasos para correr el proyecto

1. Clonar o descargar repositorio
2. Dentro de la raiz de los archivos de repositorio se encuentra **DataBaseScript.sql**  ejecutarlo en SQL Server.
3. Abrir la carpeta **EncuestasAPI**
4. Cambiar string de conexion a SQL Server en la ruta siguiente

```
Raiz
│   README.md
│   EncuestasAPI
│   ...
└───EncuestasAPI
    │   EncuestasAPI.sln
    │
    └───EncuestasAPI
       │   appsettings.json

```
Dentro de **appsettings.json**
Sustituir el string de conexion en linea 3. en el atributo **WebApiDatabase**
```
 "ConnectionStrings": {
    "WebApiDatabase": "Data Source=GT3140615W1\\SQLEXPRESS; Initial Catalog=Encuestas; Integrated Security=true;"
  },
  ..

```
 
5. Correr el proyecto de VisualStudio desde la aplicación **EncuestasAPI** y no desde IIS Express como se muestra en la imagen.


6. Importar Coleccion de Postman **EncuestasCollection.postman_collection.json** que se encuentra en la raiz del repositorio.

7. Ejecutar el request de autenticación llamado **GetToken**.
8. CLick en el nombre de la collecion y Copiar el token retornado anteriormente a la variable token dentro de la collecion.
9. Ejecutar request siguientes.

Al guardar una encuesta se retorna un link con un html en el cual se pueden llenar dichas encuestas por default se esta probando con la encuesta 3 copiar el link del request en  "**Link al formulario hacer get en navegador..**"
Realizar el get en el navegador para tener una mejor interaccion y llenarlo desde el formulario ,de igual manera esta el post de ese formulario en especifico en el request "**PostDataExampleForPreviousLink**"


  
  
