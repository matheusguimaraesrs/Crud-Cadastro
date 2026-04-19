# ESTÁGIO 1: Compilação (Build)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# 1. Copia o arquivo .csproj que está dentro da pasta para a pasta correspondente no Docker
COPY ["Crud-Cadastro/Crud-Cadastro.csproj", "Crud-Cadastro/"]

# 2. Restaura as dependências focando no arquivo específico
RUN dotnet restore "Crud-Cadastro/Crud-Cadastro.csproj"

# 3. Copia todo o conteúdo do repositório
COPY . .

# 4. Muda o diretório de trabalho para onde o projeto realmente está
WORKDIR "/src/Crud-Cadastro"

# 5. Compila e publica
RUN dotnet publish "Crud-Cadastro.csproj" -c Release -o /app/publish /p:UseAppHost=false

# ESTÁGIO 2: Execução (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Copia os arquivos publicados do estágio anterior
COPY --from=build /app/publish .

# Configurações de porta para o Render
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# Comando para iniciar (A DLL geralmente mantém o nome do projeto)
ENTRYPOINT ["dotnet", "Crud-Cadastro.dll"]
