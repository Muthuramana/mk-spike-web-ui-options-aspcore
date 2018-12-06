FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Careers.Freshlook.sln ./
COPY Careers.Freshlook/Careers.Freshlook.csproj Careers.Freshlook/
RUN dotnet restore Careers.Freshlook/Careers.Freshlook.csproj -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/Careers.Freshlook
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Careers.Freshlook.dll"]
