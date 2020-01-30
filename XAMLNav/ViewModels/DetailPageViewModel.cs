using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace XAMLNav
{
    public class DetailPageViewModel : INotifyPropertyChanged
    {
        public DetailPageViewModel()
        {
            ExitCommand = new Command(async () => await Application.Current.MainPage.Navigation.PopAsync());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        string noteText;
        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteText)));
            }
        }
        System.DateTime noteDate;
        public System.DateTime NoteDate
        {
            get => noteDate;
            set
            {
                noteDate =value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteDate)));
            }
        }

        public ICommand ExitCommand { get; }
    }
}
