
using System.Collections;



/* O ArrayList era utilizado antigamente, mas ele não restringe
 o tipo de um elemento em uma coleção, então muitas vezes era necessário 
verificar o tipo do elemento antes de manipular ele, o que dava mais trabalho. 
PS: a coleção acima não é uma ArrayList() ela é só um Array*/

var diasDaSemana = new DiasDaSemana();

foreach (string dia in diasDaSemana) //IEnumerable<string>
{
    Console.WriteLine(dia);
}
// esse foreach na verdade é uma simplificação do C#, na realidade ele está
// fazendo basicamente isso daqui 


var carrinho = new List<Produto>()
{
    new Produto() {Nome="Arroz", Preco=32.60},
    new Produto() {Nome="Feijão", Preco=8.90}
    //"Quarta" -> Se fosse um ArrayList eu conseguiria fazer isso
};

/* Coleções do tipo List, como carrinho, são mais utilizadas em relação a coleções
 do tipo Array, porque o Array é uma coleção que você precisa manipular 
manualmente o seu tamanho*/

/* Para acessar elementos de uma lista é necessário utilizar por meio de um acesso
 indexado, no C# o index começa pelo número 0*/

void PercorrerComFor()
{
    for (int i = 0; i < carrinho.Count; i++)
    {
        var produto = carrinho[i];
        Console.WriteLine($"Produto: {produto.Nome}");
    }
}
void PercorrerComForeach()
{

    foreach (var produto in carrinho)
    {
        Console.WriteLine(produto);
    }
}
PercorrerComForeach();

class Produto
{
    public string Nome { get; set; }
    public double Preco { get; set; }
}

class DiasDaSemanaEnumerado : IEnumerator<string> // Essa classe é resposável por enumerar uma coleção
{
    private int posicao = -1;
    private string[] dias = { "Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado" };
    
    // Current significa atual
    public string Current => dias[posicao]; 

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public bool MoveNext()
    {
        posicao++;
        return posicao < dias.Length;
    }

    public void Reset()
    {
        posicao = -1;
    }
}

// para acessar Dias da semana - que é uma classe que estou usando para encapsular os dados - em um foreach eu preciso implementar a interface IEnumerable
// só que o IEnumerable tem um método GetEnumerator que retorna um IEnumerator
class DiasDaSemana : IEnumerable<string> 
{
    public IEnumerator<string> GetEnumerator()
    {
        return new DiasDaSemanaEnumerado();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}