# ESTÁGIO 1: Compilação (Build)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia o arquivo de projeto e restaura as dependências
# Usando o nome com hífen conforme sua verificação na pasta
COPY ["Crud-Cadastro.csproj", "./"]
RUN dotnet restore

# Copia o restante dos arquivos e compila a aplicação
COPY . .
RUN dotnet publish "Crud-Cadastro.csproj" -c Release -o /app/publish /p:UseAppHost=false

# ESTÁGIO 2: Execução (Runtime)
# IMPORTANTE: Aqui também precisa ser 10.0 para suportar seu projeto
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Copia os arquivos compilados do estágio anterior
COPY --from=build /app/publish .

# O Render usa a porta 80 por padrão para serviços web gratuitos
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# Comando para iniciar a aplicação usando a DLL do seu projeto
ENTRYPOINT ["dotnet", "Crud-Cadastro.dll"]