# FigurasApi

API RESTful en .NET para gestionar y calcular áreas y volúmenes de figuras geométricas.

## Características
- CRUD de figuras geométricas (cubo, esfera, pirámide, cilindro, rectángulo, círculo, cuboide, cono)
- Cálculo de áreas y volúmenes mediante endpoints dedicados
- Autenticación JWT (usuario predefinido: admin/12345)
- Persistencia en base de datos PostgreSQL (Supabase compatible)
- Documentación interactiva con Swagger

## Requisitos
- .NET 8 o superior
- PostgreSQL (puedes usar Supabase)

## Configuración local

1. **Clona el repositorio:**
   ```sh
   git clone https://github.com/tuusuario/FigurasApi.git
   cd FigurasApi
   ```

2. **Configura tu cadena de conexión y JWT:**
   Edita `appsettings.json` y pon valores de ejemplo o vacíos:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": ""
   },
   "Jwt": {
     "Key": "",
     "Issuer": "",
     "Audience": ""
   }
   ```

3. **Restaura y compila:**
   ```sh
   dotnet restore
   dotnet build
   ```

4. **Crea la base de datos y aplica migraciones:**
   ```sh
   dotnet ef database update
   ```

5. **Ejecuta la API:**
   ```sh
   dotnet run
   ```

6. **Accede a Swagger:**
   - [http://localhost:5244/swagger](http://localhost:5244/swagger)

## Usuario de prueba
- **Usuario:** admin
- **Contraseña:** 12345

## Despliegue en Railway

1. **Sube tu proyecto a GitHub.**
2. **Crea un nuevo proyecto en Railway** y selecciona tu repo.
3. **Agrega las siguientes variables de entorno en Railway:**
   - `ConnectionStrings__DefaultConnection` (tu cadena de conexión a Postgres)
   - `Jwt__Key` (tu clave secreta JWT)
   - `Jwt__Issuer` (por ejemplo: FigurasApi)
   - `Jwt__Audience` (por ejemplo: FigurasApiUsuarios)
4. **Railway detectará y desplegará tu API automáticamente.**
5. **Accede a la URL pública que te da Railway para probar tu API y Swagger.**

## Notas
- No subas tus claves reales ni contraseñas al repositorio público.
- Usa variables de entorno para los secretos en producción.

---

¡Listo para usar y desplegar tu API de Figuras Geométricas! 🚀 