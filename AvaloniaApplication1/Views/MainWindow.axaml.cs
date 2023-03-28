using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.ViewModels;
using Avalonia.ReactiveUI;
using AvaloniaApplication1.Models;
using ReactiveUI;

namespace AvaloniaApplication1.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public ReactiveViewModel ReactiveViewModel { get; } = new ReactiveViewModel();
        public JsonProcessor JsonProcessor { get; } = new JsonProcessor();
        public MainWindow()
        {
            InitializeComponent();
            ExternalApiCall.InitializeClient();
            this.WhenActivated(d => d(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
            var dataSource = new ObservableCollection<string[]>
            {
                new []{ "A", "B", "C"},
                new []{ "C", "B", "A"},
            };

            foreach (var idx in dataSource[0].Select((value, index) => index))
            {
                Grid.Columns.Add(new DataGridTextColumn { Header = $"{idx + 1}. column", Binding = new Binding($"[{idx}]") });
                
            }

            Grid.AutoGenerateColumns = false;
            Grid.Items = dataSource;
        }



        private async Task<CodeforcesModel> LoadJs()
        {
            var product = await JsonProcessor.LoadJson();
            Console.WriteLine(product);
            return product; 
            

        }
        private async Task<TodoModel> LoadTodo()
        {
            var product = await TodoProcessor.LoadTodos();
            return product; 
            

        }
        
        private async Task DoShowDialogAsync(InteractionContext<MusicStoreViewModel, AlbumViewModel?> interaction)
        {
            var dialog = new MusicStoreWindow();
            dialog.DataContext = interaction.Input;

            var result = await dialog.ShowDialog<AlbumViewModel?>(this);
            interaction.SetOutput(result);
        }

        private async void  Button_OnClick(object? sender, RoutedEventArgs e)
        {
            var res = await LoadJs();
            Title.Text = res.title;
            Content.Text = res.content;
            Timelimit.Text = res.time_limit;


        }

        private async void GetTodos(object? sender, RoutedEventArgs e)
        {
            var res = await LoadTodo();
            // Title.Text = res.Todo;
           // Description.Text = $"The todo is {res.Completed}";
        }
    }
}