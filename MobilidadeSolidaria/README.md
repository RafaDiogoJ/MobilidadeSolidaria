Mobilidade Solidária

Projeto do Trabalho de Conclusão de Curso de Desnvolvimento de Sistemas, com a finalidade de gestão de doação e empréstimo de equipamentos de mobilidade.

## Sumário

- Descrição
- Pré-requisitos
- Configuração do ambiente
- Clonando o projeto
- Restaurando dependências
- Configuração do banco de dados
- Executando o projeto
- Notas adicionais
- Contato

## Descrição

Este projeto é uma aplicação web desenvolvida em ASP.NET Core com .NET 9.0 (preview), que permite a doação e empréstimo de equipamentos de mobilidade como cadeiras de rodas e andadores.

## Pré-requisitos

Antes de iniciar, certifique-se de ter instalado em sua máquina:

- [Git](https://git-scm.com/) (para clonar o repositório)
- [.NET 9.0 SDK (Preview)](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)  
  *Nota: .NET 9.0 está em versão preview, utilize Visual Studio 2022 17.10 ou superior para melhor compatibilidade.*
- [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/) (recomendado, versão 17.10 ou superior) ou outro editor compatível com .NET
- [XAMPP](https://www.apachefriends.org/pt_br/index.html) (para rodar o MySQL)
- Navegador moderno (Chrome, Edge, Firefox, etc.)

## Configuração do ambiente

1. Instale o .NET 9.0 SDK
   Baixe e instale pelo site oficial:  
   https://dotnet.microsoft.com/en-us/download/dotnet/9.0

2. Configure o XAMPP  
   - Instale o XAMPP se ainda não tiver.  
   - Abra o Painel de Controle do XAMPP.  
   - Inicie o serviço **MySQL** clicando em **Start** e aguarde o status ficar verde.

## Clonando o projeto

Abra um terminal (Prompt de Comando, PowerShell, Terminal do VSCode) e execute:

git clone https://github.com/RafaDiogoJ/MobilidadeSolidaria.git
cd MobilidadeSolidaria

## Restaurando dependências

No terminal, dentro da pasta do projeto, execute:

dotnet restore

(Este comando baixa todas as dependências NuGet necessárias para o projeto.)

## Configuração do banco de dados

O projeto está configurado para usar o MySQL via XAMPP. Certifique-se de que:

    O serviço MySQL do XAMPP está rodando.

    As configurações de conexão (string de conexão) no arquivo appsettings.json ou na configuração do projeto estão corretas para o seu ambiente.

## Executando o projeto

Em novo terminal no VSCode

Execute:

1. cd .\MobilidadeSolidaria\ (parar entrar do diretorio do projeto)

2. dotnet watch run (para rodar o projeto com Hot Reload)

## Notas adicionais

    Por usar .NET 9.0 (preview), o ambiente pode apresentar instabilidades.

    Caso tenha problemas na conexão com o banco, verifique se o MySQL está ativo no XAMPP.

    Configure as variáveis de ambiente ou o appsettings.json conforme necessário para sua máquina.

## Contato

Para dúvidas ou suporte, entre em contato:

    Rafael Diogo

    Email: rafabbta@hotail.com

    GitHub: https://github.com/RafaDiogoJ

Espero que curta o projeto! 