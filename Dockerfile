FROM microsoft/dotnet:latest
EXPOSE 1253
COPY ./src/WebApiCore/project.json /app/
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
#RUN ["dotnet", "build"]

