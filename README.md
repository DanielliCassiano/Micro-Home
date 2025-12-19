
# MicroHome - Hands-on Microservices (.NET 9)

Este projeto demonstra a implementação de uma arquitetura de microsserviços utilizando *ASP.NET Core 9, focando em conteinerização com **Docker* e persistência de dados em *SQL Server*.

## 💡 Ideia de Implementação
A ideia é uma espécie de loja de decoração para casa, com um CRUD básico. Focado na implementação da arquitura e não especificamente nas funcionalidades da loja. 


## 🚀 Tecnologias Utilizadas
* *Back-end:* .NET 9 (Web API)
* *Banco de Dados:* SQL Server 2022
* *Containerização:* Docker & Docker Compose
* *Documentação:* OpenAPI / Scalar
* *ORM:* Entity Framework Core (Migrations)

## 🏗️ Arquitetura
A solução é dividida em dois serviços principais que se comunicam via HTTP:
1. *Catalog.API:* Gerenciamento de produtos e estoque.
2. *Orders.API:* Processamento de pedidos (consome dados do Catálogo).
3. *ApiGateway (YARP):* Ponto de entrada único para o ecossistema.

## 🎯 Step atual
  Finalizando a configuração do docker com o banco, já está bem funcional(localmente sem executar as APIs via docker) e poderei seguir para o CRUD quando conectar corretamente com o SQL via docker.
  * *Atual*: Concluir a conexão SQL com Docker(no momento não está conseguindo localizar a conexeção local)


## 🛠️ Como Executar

### Execução recomendada — Docker Compose

1. (Opcional) Adicione um `docker-compose.override.yml` para criar um SQL Server junto aos serviços. Exemplo abaixo.

2. No diretório `MicroHome` (onde está o `docker-compose.yml`), execute:

```bash
docker-compose up --build
```

3. Aguarde os logs; o serviço de Catálogo aplica migrações automaticamente e semeia dados na inicialização.

Observações sobre Docker:
- O `docker-compose.yml` padrão injeta uma connection string apontando para um host externo (IP `192.168.0.30`). Use o `docker-compose.override.yml` para executar um SQL Server dentro do mesmo compose e apontar as APIs para ele.
- Os Dockerfiles expõem as portas `8080` e `8081`, mas o mapeamento para o host precisa ser feito no `docker-compose` ou manualmente.

---

### Execução local (sem Docker)

1. Configure um SQL Server local (por exemplo `SQLEXPRESS`) e ajuste `ConnectionStrings:DefaultConnection` em `MicroHome.Catalogo.API/appsettings.Development.json` ou defina a variável de ambiente `ConnectionStrings__DefaultConnection`:

```
Server=.\SQLEXPRESS;Database=MicroHomeDb;Trusted_Connection=True;TrustServerCertificate=True;
```

2. Restaurar e compilar a solução (a partir da pasta `MicroHome`):

```bash
dotnet build MicroHome.slnx
```

3. Executar as APIs (cada uma em um terminal diferente):

```bash
dotnet run --project MicroHome.Catalogo.API
dotnet run --project MicroHome.Pedidos.API
dotnet run --project MicroHome.ApiGateway
```

4. O projeto de Catálogo chama `context.Database.Migrate()` na inicialização e insere dados de exemplo automaticamente; portanto, se a connection string apontar para um SQL Server acessível, o banco será criado/aplicado automaticamente.

---

### Comandos úteis

- Build: `dotnet build MicroHome.slnx`
- Executar projeto específico: `dotnet run --project <CaminhoDoProjeto>`
- Docker: `docker-compose up --build` (executar em `MicroHome`)
- Criar SQL Server via Docker (se necessário):

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong!Passw0rd" -p 1433:1433 --name microhome-mssql -d mcr.microsoft.com/mssql/server:2019-latest
```

---

## ✅ Solução de problemas rápida

- Migrações falham → verifique conexão/credenciais do SQL Server e se a porta está acessível.
- Serviços não aparecem em `localhost` → confirme mapeamento de portas no `docker-compose`.
- OpenAPI aparece apenas em ambiente `Development`.
