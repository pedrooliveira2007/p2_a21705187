# LP2_P1_4X_Tiles

## Autoria

### Grupo

Afonso Rosa - a21802169  

Nuno Figueiredo - a21705451

Pedro Oliveira - a21705187

### Distribuição

#### Afonso Rosa

O aluno Afonso Rosa foi o responsável pelos scripts `CameraManager.cs` e pelas
versões iniciais e funcionamento chave do `FileHandler.cs` e
`ProcessMapInformation.cs` sendo estes *re-factored* pelo colega Pedro Oliveira.

#### Nuno Figueiredo

O aluno Nuno Figueiredo foi o responsável pela totalidade do UI do projeto,
tratou também dos scripts `FileListUI.cs`, `ForTheFuture.cs` e `Tile.cs` e dos
seus componentes. Colaborou com o aluno Pedro Oliveira de modo a assegurar-se
que a componente de UI não colidia com a componente código, e vice-versa.

#### Pedro Oliveira

O aluno Pedro Oliveira foi o responsável pela incorporação e manutenção do MVC
*pattern*, tratou ainda dos scripts `GameController.cs`, `Terrain,cs`,
`Resource.cs` e `FileListUI.cs` e tratou do *re-factor* dos scripts
`ProcessMapInformation.cs`, `FileHandler.cs` e do `Tile.cs` sendo estes
refeitos na sua semi-totalidade.

## Legenda dos *tiles*

![Legenda *tiles*](legenda.png)

## Arquitetura da solução

### Descrição da solução

O programa usa o MVC como base para o seu funcionamento e organização, o
`GameController.cs` funciona como o "*Controller*" do MVC *pattern* e gere o
funcionamento do projeto na sua totalidade, o `FileListUI.cs` e o
`ForTheFuture.cs` operam como os "*Views*" do MVC, sendo os únicos responsáveis
pela apresentação de dados ao utilizador, tudo o resto são os "*Models*" do
*design pattern* em questão, com as exceções do `Terrain.cs` e `Resources.cs`
que são enumeradores para auxiliar na geração das *tiles*.

O script `Tile.cs` é o responsável pelo funcionamento das *tiles* em si, apesar
disto a informação que estas necessitam para se instanciar é fornecida pelo
`ProcessMapInformation.cs`. Este, após filtrar as informações do ficheiro, passa
ao `Tile.cs` as palavras-chaves que levam à atribuição correta do tipo de
terreno de cada *tile* e aos recursos respetivos de cada tile. No `Tile.cs`,
especificamente no método `InitializeTile()`, o qual é chamado no
`ProcessMapInformation.cs`, são instanciadas as *tiles* sendo que antes de serem
instanciadas é lhes atribuído o tipo de terreno e recursos.

### UML

![UML](UML.png)

## Referências

Scripts feitos no ano passado foram reaproveitados pelos alunos, nomeadamente o
projeto do [Afonso Rosa](https://github.com/AppInfoMech/LP2_Project1_4XEngine).

Foram utilizados como apoio [este vídeo](https://www.youtube.com/watch?v=Oba1k4wRy-0)
e [este vídeo](https://www.youtube.com/watch?v=ZI6DwJtjlBA) do user
[c00pala](https://www.youtube.com/@c00pala) para a realização do Menu
*scrolável* e da disposição dos recursos na janela de informação das *tiles*.

Foi utilizado este [site](https://www.geeksforgeeks.org/mvc-design-pattern/)
de modo a facilitar a compreensão e incorporação do MVC *pattern*.
