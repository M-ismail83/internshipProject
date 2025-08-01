FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /usr/src
COPY *.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /usr/src/app
COPY --from=build /app/publish .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "ToDoList.dll"]