# Strade

`ANÁLISE E DESENVOLVIMENTO DE SISTEMAS`

`PROJETO: DESENVOLVIMENTO DE UMA APLICAÇÃO INTERATIVA`

`EIXO 2`

O objetivo desse projeto é permitir que as lojas de e-commerce possam direcionar os esforços, que hoje são utilizados para manutenção de contratos de transporte, em atividades mais relevantes com a atividade primária dos seus negócios. Temos como metas: 

 - Atuar como hub de transportadoras locais de vários portes e modais de entrega; 
 - Produzir uma solução de software que se integre ao ecossistema de vendas online das lojas; 
 - Produzir uma solução de software que comunique às transportadoras os dados necessários à cada entrega; 
 - Receber das operadoras o status de processamento dos pedidos; 
 - Possuir uma interface de comunicação com o cliente para acompanhamento do seu pedido 

## Integrantes

* [Bruno de Melo Ruas](https://www.linkedin.com/in/brunoruas2/)
* [Diego Menezes Soares](https://www.linkedin.com/in/diego-soares-1913451b7)
* [Gabriel da Silva Oliveira](https://www.linkedin.com/in/gsogabriel/)
* [Lucas Célio Neves Silva](https://www.linkedin.com/in/lucascns/)
* [Marina Gonçalves Duque](https://www.linkedin.com/in/marina-duque-1b2ab6156)
* [Mikaelly da Silva Carneiro](https://www.linkedin.com/in/MikaellyCarneiro)
* [Thassia Diandra Ferreira](https://www.linkedin.com/in/thassiaferr)

## Orientador

* José Wilson Da Costa

## Instruções de utilização

Link de acesso: http://brunoruas-001-site1.etempurl.com/

Por se tratar de uma funcionalidade, a solução proposta pela equipe contém uma interface de atuação superior à apenas o site da empresa Strade. Para o melhor entendimento sobre o funcionamento da solução proposta pela equipe, é necessário alguns dados de caso de uso, a saber, o cadastro prévio de uma loja e de um cliente.

Para a parte da loja. Criamos uma página-exemplo que simula um carrinho de compra na fase final de aquisição de um produto (tênis esportivo da marca Nike). O site-exemplo da loja pode ser acessado no link abaixo.

Link do site da loja parceira: http://brunoruas-001-site1.etempurl.com/src/exemploloja/index.html

### Fluxo de utilização

Fluxo no site da loja parceira:
* No site da loja, o cliente escolhe a região da cidade de Belo Horizonte em que deseja a entrega do seu produto.
* Ao selecionar a região, deve-se clicar no botão de busca logo abaixo.
* Ao clicar no botão, uma lista dinâmica com as transportadoras cadastradas como atendentes da referida região.
* Ao selecionar a transportadora, basta clicar no botão selecionar no canto inferior esquerdo.
* Por fim, basta clicar no botão comprar no canto inferior direito do site da loja.
* Ao clica-lo, um pop-op contento o número do pedido do cliente aparecerá (esse número será usado para controle do status da entrega).

Fluxo Transportadora no site da Strade:
* O cadastro de uma nova transportadora é realizado na terceira opção do menu superior.
* Para habilitar o formulário de inscrição, a transportadora deve aceitar as regras de negócio no radio button ao lado esquerdo do formulário.
* Uma vez aceitas as regras, o formulário estará disponível ao preenchimento das informações.
* Ao término do preenchimento, deve-se clicar no botão cadastrar abaixo do formulário.
* Um pop-up com a mensagem "Sua transportadora foi cadastrada" aparecerá na página indicando o sucesso do cadastro no banco de dados.

Fluxo Cliente no site da Strade:
* Caso o cliente queira acessar o status da sua entrega, ele deverá clicar na opção de login no menu superior.
* Para o caso-modelo, o usuário "Sr Barriga" foi cadastrado cujo email de acesso é "barriga@gmail.com" e senha "teste123".
* Ao clicar na opção de login, aparecerá um formulário de login que deve ser preenchido com o email e senha do cliente.
* Ao clicar no botão logar, um pop-up de sucesso ou fracasso do login aparecerá e o cliente será direcionado para a tela de consulta de pedido.
* De posse do número do pedido na página da loja parceira, basta coloca-lo no input de texto e clicar em buscar.
* Uma mensagem com um dos 4 status da entrega aparecerá.

# Documentação

<ol>
 <li><a href="docs/01-Documentação de Contexto.md"> Documentação de Contexto</a></li>
 <li><a href="docs/02-Especificação do Projeto.md"> Especificação do Projeto</a></li>
 <li><a href="docs/03-Metodologia.md"> Metodologia</a></li>
 <li><a href="docs/04-Projeto de Interface.md"> Projeto de Interface</a></li>
 <li><a href="docs/05-Arquitetura da Solução.md"> Arquitetura da Solução</a></li>
 <li><a href="docs/06-Template Padrão da Aplicação.md"> Template Padrão da Aplicação</a></li>
 <li><a href="docs/07-Programação de Funcionalidades.md"> Programação de Funcionalidades</a></li>
 <li><a href="docs/08-Plano de Testes de Software.md"> Plano de Testes de Software</a></li>
 <li><a href="docs/09-Registro de Testes de Software.md"> Registro de Testes de Software</a></li>
 <li><a href="docs/10-Plano de Testes de Usabilidade.md"> Plano de Testes de Usabilidade</a></li>
 <li><a href="docs/11-Registro de Testes de Usabilidade.md"> Registro de Testes de Usabilidade</a></li>
 <li><a href="docs/12-Apresentação do Projeto.md"> Apresentação do Projeto</a></li>
 <li><a href="docs/13-Referências.md"> Referências</a></li>
</ol>

# Código

<li><a href="src/README.md"> Código Fonte</a></li>

# Apresentação

<li><a href="presentation/README.md"> Apresentação da solução</a></li>
