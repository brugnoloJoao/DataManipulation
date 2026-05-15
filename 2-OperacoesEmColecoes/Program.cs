/*
Seja um aplicativo de gerenciamento de músicas onde os usuários podem organizar suas faixas
favoritas em playlists personalizadas. Para cada playlist, é essencial que o usuário tenha
controle total sobre a sequência de reprodução das músicas, permitindo reordená-las
livremente a qualquer momento. Além disso, o aplicativo precisa oferecer a funcionalidade de
reprodução aleatória para uma playlist específica, proporcionando uma experiência de audição
dinâmica e variada, sem, contudo, alterar a ordem original que o usuário definiu. O desafio
é criar uma estrutura robusta que suporte a adição e remoção eficiente de músicas, a
reordenação flexível dentro das playlists e a seleção de faixas tanto em modo sequencial
quanto aleatório.
*/

// Funcoes que vamos implementar:
// [x] Criar as classes para musicas e playlist
// [x] Listar musicas da playlist
// [x] Adicionar musica à playlist
// [x] Obter uma musica especifica da playlist
// [x] Remover musica da playlist
// [x] Tocar uma musica aleatoria da playlist
// [ ] Reordenar musicas segundo alguma logica especifica (ex. duracao)
// [ ] Uma playlist nao pode ter musicas repetidas
// [ ] Exibir as 10 musicas mais tocadas em todas as playlists (ranking)
// [ ] Player de musica com:
// [ ] - Fila de reproducao (para musicas avulsas e/ou playlists)
// [ ] - Historico de reproducao


using System.ComponentModel;

Musica musica1 = new Musica { Titulo = "Bohemian Rhapsody", Artista = "Queen", Duracao = TimeSpan.FromMinutes(5.55) };

Musica musica2 = new Musica { Titulo = "Imagine", Artista = "John Lennon", Duracao = TimeSpan.FromMinutes(3.03) };

Musica musica3 = new Musica { Titulo = "Stairway to Heaven", Artista = "Led Zeppelin", Duracao = TimeSpan.FromMinutes(8.02) };

Musica musica4 = new Musica { Titulo = "Smells Like Teen Spirit", Artista = "Nirvana", Duracao = TimeSpan.FromMinutes(5.01) };

Musica musica5 = new Musica { Titulo = "Sweet Child o' Mine", Artista = "Guns N' Roses", Duracao = TimeSpan.FromMinutes(5.56) };

Musica musica6 = new Musica { Titulo = "November Rain", Artista = "Guns N' Roses", Duracao = TimeSpan.FromMinutes(8.57) };

Musica musica7 = new Musica { Titulo = "Creep", Artista = "Radiohead", Duracao = TimeSpan.FromMinutes(3.56) };

Musica musica8 = new Musica { Titulo = "Under the Bridge", Artista = "Red Hot Chili Peppers", Duracao = TimeSpan.FromMinutes(4.24) };

var rockInternacional = new Playlist { Nome = "Rock Internacional" };
rockInternacional.Add(musica1);
rockInternacional.Add(musica2);
rockInternacional.Add(musica3);
rockInternacional.Add(musica4);
rockInternacional.Add(musica5);
rockInternacional.Add(musica6);
rockInternacional.Add(musica7);
rockInternacional.Add(musica8);

ExibirPlaylist(rockInternacional);

var musicaEncointrada = rockInternacional.ObterPeloTitulo("Imagine");
if (musicaEncointrada is not null)
{
    Console.WriteLine($"Música encontrada: {musicaEncointrada.Titulo} - {musicaEncointrada.Artista}");
    Console.WriteLine("Removendo Música...");
    rockInternacional.Remove(musicaEncointrada);
}


ExibirPlaylist(rockInternacional);


var musicaAleatoria = rockInternacional.ObterAleatorio;
if (musicaAleatoria is not null)
{
    Console.WriteLine($"Música aleatória: {musicaAleatoria.Titulo} - {musicaAleatoria.Artista}");
}
else
{
    Console.WriteLine("A playlist está vazia.");
}

void ExibirPlaylist(Playlist playlist)
{
    Console.WriteLine($"Tocando a playlist: {playlist.Nome}");
    foreach (var musica in playlist)
    {
        Console.WriteLine($"\t{musica.Titulo}");
    }
}

class Musica
{
    public string Titulo { get; set; }
    public string Artista { get; set; }
    public TimeSpan Duracao { get; set; }
}

class Playlist : ICollection<Musica>
{
    private List<Musica> musicas = new List<Musica>();
    public string Nome { get; set; }

    public int Count => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public Musica? ObterPeloTitulo(string titulo)
    {
        foreach (var musica in musicas)
        {
            if (musica.Titulo == titulo)
            {
                return musica;
            }
        }
        return null;
    }

    public Musica? ObterAleatorio =>
        musicas.Count > 0 ? musicas[new Random().Next(musicas.Count)] : null;
    

    public IEnumerator<Musica> GetEnumerator()
    {
        return musicas.GetEnumerator();
    }

    public void Add(Musica item)
    {
        musicas.Add(item);
    }

    public void Clear()
    {
        musicas.Clear();
    }

    public bool Contains(Musica item)
    {
        return musicas.Contains(item);
    }

    public void CopyTo(Musica[] array, int arrayIndex)
    {
        musicas.CopyTo(array, arrayIndex);
    }

    public bool Remove(Musica item)
    {
        return musicas.Remove(item);
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}