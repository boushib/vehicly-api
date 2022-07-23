# Vehicly

This is the backend Rest API for _Vehicly_, a vehicles online store.

Frontend: <https://github.com/boushib/vehiclesStoreFrontend>

## Stack to be used in the project

- **Frontend**: Vue.js, & Vuex.
- **Backend**: Rest API in C# (.NET core).
- **Database Engine**: PostgreSQL.
- **File Storage**: AWS S3.

## Tools used during development

- VSCode.
- Postman.
- pgAdmin
- Docker

## Run dev environment

First let's pull the postgres image:

```text
docker pull postgres
```

Then, start a postgres instance:

```text
docker run --name postgres -e POSTGRES_PASSWORD=123456 -d -p 5432:5432 postgres
```

Now, it's time to start a postgres container:

```bash
docker start postgres
```

After cloning this repo, let's create the our database and tables:

But first, add these entries to your secret manager (make sure to replace the dummy values with real ones):

Ref: <https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=linux>

```json
{
  "PostgresConnectionString": "Server=localhost;Port=5432;Database=vehiclesStore;UserId=postgres;Password=123456",
  "JWTConfig": {
    "Secret": "your-super-secret-key",
    "Issuer": "your-issuer",
    "Audience": "your-audience",
    "AccessTokenExpiration": 525600,
    "RefreshTokenExpiration": 43200
  },
  "AWS": {
    "AccessKeyID": "your-aws-access-key-id",
    "SecretAccessKey": "your-aws-secret-access-key",
    "DefaultBucket": "your-bucket-name"
  }
}
```

Install Entity Framework:

```bash
dotnet tool install --global dotnet-ef
```

Update the database:

```bash
dotnet ef database update --context UsersContext
dotnet ef database update --context VehiclesContext
```

Finally run the dev server:

```bash
dotnet run
```

All done, enjoy!
