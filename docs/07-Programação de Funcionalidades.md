# Programação de Funcionalidades

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="4-Metodologia.md"> Metodologia</a>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="5-Arquitetura da Solução.md"> Arquitetura da Solução</a>

### Requisitos Funcionais

| **ID** | **Descrição do Requisito** | **Artefato(s) Produzido(s)** |
| ------ | -------------------------- | -------------- |
| **RF-001** | O sistema deve listar as transportadoras disponíveis para entrega no endereço indicado. | src\exemplo\index.html + \js\script.js |
| **RF-002** | O site do sistema deve permitir o cadastro de transportadoras locais. | index.html + src\code\strade.js |
| **RF-003** | O site do sistema deve disponibilizar um meio para atualização dos status dos itens. | src\code\stradeAPI\controllers\pedidoController.cs |
| **RF-004** | O sistema deve permitir a escolha do tema escuro ou claro para facilitar a navegação das pessoas com hipersensibilidade a luz. | src\code\script\darkmode.js |

# Instruções de acesso
Por se tratar de uma funcionalidade, a solução proposta pela equipe contém uma interface de atuação superior à apenas o site da empresa Strade. Para o melhor entendimento sobre o funcionamento da solução proposta pela equipe, é necessário alguns dados de caso de uso, a saber, o cadastro prévio de uma loja e de um cliente.

Para a parte da loja. Criamos uma página-exemplo que simula um carrinho de compra na fase final de aquisição de um produto (tênis esportivo da marca Nike). O site-exemplo da loja pode ser acessado no link abaixo.

Link do site da loja parceira: http://brunoruas-001-site1.etempurl.com/src/exemploloja/index.html
Fluxo de utilização

Fluxo no site da loja parceira:

    No site da loja, o cliente escolhe a região da cidade de Belo Horizonte em que deseja a entrega do seu produto.
    Ao selecionar a região, deve-se clicar no botão de busca logo abaixo.
    Ao clicar no botão, uma lista dinâmica com as transportadoras cadastradas como atendentes da referida região.
    Ao selecionar a transportadora, basta clicar no botão selecionar no canto inferior esquerdo.
    Por fim, basta clicar no botão comprar no canto inferior direito do site da loja.
    Ao clica-lo, um pop-op contento o número do pedido do cliente aparecerá (esse número será usado para controle do status da entrega).

Fluxo Transportadora no site da Strade:

    O cadastro de uma nova transportadora é realizado na terceira opção do menu superior.
    Para habilitar o formulário de inscrição, a transportadora deve aceitar as regras de negócio no radio button ao lado esquerdo do formulário.
    Uma vez aceitas as regras, o formulário estará disponível ao preenchimento das informações.
    Ao término do preenchimento, deve-se clicar no botão cadastrar abaixo do formulário.
    Um pop-up com a mensagem "Sua transportadora foi cadastrada" aparecerá na página indicando o sucesso do cadastro no banco de dados.

Fluxo Cliente no site da Strade:

    Caso o cliente queira acessar o status da sua entrega, ele deverá clicar na opção de login no menu superior.
    Para o caso-modelo, o usuário "Sr Barriga" foi cadastrado cujo email de acesso é "barriga@gmail.com" e senha "teste123".
    Ao clicar na opção de login, aparecerá um formulário de login que deve ser preenchido com o email e senha do cliente.
    Ao clicar no botão logar, um pop-up de sucesso ou fracasso do login aparecerá e o cliente será direcionado para a tela de consulta de pedido.
    De posse do número do pedido na página da loja parceira, basta coloca-lo no input de texto e clicar em buscar.
    Uma mensagem com um dos 4 status da entrega aparecerá.

