# Use uma imagem oficial do .NET SDK como base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copie os arquivos .csproj e restaure as dependências
COPY *.sln .
COPY GerenciamentoTerefas/*.csproj GerenciamentoTerefas/
COPY Domin/*.csproj Domin/
COPY Data/*.csproj Data/
COPY GrossCurting/*.csproj GrossCurting/
COPY Service/*.csproj Service/
COPY GerenciadorTerefas.Teste/*.csproj GerenciadorTerefas.Teste/
RUN dotnet restore

# Copie o restante dos arquivos e publique a aplicação
COPY . .
RUN dotnet publish -c Release -o out

# Use uma imagem oficial do .NET Runtime como base
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Exponha a porta na qual a aplicação irá rodar
EXPOSE 80

# Defina o comando para rodar a aplicação
ENTRYPOINT ["dotnet", "GerenciamentoTarefas.dll"]

