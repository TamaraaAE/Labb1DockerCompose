Ett .NET 8 projekt som innehåller Docker och Entity Framework.
Skapade ett REST API som hanterar produkter.
Detta projekt är byggt med .NET 8 Minimal API, EF Core och SQL Server i Docker-Container.
Måsta ha Docker och Docker Compose installerat.

För att köra projektet:
1. Klona repot
2. kan göras via bash terminalen.
3. git clone https://github.com/TamaraaAE/Labb1DockerCompose
4. cd Labb1DockerCompose

För att starta containerna:
docker-compose up --build

Testa API:et i swagger genom att öppna:
https://localhost:7123/swagger/index.html

Tekniska val till detta projekt är:
-> .NET 8 Minimal API – modernt och enkelt

-> Entity Framework Core – för databasmodell (Code First)

-> SQL Server – databas i container

-> Docker Compose – kör både API och databas tillsammans

-> Swagger – test av API

Tack o Hej.


