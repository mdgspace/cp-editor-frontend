using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Windows.Input;
using ReactiveUI;

namespace AvaloniaApplication1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ReactiveViewModel ReactiveViewModel { get; } = new ReactiveViewModel();
        public JsonProcessor JsonProcessor { get; } = new JsonProcessor();
        public MainWindowViewModel()
        {
            
            ShowDialog = new Interaction<MusicStoreViewModel, AlbumViewModel?>();

            BuyMusicCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var store = new MusicStoreViewModel();

                var result = await ShowDialog.Handle(store);
            });
        }

        public ICommand BuyMusicCommand { get; }

        public Interaction<MusicStoreViewModel, AlbumViewModel?> ShowDialog { get; }
    }
}