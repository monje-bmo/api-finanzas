# API - Instalación, Configuración y Ejecución

API REST hecha en **ASP.NET Core** con **JWT**, **Identity** y **EF Core** (base de datos **POSTGRESQL**).

## 1) Requisitos

- **.NET SDK** (recomendado .NET 8)
  - Verificar: `dotnet --version`
- **Potsgresql**
  - Verificar `psql --version`
- **dotnet-ef** para migraciones
  - Instalar global: `dotnet tool install --global dotnet-ef`
  - Verificar: `dotnet ef --version`

## 2) Clonar el repositorio

```bash
git clone https://github.com/monje-bmo/api-finanzas.git
cd api-finanzas
````

## 3) Configurar la base de datos

### 3.1 Crear base de datos

Entrá a postgresql y crea la DB:

```sql
CREATE DATABASE mi_api_db;
```

> Podés usar cualquier nombre, pero recordá ponerlo igual en el ConnectionString.

## 4) Configuración de variables (ConnectionString + JWT)

Tu API lee configuración desde `appsettings.json`, `appsettings.Development.json` o variables de entorno.

### `appsettings.Development.json` (recomendado para local)

Crea/edita este archivo en el proyecto donde está tu `Program.cs`:

**`appsettings.Development.json`**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=mi_api_db;User=root;Password=TU_PASSWORD;TreatTinyAsBoolean=true;"
  },
  "JWT": {
    "SigningKey": "PON_AQUI_UN_SECRETO_LARGO_Y_RANDOM_MIN_32_CHARS",
    "Issuer": "miApi",
    "Audience": "miApiClient"
  }
}
```

✅ Importante:

* `SigningKey` mínimo **32 caracteres**, mejor si es largo y random.
* **No subas** este archivo con secrets al repo (agregalo al `.gitignore`).

## 5) Restaurar dependencias

En la raíz del proyecto/solución:

```bash
dotnet restore
```

## 6) Migraciones y creación de tablas (EF Core)

Si ya existen migraciones en el repo:

```bash
dotnet ef database update
```

Si NO existen migraciones (primera vez):

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## 7) Ejecutar la API (local)

### Modo normal

```bash
dotnet run
```

### Modo “watch” (recomendado)

```bash
dotnet watch run
```

El servidor normalmente imprime algo como:

* `Now listening on: http://localhost:5071`
* `Now listening on: https://localhost:7xxx`

## 8) Probar con Swagger

Abrí en el navegador:

* `http://localhost:5071/swagger`
* (o el puerto que te muestre la consola)

También podés ver el JSON:

* `http://localhost:5071/swagger/v1/swagger.json`

## 9) Autenticación (JWT)

La mayoría de endpoints protegidos requieren:

**Header**

```
Authorization: Bearer <TU_TOKEN>
```

Flujo típico:

1. Hacés login/register
2. El backend te devuelve un token
3. Lo usás en Swagger o en tu app enviando el header Authorization

---

