# RefugioAnimal

## Descrição
RefugioAnimal é um projeto Razor Pages que ajuda a gerenciar animais para adoção. Este projeto inclui funcionalidades para ONGs e protetores de animais, permitindo o cadastro, edição e exclusão de animais. 

## Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Configuração do Projeto

### 1. Clone o Repositório
Clone o repositório para sua máquina local usando o comando:

### 2. Abra o Projeto no Visual Studio
Abra o Visual Studio 2022 e carregue o projeto `RefugioAnimal.sln`.

### 3. Configuração do Banco de Dados
Certifique-se de que o SQL Server está instalado e em execução. Atualize a string de conexão no arquivo `appsettings.json` com as credenciais do seu servidor SQL.

### 4. Aplicar Migrações
Abra o Console do Gerenciador de Pacotes no Visual Studio (Ferramentas > Gerenciador de Pacotes NuGet > Console do Gerenciador de Pacotes) e execute os seguintes comandos para aplicar as migrações e criar o banco de dados:

### 5. Inserir Dados de Exemplo
Você pode inserir dados de exemplo no banco de dados executando o seguinte script SQL:

INSERT INTO Animals (Name, Description, BreedId, DonorId, Species, AdoptionStatus) 
VALUES ('Scooby-Doo', 'A Great Dane who solves mysteries with his friends.', 1, 'b2ba1136-6294-4b46-8f85-5d5eb58d34ed', 0, 0), 
('Garfield', 'A lazy, lasagna-loving cat.', 2, 'b2ba1136-6294-4b46-8f85-5d5eb58d34ed', 1, 0), 
('Snoopy', 'A beagle who loves to imagine himself as a World War I flying ace.', 3, 'b2ba1136-6294-4b46-8f85-5d5eb58d34ed', 0, 0), 
('Tom', 'A cat who is always chasing Jerry.', 4, 'b2ba1136-6294-4b46-8f85-5d5eb58d34ed', 1, 0), 
('Simba', 'The lion king.', 5, 'b2ba1136-6294-4b46-8f85-5d5eb58d34ed', 2, 0), 
('Dory', 'A forgetful blue tang fish.', 6, 'b2ba1136-6294-4b46-8f85-5d5eb58d34ed', 3, 0), 
('Bambi', 'A young deer who learns about life in the forest.', 7, 'b2ba1136-6294-4b46-8f85-5d5eb58d34ed', 4, 0), 
('Baloo', 'A fun-loving bear who teaches Mowgli about the bare necessities.', 8, 'b2ba1136-6294-4b46-8f85-5d5eb58d34ed', 5, 0),
('Toto', 'Dorothy's loyal dog from The Wizard of Oz.', 9, 'b2ba1136-6294-4b46-8f85-5d5eb58d34ed', 0, 0),
('Nemo', 'A young clownfish who gets lost in the ocean.', 10, 'b2ba1136-6294-4b46-8f85-5d5eb58d34ed', 3, 0);

### 6. Executar o Projeto
No Visual Studio, selecione o projeto `RefugioAnimal` como projeto de inicialização e pressione `F5` para rodar o projeto.

## Estrutura do Projeto
- **Controllers**: Contém os controladores MVC.
- **Models**: Contém as entidades e DTOs.
- **Views**: Contém as views Razor.
- **wwwroot**: Contém arquivos estáticos como CSS, JavaScript e imagens.

## Contato
Para mais informações, entre em contato com [jp.oli2019@gmail.com](mailto:jp.oli2019@gmail.com).

