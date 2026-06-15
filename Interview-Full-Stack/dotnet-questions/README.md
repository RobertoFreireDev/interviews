# Interview-questions

## TODO:

https://github.com/ByteByteGoHq/system-design-101?tab=readme-ov-file

## Perguntas de entrevista

### Teoria da Programação

#### Qual significado de cada letra de SOLID?

S - Princípio de responsabilidade única : Cada modulo, classe, função deve ter uma única responsabilidade e deve ter apenas um motivo para mudar.

Ex: Um método de criar usuário no serviço de usuário na camada de aplicação deve apenas ser responsável pelo fluxo de negócio da criação de usuário, por exemplo, chamar repositório para persistir usuário no banco e depois chamar outro método em outra classe para enviar e-mail avisando que usuário foi criado. O único motivo para este método de criar usuário mudar seria se o fluxo de negócio mudar, por exemplo, não iria mais enviar e-mail ao criar usuário.

O - Principio Open/Closed : Fechado para mudanças e aberto para extensão.

Ex: Uma classe de pessoa por exemplo com propriedade de tipo e sendo um domínio rico, tem vários comportamentos dependendo deste tipo de pessoa. O código vai ficar com vários ifs e elses. Podemos refatorar para criar uma classe pessoa pai e criar filhos cada um com sua implementação específica para o tipo e em relação a instaciação de cada filho, ficaria sob a função de uma factory. Assim, ao se mudar alguma lógica de um tipo de pessoa A, a classe pai e todos os outros filhos estariam protegidos/fechados para mudança e a classe pai está aberta para extensão.

L - Principio de substituição de Liskov : Não usar herança apenas pela relação "IS". Ex: pessoa jurídica é uma pessoa. O objeto filho deve ser substituível pelo objeto pai.

Ex: Classe quadrado e retangulo. Quadrado é um retângulo mas o objeto quadrado não pode ser substituível no lugar de um retângulo por que o quadrado aceita no seu construtor apenas um parâmetro, enquanto o retângulo aceita 2.

I - Princípio de segregação de interface : Uma classe não deve implementar contratos de comportamentos que ela não precisa. É melhor mais interfaces específicas do que menos interface genéricas. 

D - Princípio de inversão de dependência. Implementações de alto nível não deve depender de implementações de baixo nível. Ambas devem depender de abstrações. 

Ex: Um classe de serviço não deve referenciar uma implementação de um repositório. Ao invés disso, a classe de serviço deve ter como dependência a interface do repositório e instaciá-la através do construtor por injeção de dependência e o repositório implementa a interface.

#### Os 4 pilares da Programação Orientada a Objetos

Herança:

Capacidade de um objeto de herdar propriedade e comportamentos de um objeto pai. 
Reuso de código. 
Duplicação de código abre mais brecha para bugs e maior trabalho de manutenção.

Ex: Implementar no objeto pai, campos em comum dos objetos filhos que herdaram estes campos. 

Abstração: 

Abstrair uma classe seria definir suas propriedades e métodos.
A partir de classes abstratas e interfaces, é possível definir uma abstração de uma classe.
A interface abstrai uma classe ao definir os contratos de propriedades e comportamentos que esta classe deve implementar.
A classe abstrata, ao definir propriedades e métodos abstratos, também obrigada a sub-classe a implementa-los.

Encapsulamento:

Encapsular propriedades e comportamentos dentro de uma classe. Para isso, precisamos setar campos como privados e permitir o acesso de leitura a partir de outra propriedade com o get. Como esta classe é a responsável pelo correto funcionamento dela mesma, é necessário encapsular campos para evitar o mau uso por classes externas.

Polimorfismo:

Objetos poderam executar um comportamento interno de um método de objeto pai de formas diferentes.

#### Qual a diferença entre Mock e Stub?

Em teste unitários, a intenção é fazer o teste da classe e não de suas dependências. Por tanto, precisamos substituir as dependências por objetos falsos. Neste sentido, há por exemplo o Mock e o Stub.

Usamos o Mock para testar se um método do mock foi chamado e quantas vezes, se o parâmetros dos métodos do mock são os esperados e também pode setar um retorno falso.

O Stub é mais simples, criamos um classe falsa para simular o retorno geralmente com valores prédefinidos.

#### Qual a diferença entre Hash e Dicionário?

Em C#, Ambos HashTable e Dictionary são estruturas de armazenamento de dados pelo formato chave, valor.

O Hash não precisa setar o tipo de chave e valor ao contrário de Dicionário. Portanto, dicionário é mais performático por não precisar fazer boxing e unboxing.

Apenas dicionário mantém a ordem dos dados adicionados.

#### Qual a diferença entre const e readonly?

Propriedade Const deve ser inicializado em sua declaração. É uma constante em tempo de compilação.

Propriedade Readonly pode ser inicializada em sua declaração ou no construtor. Após rodar o construtor, a propriedade se torna uma constante e portanto não pode ser alterada.

#### O que é GC?

Garbage collector é o gerenciador de memória do .Net que libera memória ocupada por objeto no heap que não estão mais sendo usados. Não inclui portanto o gerenciamento de memória no stack.

#### Qual a diferença entre os tipos valor e referência?

Tipo referência são sempre alocados no heap

Tipo valor são sempre alocados na stack, exceto quando são propriedades de uma classe.


### Prática da Programação

#### Clean Code já te ajudou com algo?

Projetos que seguem clean code e boas guidelines são mais fáceis de serem lidos e de aplicar testes unitários por que não são códigos que só quem fez entende, tem funções e classes pequenas com responsabilidades bem definidas, pouca indentação nas funções, com um único nível de abstração por função, com comentários úteis e sem códigos comentados.

Também é mais fácil de fazer troubleshooting por que não tem atribuição a parâmetros dentro de funções o que tornaria difícil de rastrear todas as modificações feitas em um objeto.

#### O que acha de sistemas legado?

Primeiramente, é importante aplicar testes unitários e testes de integração para ganhar familiriaridade com o código e projeto.

Criar documentação dos principais fluxos de negócios.

Criação de documentos com guidelines do projeto:

- Guidelines das linguagens do back, front e banco de dados
- Guidelines da organização de pastas e arquitetura dos projetos

Exemplos de possíveis refatorações:

- Aplicar clean code
- Criar componentes no front ou classes no back para reuso de código
- Melhoria de performance no front ou em queries de banco e criação de index se necessários
- Mover arquivos (componentes e classes) caso estejam fora do padrão de pastas do projeto.
- Analisar se há espaço para melhorias de custos na aplicação

#### Quando aplicar e o que é microserviços?

Microserviços é quando se divide o sistema em aplicações separadas.

Sobre as vantagens de microserviços:

Flexibilidade - podem rodar em tecnologias diferentes e até com times diferentes.

Escalabilidade - pode escalar microserviços de forma independente.

Rapidez - Pode desenvolver uma feature nova dentro de uma aplicação menor que vai requerer menos testes e um deploy mais rápido.

Desvantagens:

Troubleshooting - Pode ser mais complicado pois o problema pode envolver diferentes microserviços ao mesmo tempo

Setup - Requer um planejamento de negócios elaborado para saber dividir os microserviços em dominios/funcionalidades desacoplados e coesos. Requer um esforço técnico para configuração da infraestrura e aplicações muito maior que um monolíto.

Complexidade - Requer uma maturidade maior para não gerar um monolíto que é separado em aplicações/máquinas distintas.

### Experiências

#### Qual seria o seu maior desafio proposto a si mesmo ao ingressar na empresa?


### More questions:

# Technical questions
1. What techniques would you use to make sure an API is reliable and scalabe for reading operations to support 1M requests a day with peak of 2000 concurrent users?
1. You have just been put in charge of a legacy code project which is difficult to maintain – what would you plan to improve in order to make the project easier to maintain in the long-term?
1. What is an acceptable response time for a ready-only API GET method in your opinion?
1. What is dependency injection? What are the benefits of using it?
1. Do you test your applications? What are the importance of tests in software development and the difference between each type of test? (Unit tests, E2E, Integration tests, Load Test)

# Role-specific questions
1. What metrics do you use to monitor a backend application performance?
1. What metrics do you use to monitor your teams performance?
1. Which tests are most important before deploying a new system or feature?
1. What tools and techniques do you use when reviewing someone else’s code?
1. What techniques do you use to onboard new developers on the team?

# Operational and situational questions
1. What would be your approach to a more junior developer on your team who kept questioning your decisions?
1. How would you negotiate a bigger budget for your team?
1. How do you document your programming work?
1. How do you give feedback to a developer that is not performing as expected?
1. How would you communicate with a team that is not doing a specific process as expected? For example, developers are not doing code reviews properly and you noticed that by all code reviews being approved in 5 or less minutes
1. How would you communicate with a product manager that is pushing a feature that is not properly described or the goal is not clear

# Behavioral questions
1. What do they do to sell new ideas to management? For example, if your manager asks you to select between two technologies, how would you do this? _This question tests how well a candidate presents a business case to use a particular type of technology, and what risks and values they consider when making the decision._
1. How do you stay up-to-date on new technologies related to full-stack web development?
1. What’s your biggest professional success so far? Why?
1. What was the last team project you worked on? What did you work on? In hindsight, how would you prioritize those tasks for better collaboration? _With these questions, you are finding out whether or not the candidate was a team player and collaborated well with others. You will also find out how they prioritize tasks, and how well they think through (and then explain) what they would do differently in the future._

# Career thinking
1. Where do you see yourself in 5 years? What you expect to be doing and on which role?
