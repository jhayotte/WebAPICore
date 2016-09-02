FROM microsoft/dotnet:latest

COPY /src /app

WORKDIR /app

RUN ["dotnet", "restore"]

WORKDIR /app/WebApiCore

RUN ["dotnet", "build"]

EXPOSE 1253

ENTRYPOINT ["dotnet", "run"]
