# API de Gestão de Vacinas

Esta API é destinada à gestão de postos de vacinação, vacinas disponíveis e usuários.

## Configuração do Ambiente

### Pré-requisitos

- .NET Core SDK 7 ou superior
- SQL Server (ou outro banco suportado pelo Entity Framework Core)
- IDE de sua preferência (Visual Studio, VS Code, etc.)

### Configuração do Banco de Dados

1. **Criar o Banco de Dados**:

   - Execute o script SQL fornecido [Script Da Criação do Banco.sql.txt](https://github.com/user-attachments/files/15964350/Script.Da.Criacao.do.Banco.sql.txt) para criar o banco de dados `ApiGestaoVacinas`.
   
2. **Configuração da Conexão com o Banco de Dados**:
   - Abra o arquivo `appsettings.json` e configure a string de conexão com o banco de dados SQL Server.

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=SEUSERVIDOR;Database=ApiCrud;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
   
## Acessando a Documentação no Swagger

A documentação completa dos endpoints da API pode ser visualizada através do Swagger. Para acessar o Swagger e explorar os endpoints disponíveis, siga os passos abaixo:

1. **Execute a API**: Certifique-se de que a API está em execução localmente ou em um ambiente acessível.
2. **Abra o Swagger**: Abra seu navegador e acesse o seguinte URL (substitua `localhost:porta` pelo endereço da sua API):
3. **Explore os Endpoints**: No Swagger, você poderá ver todos os endpoints da API, suas descrições, exemplos de requisição e respostas esperadas.
Isso facilitará a compreensão de como utilizar cada endpoint e os dados necessários para interagir com a API.
Para mais detalhes sobre como usar cada endpoint específico, consulte a seção correspondente neste README.


## Licença
Este projeto é licenciado sob os termos da Licença MIT. Veja o arquivo [LICENSE](./LICENSE) para mais detalhes.
