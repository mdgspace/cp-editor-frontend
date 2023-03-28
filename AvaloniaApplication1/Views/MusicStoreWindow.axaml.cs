using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.ViewModels;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;

namespace AvaloniaApplication1.Views
{
    public partial class MusicStoreWindow : ReactiveWindow<MusicStoreViewModel>
    {
        public MusicStoreWindow()
        {
            InitializeComponent();
            this.WhenActivated(d => d(ViewModel!.BuyMusicCommand.Subscribe(Close)));
        }
    }
}