# Documentação

Projeto do processo seletivo feito final de 2020

## Instrução de Uso

* Com apenas as 2 ferramentas Visual Studio e o docker instalado (Setado para linux) é possível rodar a aplicação.
* Utilizar botão Docker Compose (mesmo botão padrão no qual se depura qualquer aplicação do Visual Studio), executará os comandos do Dockerfile e gerará os arquivos finais para rodar no servidor
* No postman, usando a mesma porta gerada pelo projeto, enviar o evento no corpo da requisição pelo EndPoint /Home/Post

## Estrutura

* docker-compose. 
        
    Este projeto foi setado como projeto de inicialização.
    docker-compose.yml. Configurado criação de 2 containers para sistema Linux: mssql-2017 e a aplicação WebApplication que depende do banco
    

* WebApplication
        
    Feito em ASP.NET CORE MVC 3.1
    Para efeito de simplicidade, foi escolhido desenvolver as telas usando as Views do MVC
        
    * Startup
            
        Foi adicionados os serviços AutoMapper (mapeamento ViewModel e Entidade do evento do sensor) e DbContext (mapeamento Objeto-Relacional do evento do sensor).
        Atualização automática do schema do banco de dados, se necessário, a partir das migrations presentes na pasta Migrations

    * Dockerfile

        Configuração da imagem a ser construida gerada automaticamente pelo Visual Studio

    * Controller
            
        Foi utilizada uma controller, a HomeController apenas para simplificação do projeto
        Todas as Actions serão explicadas na seção Controller (MVC).
        Este projeto contém todas as dependências e responsabilidades.
        Por ser um projeto simples, esta miscelânea de responsabilidades na mesma camada de apresentação não implica em ilegibilidade.
        Uma melhor arquitetura será explicada na seção Melhorias futuras

    * Models
            
        * RelatorioSensorViewModel (utiliza RegiaoViewModel e SensorViewModel) 
            Model para a view da criação de relatório (view Report)
        * EventViewModel

    * Views
            
        O layout utilizou a biblioteca chart.js 2.8 para criação do gráfico para os eventos numéricos
            
        * Index. Para visualização da tabela com atualização automática dos eventos.
        * Graph. Para visualização do gráfico para eventos com valores numéricos com atualização automática e
        com filtro de exibição de eventos por sensor e região.
        * Report. Relatório em tabela dos eventos por região e sensor
        
    * Entities

        A entidade não deveria pertencer ao mesmo projeto MVC
        Uma melhor arquitetura será explicada na seção Melhorias futuras

        * Event

            O evento foi desenvolvido pensando-se em um domínio rico. 
            Além dos seus atributos, o evento conhece sua própria validação
                
            Validações:

            * Tag deve conter 3 valores
            * Primeiro valor da Tag deve ser "brasil"
            * Segundo valor da Tag deve ser "norte", "nordeste", "sul", "sudeste" ou "centrooeste"
            * Terceiro valor da Tag não pode estar vazio
            * Data não pode estar vazia
            * Valor não pode estar vazio

            Todos essas validações estão presentes no teste unitário do Evento

* XUnitTestEvent

    Este projeto depende do projeto de aplicação Web mas este último é agnóstico ao projeto de teste. 
    Portanto, o projeto de teste pode ser removido da aplicação sem impactos.
        
    * EventTest. Teste unitário da entidade que armazena e trata os eventos dos sensores.


## Controller (MVC)

* Index

    * Utilizado para a View Index

* Graph

    * Utilizado para a View Graph
    * Utiliza a função buildReport para montagem das opções do par região e sensor usando os eventos válidos 

* Report

    * Utilizado para a View Report
    * Utiliza a função buildReport para montagem do Relatório
    * A criação do relatório deveria estar fora da Controller [Melhorias futuras]

* Post

    * Persiste o evento no banco
    * Utiliza REST POST com o evento do sensor no corpo da requisição

* GetData

    * Utilizado para a View Index
    * Obtem todos os eventos em ordem decrescente de armazenamento no banco
    * O evento tem seu campo id (chave primária) auto incrementada durante a persistência no banco 

* hasData

    * Utilizado para a View Graph
    * Verifica se existe algum evento válido armazenado no banco
    * Usado em na View do gráfico para controle da exibição ou não do botão de filtro de sensor e região

* GetLastResults

    * Utilizado para a View Graph
    * Obtêm os ultimos 10 dados válidos filtrado pela região e sensor definido pelo usuário
    * Todos os dados foram convertidos de string para int [Melhorias futuras]

* DeleteAllData. 

    * Deleta todos os eventos do banco
    * Esta action foi criada para auxiliar nos testes manuais
    * Não deveria estar presente no projeto final.


## Melhorias futuras
    
* Arquitetura DDD
    
    * Para simplicidade, Desenvolvimento foi feito totalmente em um projeto. Entretanto, uma melhor arquitetura deveria separar as camadas utilizando DDD. Cada camada com sua própria responsabilidade.
    * A apresentação não deveria saber por exemplo que se está utilizando Entity FrameWork para o mapeamento da entidade Evento para a tabela evento no banco de dados. Outro problema é a camada de apresentação ter a responsabilidade de gerar o relatório.
    
    * A primeira camada deveria ser de apresentação. Portanto, apenas conter o MVC e o autoMapper.
    * Camada de Serviços. Criar um serviços específico para gerar Relatório chamando a aplicação CRUD do evento
    * Camada de Aplicação. Criar uma aplicação CRUD padrão do Evento
    * Camada de Domínio. Conter a entidade Evento. 
    * Camada de Infra. Conter o DbContext e as migrations

* Authenticação e Autorização

    * Adicionar authenticação com autorização para todas as actions exceto a Post
    * Isso por que o evento deve ser enviado utilizando um token

* Gráfico

    * O filtro hoje retorna apenas valores inteiros
    * O filtro deve retornar valores com até 4 casas decimais
    * Deve entender caracteres especiais como "°"

* Bug de performance

    * A aplicação receberá milhares de eventos por segundo. Portanto, na tabela de eventos haverá lentidão na renderização da tela devido a quantidade de eventos trazidos
    * Sugestão: ou paginar de forma estática ou continuar a atualização automatica dos dados mas apenas trazer os últimos 100 dados (filtro no BackEnd)

* Tratamento de Erro

    * Algum adversidade no recebimento do evento pode "quebrar" a aplicação. Portanto, é crucial o tratamento genérico desta requisição

* Validação do Evento

    * Adicionar validação para verificar se o timeStamp é uma data válida