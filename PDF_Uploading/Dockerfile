FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Pehle sirf .csproj file copy karo project folder se
COPY PDF_Uploading/*.csproj ./
RUN dotnet restore

# Ab baaki saari files bhi copy karo project folder se
COPY PDF_Uploading/. ./
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PDF_Uploading.dll"]
