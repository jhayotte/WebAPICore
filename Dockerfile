FROM microsoft/dotnet:latest
EXPOSE 1253
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
