using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace QnAmazing
{
    public class QnAmazingPageViewModel : INotifyPropertyChanged
    {
        public ICommand AskCommand { get; set; }

        private ISpeechService textToSpeech;

        private INavigation navigation;

        public QnAmazingPageViewModel(INavigation navigation)
        {
            IsEntryPossible = true;

            this.navigation = navigation;

            AskCommand = new Command(AskCommandHandler);
            Answers = new ObservableCollection<QnAMakerResult>();

            textToSpeech = DependencyService.Get<ISpeechService>();
        }

        private async void AskCommandHandler()
        {
            if (String.IsNullOrEmpty(Query)) {
                return;
            }
            IsEntryPossible = false;
            try 
            {
                var qnaResult = await WebService.Query(Query);
                Debug.WriteLine(qnaResult.ToString());
                ResponseJson = qnaResult.ToString();
                Answers.Insert(0, qnaResult);
                textToSpeech.Speak(qnaResult.Answer);
                Query = "";
            }
            finally {
                IsEntryPossible = true;
            }
        }

        private QnAMakerResult ourSelectedItem;
        public QnAMakerResult OurSelectedItem
        {
			get
			{
				return ourSelectedItem;
			}
			set
			{
				if (ourSelectedItem == value)
				{
					return;
				}

				ourSelectedItem = value;
				if (PropertyChanged != null)
				{
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(OurSelectedItem)));
				}

                if (ourSelectedItem != null) {
                    navigation.PushAsync(new QuestionDetailPage(ourSelectedItem));
                    ourSelectedItem = null;
                }
			}
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string query;
        public string Query
        {
            get
            {
                return query;
            }
            set
            {
                if (query == value)
                {
                    return;
                }

                query = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Query"));
                }
            }
        }

        private string responseJson;
        public string ResponseJson
        {
            get
            {
                return responseJson;
            }
            set
            {
                if (responseJson == value)
                {
                    return;
                }

                responseJson = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ResponseJson"));
                }
            }
        }

        private bool isEntryPossible;
        public bool IsEntryPossible
        {
            get
            {
                return isEntryPossible;
            }
            set
            {
                if (isEntryPossible == value)
                {
                    return;
                }

                isEntryPossible = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(IsEntryPossible)));
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(IsBusy)));
                }
            }
        }

        public bool IsBusy
        {
            get
            {
                return !isEntryPossible;
            }
        }


        private ObservableCollection<QnAMakerResult> answers;
        public ObservableCollection<QnAMakerResult> Answers
        {
            get
            {
                return answers;
            }
            set
            {
                if (answers == value)
                    return;

                answers = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Answers)));
                }
            }
        }
    }
}
