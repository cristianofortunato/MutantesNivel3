Mutantes Nivel 3

Projeto desenvolvido em .Net Core 

Este API retorna status HTTP Code 200 quando a matriz está de acordo com o especificado ou http code 403 quando não possui o padrão esperado.
Caso ocorra um erro no processamento é retornado um status code 500.
Para realizar o teste em ambiente local, usar o endereço: 

<code>http://localhost:36042/mutant</code>

Exemplo de requisição:<br>
<code>
{ "dna":["ATGCGA","CAGTGC","TTATGT","AGAAGG","CCTCTA","TCACTG"] }
</code>
<i> Enviar como application/json </i>

Este projeto possui um banco de dados interno, onde todas as requisições são guardadas para geração de estatistica conforme explicado abaixo:

* Pelo Link <code>http://localhost:36042/mutant/stats</code> é possível saber todas as requisições que a API recebeu e é calculado em tempo real a média de requisições para cada grupo de DNA.

Para facilitar os testes, o projeto esta publicado no endereço: 

[POST]
<code>
  http://mutantes-nivel3.azurewebsites.net/mutant
</code>

[GET]
<code>
  http://mutantes-nivel3.azurewebsites.net/mutant/stats
</code>

