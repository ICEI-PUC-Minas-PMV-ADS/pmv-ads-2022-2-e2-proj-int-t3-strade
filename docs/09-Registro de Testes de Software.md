# Registro de Testes de Software Primeira Etapa

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>, <a href="8-Plano de Testes de Software.md"> Plano de Testes de Software</a>

Para cada caso de teste definido no Plano de Testes de Software, realize o registro das evidências dos testes feitos na aplicação pela equipe, que comprovem que o critério de êxito foi alcançado (ou não!!!). Para isso, utilize uma ferramenta de captura de tela que mostre cada um dos casos de teste definidos (obs.: cada caso de teste deverá possuir um vídeo do tipo _screencast_ para caracterizar uma evidência do referido caso).

## CT-01 - Lista de Trasportadoras - Site Loja

### Preenchimento da Região - Site Loja

><img src="./img/site-loja.png" height="100%" width="100%">

A referida funcionalidade foi substituída por uma simplificação de busca por regiões ao invés de ceps.

## CT-02 – Cadastrar transportadora

### Cadastro Preenchido
><img src="./img/cadastro-preenchido.jpg" height="100%" width="100%">

### Aviso Cadastro Errado
Todos os campos de cadastro são validados e geram alerta de erro caso preenchido incorretamente.
><img src="./img/cadastro-incorreto.jpg" height="100%" width="100%">

### Aviso Cadastro Concluido

><img src="./img/cadastro-concluido.jpeg" height="100%" width="100%">


## CT-03 – Atualização de Status dos itens

### Alterar Status do pedido
><img src="./img/alterar-status-pedido.jpg" height="100%" width="100%">

### Consultar Status do Pedido - Cliente
 ><img src="./img/consultar-pedido.jpg" height="100%" width="100%">
## CT-06 - Verificar a função de Hipersensibilidade -Dark Mode 

>### Dark Mode Inativo:
><img src="./img/Dark-mode-inativo.png" height="100%" width="100%">
>
>### Dark Mode ativo
><img src="./img/Dark-mode-ativo.png" height="100%" width="100%">
>


### Listagem Transportadoras

><img src="./img/Lista-Transportadora.png" height="100%" width="100%">


## Avaliação 1° Etapa
 ### CT-01 Verificar listagem das trasportadoras

 O sistema lista as transportadoras disponíveis para entrega no endereço indicado. Porém ainda não conseguimos listar mais que uma trasportadora e ao cadastrar nova, só aparece a primeira cadastrada.


 # Registro de Testes de Software Última Etapa

### CT-01 Verificar listagem das trasportadoras

 As trasportadoras estão sendo listadas. Atualização no Front-end para processamento de um Array de tamanho *n*. 

![image](https://user-images.githubusercontent.com/16859514/204167014-f7405628-3754-40e8-b304-8b59acbd5912.png)

 ### CT-02 Cadastrar transportadora

Cadastro da trasportadora funcionando perfeitamente.

><img src="./img/cadastro-concluido.jpeg" height="100%" width="100%">

### CT-03 – Atualização de Status dos itens

 Atualização implementada com sucesso.

 ><img src="./img/alterar-status-pedido.jpg" height="100%" width="100%">

### CT-06 Verificar a função de Hipersensibilidade -Dark Mode
 
 O site Strade possui o recurso de Dark Mode e de acordo com os testes executados o site atualizou corretamente com as cores alteradas.
 
 ![image](https://user-images.githubusercontent.com/16859514/204166959-98cb0c21-4458-4d33-a3a2-9341d32da9a3.png)

### CT-08 – Regras de negócio para Transportadoras

No site aparece a regra de negocio da transportadora.
><img src="./img/regras-de-negocio.jpg" height="100%" width="100%">

### CT-09 – Responsividade
 Site permitindo a visualização em um celular de forma adequada.

><img src="./img/responsividade.jpg" height="100%" width="100%">

><img src="./img/responsividade2.jpg" height="100%" width="100%">


## CT-11 - Banco de Dados Relacional

![image](https://user-images.githubusercontent.com/16859514/206872140-ac8f4e30-6fb7-4313-ae13-fa6d98490a6e.png)


## Avaliação Última Etapa

Todos os testes dos requisitos finalizados foram bem sucedidos.