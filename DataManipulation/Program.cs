
using System.Collections;

var diasSemana = new string[]
{
    "Domingo","Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"
};

/* O ArrayList era utilizado antigamente mas ele não restringe
 o tipo de um elemento em uma coleção, então muitas vezes era necessário 
verificar o tipo do elemento, o que dava mais trabalho*/


var carrinho = new List<Produto>()
{
    new Produto() {Nome="Arroz", Preco=32.60},
    new Produto() {Nome="Feijão", Preco=8.90}
};

/* Coleções do tipo List como */
class Produto
{
    public string Nome { get; set; }
    public double Preco { get; set; }
}