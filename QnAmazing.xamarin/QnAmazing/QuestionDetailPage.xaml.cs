using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace QnAmazing
{
    public partial class QuestionDetailPage : ContentPage
    {
        public QuestionDetailPage():this(null) {}

        public QuestionDetailPage(QnAMakerResult qna)
        {
            InitializeComponent();
            BindingContext = new QuestionDetailViewModel(qna);
        }

    }
}
