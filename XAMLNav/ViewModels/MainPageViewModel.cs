﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace XAMLNav
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            Notes = new ObservableCollection<NoteModel>();

            SaveNoteCommand = new Command(() =>
            {
                Notes.Add(new NoteModel { Text = NoteText, DateTime=NoteDate });
                NoteText = string.Empty;
            },
            () => !string.IsNullOrEmpty(NoteText));

            EraseNotesCommand = new Command(() => Notes.Clear());

            NoteSelectedCommand = new Command(async () =>
            {
                if (SelectedNote is null)
                    return;

                var detailViewModel = new DetailPageViewModel
                {
                    NoteText = SelectedNote.Text,
                    NoteDate = SelectedNote.DateTime
                };

                await Application.Current.MainPage.Navigation.PushAsync(new DetailPage(detailViewModel));

                SelectedNote = null;
            });
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

                SaveNoteCommand.ChangeCanExecute();
            }
        }

        System.DateTime noteDate;
        public System.DateTime NoteDate
        {
            get => System.DateTime.Now;
            set
            {
                noteDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteDate)));

                SaveNoteCommand.ChangeCanExecute();
            }
        }

        NoteModel selectedNote;
        public NoteModel SelectedNote
        {
            get => selectedNote;
            set
            {
                selectedNote = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedNote)));

            }
        }

        public ObservableCollection<NoteModel> Notes { get; }

        public Command NoteSelectedCommand { get; }
        public Command SaveNoteCommand { get; }
        public Command EraseNotesCommand { get; }
    }
}
