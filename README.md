# ms-estate-center API (Prueba técnica)

API RESTful construida con **ASP.NET Core 8.0** para la gestión de propiedades inmobiliarias.  
Incluye autenticación JWT, conexión con MongoDB y cifrado AES para proteger datos sensibles.

## Requisitos previos

Asegúrate de tener instalados los siguientes componentes en tu entorno local:

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [MongoDB Atlas](https://www.mongodb.com/atlas/database) o una instancia local de MongoDB
- [Git](https://git-scm.com/)
- (Opcional) [Visual Studio Code](https://code.visualstudio.com/) o tu IDE preferido


## Ambiente de Despliegue

La API está desplegada en la plataforma [Railway](https://railway.com), lo que permite acceder a sus endpoints de forma pública y segura.

Puedes consumirla utilizando la siguiente URL base:

```bash
https://ms-estate-center-production.up.railway.app/api

```

## Configuración local

Edita el archivo `appsettings.json` ubicado en la raíz del proyecto y agrega los valores de configuración correspondientes.

Estos valores se obtienen desde la plataforma de despliegue en la nube [Railway](https://railway.com), donde se encuentran definidas las variables de entorno del proyecto.

```bash
MongoDB__ConnectionString
MongoDB__DatabaseName
Jwt__Key
AESSettings__Key
AESSettings__IV
```

## Clonar el repositorio

```bash
git clone https://github.com/tu-usuario/ms-estate-center.git
cd ms-estate-center 
```

## Ejecución local

```bash
dotnet restore
dotnet build
dotnet watch run
```

## Swagger

[API en Swagger](https://ms-estate-center.onrender.com/swagger/index.html)