using System.Windows;
using TheMovies.ViewModel;

namespace TheMovies;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainViewModel mvm = new MainViewModel();
        DataContext = mvm;
    }

}


