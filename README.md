# ms-estate-center API (Prueba técnica)

API RESTful construida con **ASP.NET Core 8.0** para la gestión de propiedades inmobiliarias.  
Incluye autenticación JWT, conexión con MongoDB y cifrado AES para proteger datos sensibles.


## Requisitos previos

Asegúrate de tener instalados los siguientes componentes en tu entorno local:

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [MongoDB Atlas](https://www.mongodb.com/atlas/database) o una instancia local de MongoDB
- [Git](https://git-scm.com/)
- (Opcional) [Visual Studio Code](https://code.visualstudio.com/) o tu IDE preferido

## Configuración local

Edita el archivo `appsettings.json` en la raíz del proyecto agregando los valores:

MongoDB__ConnectionString
MongoDB__DatabaseName
Jwt__Key
AESSettings__Key
AESSettings__IV

## Ejecución local

dotnet restore
dotnet build
dotnet watch run

## Clonar el repositorio

```bash
git clone https://github.com/tu-usuario/ms-estate-center.git
cd ms-estate-center 
```

## Swagger

[API en Swagger](https://ms-estate-center.onrender.com/swagger/index.html)