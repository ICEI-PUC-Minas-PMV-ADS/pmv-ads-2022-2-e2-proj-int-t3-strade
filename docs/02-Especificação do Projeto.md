# Especificações do Projeto

A seguir estão apresentadas as personas que foram encontradas durante a pesquisa de resolução e entendimento do problema.

## Personas

| Júlio Assis | Idade:58 |Persona 1 - Consumidor|
|:---:|:---:|:---:|
| ![Persona Júlio Assis](img/persona-julio-assis.png)| **Ocupação:**  Motorista de ônibus da empresa RandBus.| **Aplicativos:** Facebook, WhatsApp, YouTube |
| **Motivações**| **Frustrações** | **Hobbies e História** |
| Ser um bom motorista. | Sempre que compra um produto pela internet não consegue saber onde está o pacote, as informações nunca estão claras. | Adora praticar esportes ao ar livre. Gosta de bicicleta e ama comprar acessórios para ela. |

| Matheus Pereira | Idade:23 |Persona 2 - Lojista|
|:---:|:---:|:---:|
| ![Persona Matheus Pereira](img/persona-matheus-pereiira.png)| **Ocupação:**  MEI em um e-commerce de artigos de pesca que atende a região de Belo Horizonte. | **Aplicativos:**  Instagram, LinkedIn, YouTube |
| **Motivações**| **Frustrações** | **Hobbies e História** |
| Oferecer os melhores experiências de compra para seus clientes. | Muitas vezes ocorrem avarias na entrega dos seus produtos. | Pescar com suas família. |

| Chiara Fernandes | Idade: 34 |Persona 3 - Transportadora|
|:---:|:---:|:---:|
| ![Persona Chiara Fernandes](img/persona-chiara-fernandes.png) | **Ocupação:** CEO de uma transportadora com 12 empregados e 4 vans de transporte. | **Aplicativos:** Telegram, YouTube, Instagram, Aplicativos de bancos, LinkedIn |
| **Motivações**| **Frustrações**| **Hobbies e História** |
| Ter seus clientes satisfeitos com as entregas feitas de forma rápida, eficaz e sem danos ao produto. | Sente que perde muito tempo em diversas reuniões com lojas parceiras. | Gosta de viajar a lugares novos, conhecer pessoas e sempre viajar com sua primeira van, um presente de seu pai. |

| Adriana Andrade | Idade: 42 |Persona 4 - Transportadora|
|:---:|:---:|:---:|
| ![Persona Adriana Andrade](img/persona-adriana-andrade.png) | **Ocupação:** CEO de uma transportadora com 40 empregados com múltiplos veículos de diferentes portes.| **Aplicativos:** Telegram, YouTube, LinkedIn, Whatsapp, Teams, Instagram |
| **Motivações**| **Frustrações**| **Hobbies e História** |
| Sua maior motivação está na satisfação dos lojistas. Para Adriana, se o lojista está satisfeito é porque seus clientes estão satisfeitos. | Sente que perde muito tempo para resolver problemas que poderiam ser resolvidos rapidamente com o contato direto com o cliente. | Paintball com os amigos. Gosta de frequentar restaurantes elegantes. Comidas apimentadas. |

| Diego Novaes | Idade: 21 |Persona 5 - Consumidor|
|:---:|:---:|:---:|
| ![Persona Diego Novaes](img/persona-diego-novaes.png) | **Ocupação:** Desenvolvedor de Jogos para uma empresa de grande porte. | **Aplicativos:** Roblox, Minecraft, Tiktok, Instagram, Teams |
| **Motivações**| **Frustrações**| **Hobbies e História** |
| Quer transformar a vida das crianças e dos adolescentes através de seus jogos. Aplica sua criatividade em todos os seus trabalhos. | Sente-se frustrado com a falta de opções de frete na hora da compra de seus equipamentos para o trabalho. | Começou a desenvolver aos 15 anos com aplicativos de desenvolvimento como Unreal Engine. Hoje está no início de seus sonhos. Sua única paixão são os jogos. |

| Tamara Furtado | Idade: 29 |Persona 6 - Consumidor (necessidade especial)|
|:---:|:---:|:---:|
| ![Persona Tamara Furtado](img/persona-tamara-furtado.png) | **Ocupação:** Estudante universitária em engenharia ambiental | **Aplicativos:** Instagram, Facebook, Netflix |
| **Motivações**| **Frustrações**| **Hobbies e História** |
| Ser cliente de empresas que pensam em diversidade, inclusão e acessibilidade para que isso aconteça cada vez mais. | Não ter informação de quais empresas são inclusivas. | Ver filmes e jogar basquete com seu grupo de amigos. |

| Kim Oculamat | Idade: 32 |Persona 7 - Lojista|
|:---:|:---:|:---:|
| ![Persona Kim Oculamat](img/persona-kim-oculamat.png)| **Ocupação:**  Fisioterapeuta, vende artigos de fisioterapia, musculação e esportes. | **Aplicativos:** Mercado livre, Ifood, Drogaria Araújo, Instagram, Youtube e Twitter  |
| **Motivações**| **Frustrações** | **Hobbies e História** |
| Que seus clientes recebam suas encomendas num prazo minimo (dentro prazo) e em bom estado | Não ter acesso a qualidade do serviço das transportadoras | Iniciou sua carreira na fisioterapia por conta da musculação e sua paixão pelo futebol americano, que se tornaram um hobbie |

## Histórias de Usuários

Registramos as histórias das personas encontradas para o projeto e analisamos suas histórias. 

| EU COMO... `PERSONA` | QUERO/PRECISO ... `FUNCIONALIDADE` | PARA ... `MOTIVO/VALOR`                |
| -------------------- | ---------------------------------- | -------------------------------------- |
|**Júlio Assis**| saber onde está o meu pacote. | ficar tranquilo sabendo que o pacote está seguro e chegará no tempo certo.|
|**Matheus Pereira**| quando comprar ou vender, não ocorra avarias nos produtos. | para evitar transtornos devido a burocracia para resolver o problema. |
|**Chiara Fernandes**| reduzir a quantidade de reuniões com lojistas para um único contrato | economizar tempo e conseguir focar em outros assuntos que podem ser otimizados.|
|**Adriana Andrade**| ter contato com o cliente | resolver seus problemas de forma mais eficiente.|
|**Diego Furtado**| maior quantidade de opções de frete | escolher aquele que atender melhor sua necessidade de tempo. |
|**Tamara Furtado**| Seja possível identificar quais transportadoras possuem funcionários que se encaixam em PCD. | poder escolher a empresa baseado nessa informação. |
|**Kim Oculamat**| Seja possivel ver as avaliaçoes feitas por clientes das transportadoras | Para ter acesso a qualidade do serviço prestado ao cliente |

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

| **ID** | **Descrição do Requisito** | **Prioridade** |
| ------ | -------------------------- | -------------- |
| **RF-001** | O sistema deve listar as transportadoras disponíveis para entrega no endereço indicado. | ALTA |
| **RF-002** | O site do sistema deve permitir o cadastro de transportadoras locais. | ALTA |
| **RF-003** | O site do sistema deve disponibilizar uma página para atualização dos status dos itens. | ALTA |
| **RF-004** | O sistema deve permitir a avaliação da transportadora depois da entrega. | ALTA |
| **RF-005** | O sistema deve disponibilizar meios de contato com o cliente, seja para a transportadora, seja para a loja. | ALTA |
| **RF-006** | O sistema deve permitir a escolha do tema escuro ou claro para facilitar a navegação das pessoas com hipersensibilidade a luz. | ALTA |
| **RF-007** | O sistema deve gerar um relatório das comunicações feitas pela transportadora ou pelos lojistas. | ALTA |

### Requisitos não Funcionais

| **ID** | **Descrição do Requisito** | **Prioridade** |
| ------ | -------------------------- | -------------- |
| **RNF-001** | O sistema deve ter uma lista com uma regra de negócios para o cadastro das transportadoras. | ALTA |
| **RNF-002** | O site do sistema de cadastro das transportadoras deverá ser responsivo, permitindo a visualização em um celular de forma adequada. | ALTA |
| **RNF-003** | A lista de transportadoras deve indicar quais delas possuem funciorários PCD. | ALTA |
| **RNF-004** | O sistema deve ter um banco de dados relacional que permita que a API o consulte. | ALTA |
| **RNF-005** | A equipe somente deve utilizar as linguagens HTML, CSS, JS e C#. | Alta |

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

| **ID** | **Restrição** |
| ------ | ------------- |
| 01  | O projeto completo deve ser entregue no dia 11/12/2022. | Alta |
| 02  | A equipe não pode terceirizar o desenvolvimento do projeto. | Alta |

## Diagrama de Casos de Uso

![](img/diagramaCasosUso.png)
