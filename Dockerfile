FROM microsoft/dotnet:latest

COPY /src/WebApiCore /app

WORKDIR /app

RUN ["dotnet", "restore"]

RUN ["dotnet", "build"]

EXPOSE 1253

ENTRYPOINT ["dotnet", "run"]
