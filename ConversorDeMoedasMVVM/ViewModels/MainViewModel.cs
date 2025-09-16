using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversorDeMoedasMVVM.Models;
using System.Windows.Input;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace ConversorDeMoedasMVVM.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

       void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private readonly RateTable _rates= new();

        public IList<string> Currencies { get; }

        string? _amountText;

        public string? AmountText //validação de entrada
        {
            get => _amountText;
            set
            {
                if (value == _amountText) return;
                //se ele for identico , não faz nada, se ele trocou o valor colocado, faz a troca.
                _amountText = value;
                OnPropertyChanged();
                ((Command)ConvertCommand).ChangeCanExecute();
            }
            //sempre que o valor mudar, o botão de converter deve ser reavaliado
        }

        string _from = "USD";

        public string From
        {
            get => _from; // pegar
            set
            {
                if (value == _from) return;
                //se ele for identico , não faz nada, se ele trocou de moeda , faz a troca.
                _from = value;
                OnPropertyChanged();
                ((Command)ConvertCommand).ChangeCanExecute();
            }
            // sempre que o valor mudar, o botão de converter deve ser reavaliado
        }
        string _to = "BRL"; // variavel do destino ou seja o para, que é o BRL
        public string To
        {
            get => _to; // pegar
            set
            {
                if (value == _to) return;
                //se ele for identico , não faz nada, se ele trocou de moeda , faz a troca.
                _to= value;
                OnPropertyChanged();
                ((Command)ConvertCommand).ChangeCanExecute();
            }
            // sempre que o valor mudar, o botão de converter deve ser reavaliado
        }

        string _resultText = "--";
        public string ResultText
        {
            get => _resultText;
            set
            {
                if (_resultText != value)
                //s for diferente de valor, faz a troca
                {
                    //ele vai atribuir o resultado ao valor 
                    _resultText = value;
                    OnPropertyChanged();
                }
                
            }
        }
        public ICommand ConvertCommand { get; } // comando de converter
        public ICommand SwapCommand { get; } // comando de inverter
        
        public ICommand ClearCommand { get; } // comando de limpar

        readonly CultureInfo _ptBR = new("pt-BR"); // nos vai usar isso pq é nosso parametro inicial

        public MainViewModel() 
        {
            Currencies = _rates.GetCurrencies().ToList();
            ConvertCommand = new Command(DoConvert, CanConvert);
            SwapCommand = new Command(DoSwap);
            ClearCommand = new Command(DoClear);
        }

        bool CanConvert() // validação do comando converter
        {
            if (string.IsNullOrWhiteSpace(AmountText)) return false;
            //se o campo de texto estiver vazio, retorna falso maais tbm retorna nada se for espaço em branco
            return TryParseAmount(AmountText, out _);
            
        }

        void DoConvert() // ação do comando converter
        {
            if (!TryParseAmount(AmountText, out var amount))
            {
                ResultText = "Valor inválido";
                return;

                //se digitar valor errado , ele mostra valor inválido
                //TryParseAmount = validação de entrada
            }
            if (!_rates.Supports(From) || !_rates.Supports(To))
            {
                ResultText = "Moeda inválida";
                return;
                //se digitar moeda inválida, ele mostra moeda inválida
            }
            var result = _rates.Convert(amount, From, To);
            ResultText = string.Format(_ptBR, "{0:N2} {1} = {2:N2} {3}", amount, From, result, To);
        }
        
        void DoSwap() // ação do comando inverter
        {
            (From, To) = (To, From); // troca os valores de From e To entre si
            ResultText = "--";
        }
        void DoClear() // ação do comando limpar
        {
            AmountText = string.Empty;
            ResultText = "--";
        }

        bool TryParseAmount(string? text, out decimal amount) // validação de entrada
        {

            amount = 0m;
            if (string.IsNullOrWhiteSpace(text)) return false;
            // remove casas de espaços ante e dps do texto e verifica se o texto está vazio ou contém apenas espaços em branco.
            var s = text.Trim();
            if (!decimal.TryParse(s, NumberStyles.Number, _ptBR, out amount)) return true;

            s = s.Replace(",", "");
            return decimal.TryParse(s, NumberStyles.Number, _ptBR, out amount); // ele te devolve corretamente o valor convertido.

            //tenta converter o texto em um valor decimal usando as regras de formatação numérica do Brasil (pt-BR).

            //Se a conversão for bem-sucedida, o valor convertido será armazenado na variável amount e o método retornará true.

            //Se a conversão falhar (por exemplo, se o texto não for um número válido), o método retornará false e amount será definido como 0.

        }


    }
}
