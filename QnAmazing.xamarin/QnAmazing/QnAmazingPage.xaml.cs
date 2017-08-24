using Xamarin.Forms;

namespace QnAmazing
{
    public partial class QnAmazingPage : ContentPage
    {
        public QnAmazingPage()
        {
            InitializeComponent();
            BindingContext = new QnAmazingPageViewModel(Navigation);
			var viewModel = (QnAmazingPageViewModel)BindingContext;
            viewModel.Answers.CollectionChanged+= (sender, e) =>{
                if (e.Action== System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    AnswerList.ScrollTo(viewModel.Answers[0], ScrollToPosition.Start, true);   
                }
            };
			
        }
    }
}
