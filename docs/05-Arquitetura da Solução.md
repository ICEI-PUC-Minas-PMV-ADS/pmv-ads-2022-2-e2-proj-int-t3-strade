# Arquitetura da Solução

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>

Definição de como o software é estruturado em termos dos componentes que fazem parte da solução e do ambiente de hospedagem da aplicação.

## Diagrama de Classes

[comment]: <> (O diagrama de classes ilustra graficamente como será a estrutura do software, e como cada uma das classes da sua estrutura estarão interligadas. Essas classes servem de modelo para materializar os objetos que executarão na memória.)

[comment]: <> (As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Classes”.)

[comment]: <> (> - [Diagramas de Classes - Documentação da IBM]https://www.ibm.com/docs/pt-br/rational-soft-arch/9.6.1?topic=diagrams-class)
[comment]: <> (> - [O que é um diagrama de classe UML? | Lucidchart]https://www.lucidchart.com/pages/pt/o-que-e-diagrama-de-classe-uml)

![Diagrama de Classes](img/diagrama%20de%20classes.jpg)

## Modelo ER (Projeto Conceitual)

[comment]: <> (O Modelo ER representa através de um diagrama como as entidades - coisas, objetos - se relacionam entre si na aplicação interativa.)

[comment]: <> (Sugestão de ferramentas para geração deste artefato: LucidChart e Draw.io.)

[comment]: <> (A referência abaixo irá auxiliá-lo na geração do artefato “Modelo ER”.)

[comment]: <> (> - [Como fazer um diagrama entidade relacionamento | Lucidchart] https://www.lucidchart.com/pages/pt/como-fazer-um-diagrama-entidade-relacionamento)

![Modelo Entidade Relacionamento](img/Modelo%20de%20Entidade%20e%20Relacionamento%20Strade.png)

## Projeto da Base de Dados

[comment]: <> (O projeto da base de dados corresponde à representação das entidades e relacionamentos identificadas no Modelo ER, no formato de tabelas, com colunas e chaves primárias/estrangeiras necessárias para representar corretamente as restrições de integridade.)
 
[comment]: <> (Para mais informações, consulte o microfundamento "Modelagem de Dados".)

![Projeto da Base de Dados](img/Projeto%20de%20Base%20de%20Dados.png)

## Tecnologias Utilizadas

* Ambiente .NET com foco em ASP.NET Core MVC
* Visual Studio Community
* SMARTER ASPNET para hospedagem
* Git e Github para versionamento de código

## Hospedagem

A hospedagem do banco de dados e da aplicação foi realizada na plataforma smarter aspnet https://www.smarterasp.net/index que possui um plano de 60 dias gratuitos.

> **Links Úteis**:
>
> - [Website com GitHub Pages](https://pages.github.com/)
> - [Programação colaborativa com Repl.it](https://repl.it/)
> - [Getting Started with Heroku](https://devcenter.heroku.com/start)
> - [Publicando Seu Site No Heroku](http://pythonclub.com.br/publicando-seu-hello-world-no-heroku.html)
