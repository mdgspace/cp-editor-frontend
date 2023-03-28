using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;

namespace AvaloniaApplication1.ViewModels
{
    public class MusicStoreViewModel : ViewModelBase
    {
        private string? _searchText;
        private bool _isBusy;
        
        private AlbumViewModel? _selectedAlbum;
        public ReactiveCommand<Unit, AlbumViewModel?> BuyMusicCommand { get; }
        
        public ObservableCollection<AlbumViewModel> SearchResults { get; } = new();
        public MusicStoreViewModel()
        {
            BuyMusicCommand = ReactiveCommand.Create(() =>
            {
                return SelectedAlbum;
            });
            SearchResults.Add(new AlbumViewModel());
            SearchResults.Add(new AlbumViewModel());
            SearchResults.Add(new AlbumViewModel());
        }
        public AlbumViewModel? SelectedAlbum
        {
            get => _selectedAlbum;
            set => this.RaiseAndSetIfChanged(ref _selectedAlbum, value);
        }
        public string? SearchText
        {
            get => _searchText;
            set => this.RaiseAndSetIfChanged(ref _searchText, value);
        }
        public bool IsBusy
        {
            get => _isBusy;
            set => this.RaiseAndSetIfChanged(ref _isBusy, value);
        }
        
    }
    
}
