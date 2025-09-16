using ConversorDeMoedasMVVM.ViewModels;

namespace ConversorDeMoedasMVVM
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        
    }
}
