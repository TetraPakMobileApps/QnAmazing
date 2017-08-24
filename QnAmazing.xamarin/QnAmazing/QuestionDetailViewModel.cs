using System;
namespace QnAmazing
{
    public class QuestionDetailViewModel
    {
        public QnAMakerResult Qna { get; set; }

        public QuestionDetailViewModel(QnAMakerResult qna)
        {
            Qna = qna;
        }
        public double ProgressScore {
            get {
                return Qna.Score / 100;
            }
        }
    }
}
