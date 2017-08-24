using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel;

namespace QnAmazing
{
    public class QuestionDetailViewModel : INotifyPropertyChanged
    {
        public QnAMakerResult Qna { get; set; }

        public ObservableCollection<QnAMakerResult> QnaMultipleAlternatives { get; set; }

        public QuestionDetailViewModel(QnAMakerResult qna)
        {
            Qna = qna;
            QnaMultipleAlternatives = new ObservableCollection<QnAMakerResult>();
            WebService.QueryMultipleAnswers(Qna.Question).ContinueWith(fetchMultipleAnswers);
            AlternativeAnswersHeader = "Loading...";
        }

        private void fetchMultipleAnswers(Task<QnAMakerMultipleResults> task) {
            foreach (var answer in task.Result.Answers.Skip(1)) {
                QnaMultipleAlternatives.Add(answer);
            }

            AlternativeAnswersHeader = $"Alternative answers ({QnaMultipleAlternatives.Count})";
        }

        public double ProgressScore {
            get {
                return Qna.Score / 100;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string alternativeAnswersHeader;
        public string AlternativeAnswersHeader
        {
            get
            {
                return alternativeAnswersHeader;
            }
            set
            {
                if (alternativeAnswersHeader == value)
                {
                    return;
                }

                alternativeAnswersHeader = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(AlternativeAnswersHeader)));
                }
            }
        }

	}
}
