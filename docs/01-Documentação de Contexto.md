# Introdução

O comércio eletrônico direto para o consumidor final vem se tornando a maior fatia de receita de várias empresas que se consolidaram mesmo no setor de vendas diretas antes da revolução das comunicações trazida pela popularização da internet (Portal G1, 2021). Além dessas empresas tradicionais, novas marcas decidiram atuar especificamente no segmento virtual, sendo a Amazon a principal empresa desse segmento.

## Problema

Diante dessa modernização do consumo de bens diretos ao consumidor final, novos desafios surgiram. Alguns dos mais relevantes são diretamente relacionados a estrutura de transporte e entrega das compras em tempo oportuno e de maneira satisfatória ao consumidor. 

Atualmente, as lojas virtuais optam por fazer uso de algumas estratégias de entrega dos seus produtos como: 

 - Possuem a própria infraestrutura de entregas; 

 - Terceirizam suas entregas por meio de contratos diretos com distribuidoras; 

 - Usam os serviços de empresas de microsserviços como Uber, Rappi e outros  

## Objetivos
O objetivo é permitir que as lojas de e-commerce possam direcionar os esforços que hoje são direcionados para manutenção de contratos de transporte em atividades mais relevantes com a atividade primária dos seus negócios. Temos como metas: 

 - Atuar como hub de transportadoras locais de vários portes e modais de entrega; 

 - Produzir uma solução de software que se integre ao ecossistema de vendas online das lojas; 

 - Produzir uma solução de software que comunique às transportadoras os dados necessários à cada entrega; 

 - Receber das operadoras o status de processamento dos pedidos; 

 - Possuir uma interface de comunicação com o cliente para acompanhamento do seu pedido 

## Justificativa

A solução proposta para o problema supracitado consiste em diferentes camadas de desenvolvimento e atuação. 

No lado das lojas virtuais, serão produzidos iframes em html com a lógica de negócio necessária para comunicação com as APIs desenvolvidas pelo time de desenvolvimento que permitirão a produção de uma lista de opções de transportadoras a partir das condições de entrega definidas pelo cliente no momento da compra. 

No lado das transportadoras, primeiramente, serão feitos os cadastros necessários para a elaboração da regra de negócio e filtros no momento da definição da lista de transportadoras possíveis para cada entrega solicitada. Além disso, uma camada de atualização do status de cada pacote de entrega bem como a confirmação de entrega. Desse modo, são reduzidos alguns dos principais problemas enfrentados por parte das empresas de transporte (Hivecloud, 2022).

No lado do consumidor final, a sinalização do serviço de entrega bem como o informe sempre que o status da encomenda sofrer alteração. Como método de melhoria, também será obtida uma nota pelo serviço de entrega para melhor manutenção do ecossistema de transportadoras parceiras da solução. 

## Público Alvo

Como a proposta é relativa ao modelo B2B de intermediação de serviços, têm-se duas frentes de público alvo. Na frente de clientes da solução, o projeto tem como público alvo lojas de e-commerce que oferecem entregas em cidades cobertas por contratos com transportadoras parceiras. Na frente de fornecedores, o público alvo são distribuidoras de todos os portes que possuírem capacidade mínima de tecnologia de informação. 
