using System.Windows;
using Jarloo.CardStock.ViewModels;

namespace Jarloo.CardStock.Views
{
    public partial class CardDeckView : Window
    {
        public CardDeckView()
        {
            InitializeComponent();

            DataContext = new CardDeckViewModel();
        }
    }
}