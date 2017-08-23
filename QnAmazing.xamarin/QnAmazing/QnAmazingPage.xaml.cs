using Xamarin.Forms;

namespace QnAmazing
{
    public partial class QnAmazingPage : ContentPage
    {
        public QnAmazingPage()
        {
            InitializeComponent();
            BindingContext = new QnAmazingPageViewModel();
        }
    }
}
