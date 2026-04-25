
using System.Collections;

var diasSemana = new string[]
{
    "Domingo","Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"
};

/* O ArrayList era utilizado antigamente, mas ele não restringe
 o tipo de um elemento em uma coleção, então muitas vezes era necessário 
verificar o tipo do elemento antes de manipular ele, o que dava mais trabalho. 
PS: a coleção acima não é uma ArrayList() ela é só um Array*/


var carrinho = new List<Produto>()
{
    new Produto() {Nome="Arroz", Preco=32.60},
    new Produto() {Nome="Feijão", Preco=8.90}
    //"Quarta" -> Se fosse um ArrayList eu conseguiria fazer isso
};

/* Coleções do tipo List, como carrinho, são mais utilizadas em relação a coleções
 do tipo Array, porque o Array é uma coleção que você precisa manipular 
manualmente o seu tamanho*/
class Produto
{
    public string Nome { get; set; }
    public double Preco { get; set; }
}