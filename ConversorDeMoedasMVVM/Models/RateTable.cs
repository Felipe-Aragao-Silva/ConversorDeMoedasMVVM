//Na model, estrá toda a tabela de cambio ficticia + regras de conversão

namespace ConversorDeMoedasMVVM.Models
{
    public class RateTable
    {
        private readonly Dictionary<string, decimal>
        _toBRL = new()
        {
            ["BRL"] = 1.00m, //Real Brasileiro
            ["USD"] = 5.00m, //Dólar Americano
            ["EUR"] = 5.50m,  //Euro
        };

        // Propriedade para leiura externado dicionario de taxas de cambio
        public IReadOnlyDictionary<string, decimal>
        ToBRL => _toBRL;

        public IEnumerable<string> GetCurrencies() => _toBRL.Keys.OrderBy(k => k);
        //public IEnumerable : permite retornar uma coleção de elementos, uma de cada vez, em vez de retornar todos os elementos de uma vez só.
        //strings : indica que a coleção contém elementos do tipo string (neste caso, códigos de moedas).
        //GetCurrencies() : é o nome do método que retorna a coleção de códigos de moedas ordenados alfabeticamente (por meio do OrderBy(k => k)).
        //_toBRL.Keys : obtém todas as chaves (códigos de moedas) do dicionário _toBRL.
        //OrderBy(k => k) : ordena as chaves em ordem alfabética.

        public bool Supports(string code) =>
            _toBRL.ContainsKey(code);
        //Verifica se as moedas de origem e destino são suportadas pelo dicionário _toBRL.

        // Método principal de conversão de moedas.
        public decimal Convert(decimal amount, string from, string to)
        {
            if (!Supports(from) || !Supports(to)) return 0m;
            // Retorna 0 se a moeda não for suportada.

            if (from == to) return amount;
            // Retorna o valor original se as moedas forem iguais.

            var BRL = amount * _toBRL[from];
            // Converte o valor para BRL usando a taxa de câmbio da moeda de origem para BRL.
            return BRL / _toBRL[to];
        }
    }
}
