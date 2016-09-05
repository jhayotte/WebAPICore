FROM microsoft/dotnet:latest

COPY /src /app

WORKDIR /app

RUN ["dotnet", "restore"]

WORKDIR /app/WebApiCore

RUN ["dotnet", "build"]

EXPOSE 15000
ENV ASPNETCORE_URLS http://*:15000

ENTRYPOINT ["dotnet", "run"]
