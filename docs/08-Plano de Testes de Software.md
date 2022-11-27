
# Plano de Testes de Software

| **Caso de Teste** 	| **CT-01 – Listar Transportadoras** 	|
|:---:	|:---:	|
|	Requisito Associado 	| *RF-001* - O sistema deve listar as transportadoras disponíveis para entrega no endereço indicado. |
| Objetivo do Teste 	| Verificar se as transportadoras são listadas. |
| Passos 	| - Acessar o navegador <br> - Informar o CEP no site da loja que possui a API do Strade<br> - Clicar em "Buscar" <br>  |
|Critério de Êxito | - Lista as transportadoras disponíveis. |
|  	|  	|
| **Caso de Teste** 	| **CT-02 – Cadastrar transportadora**	|
|Requisito Associado | *RF-002*	- O site do sistema deve permitir o cadastro de transportadoras locais. |
| Objetivo do Teste 	| Verificar se a transportadora consegue realizar cadastro. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site<br> - Clicar no botão "Cadastrar transportadora" <br> - Preencher os campos <br> - Clicar em "Cadastrar" |
|Critério de Êxito | - O cadastro foi realizado com sucesso. Aguardar contato da Strade. |
|  	|  	|
| **Caso de Teste** 	| **CT-03 – Atualização de Status dos itens**	|
|Requisito Associado | *RF-003* O site do sistema deve disponibilizar um meio para atualização dos status dos itens. |
| Objetivo do Teste 	| Verificar se o status está atualizando. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site<br> - Clicar no botão "Atualizar status" <br> - Buscar o pedido <br> - Atualizar o status <br> - Clicar em atualizar|
|Critério de Êxito | - O status deve mostrar o último informado. |
|  	|  	|
| **Caso de Teste** 	| **CT-04 – Hipersensibilidade**	|
|Requisito Associado | *RF-004* O site deve permitir a escolha do tema escuro ou claro para facilitar a navegação das pessoas com hipersensibilidade a luz. |
| Objetivo do Teste 	|  Verificar se o site Strade possui o recurso |
| Passos 	| - Acessar o site strade <br> - Selecionar o tema escuro/claro na barra de seleção .|
|Critério de Êxito | - O site deve atualizar com as cores alteradas. |
|  	|  	|
| **Caso de Teste** 	| **CT-08 – Regras de negócio para Transportadoras**	|
|Requisito Associado | *RNF-001* O sistema deve ter uma lista com uma regra de negócios para o cadastro das transportadoras. |
| Objetivo do Teste 	|  Verificar se as regras estão sendo disponibilizadas corretamente |
| Passos 	| - Acessar o site Strade <br> - Clicar em Cadastrar Transportadora <br> -  Clicar em "Termos de negócio".|
|Critério de Êxito | - O site deve mostrar o texto com as regras de negócio como pré-requisitos para o cadastro da transportadora. |
|  	|  	|
| **Caso de Teste** 	| **CT-09 – Responsividade**	|
|Requisito Associado | *RNF-002* O site do sistema de cadastro das transportadoras deverá ser responsivo, permitindo a visualização em um celular de forma adequada. |
| Objetivo do Teste 	|  Atestar que o site está responsivo |
| Passos 	| - Acessar o site Strade <br> - Clicar em Cadastrar Transportadora|
|Critério de Êxito | - O site deve se mostrar responsivo em dispositivos móveis. |
|  	|  	|
| **Caso de Teste** 	| **CT-11 – Banco de dados Relacional**	|
|Requisito Associado | *RNF-004* O sistema deve ter um banco de dados relacional que permita que a API o consulte. |
| Objetivo do Teste 	|  Atestar que os bancos estão sendo consultados corretamente |
| Passos 	| - Acessar o navegador <br> - Informar o CEP no site da loja que possui a API do Strade<br> - Clicar em "Buscar" <br>|
|Critério de Êxito | - A busca deve ser um sucesso (200 OK) |

<!--- 
[comment]: <> (**Links Úteis**: )
[comment]: <> (> - [IBM - Criação e Geração de Planos de Teste](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
[comment]: <> (> - [Práticas e Técnicas de Testes Ágeis](http://assiste.serpro.gov.br/serproagil/Apresenta/slides.pdf) )
[comment]: <> (> -  [Teste de Software: Conceitos e tipos de testes](https://blog.onedaytesting.com.br/teste-de-software/) )
[comment]: <> (> - [Criação e Geração de Planos de Teste de Software](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html) )
[comment]: <> (> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/) )
[comment]: <> (> - [UX Tools](https://uxdesign.cc/ux-user-research-and-user-testing-tools-2d339d379dc7) ) --->
