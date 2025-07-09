using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace realworld_avalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    // public string Greeting { get; } = "Welcome to Avalonia!";

    [ObservableProperty]
    private bool _isExpanded = true;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HomeViewIsActive))]
    [NotifyPropertyChangedFor(nameof(ProcessViewIsActive))]
    [NotifyPropertyChangedFor(nameof(ActionsViewIsActive))]
    [NotifyPropertyChangedFor(nameof(MacrosViewIsActive))]
    [NotifyPropertyChangedFor(nameof(ReporterViewIsActive))]
    [NotifyPropertyChangedFor(nameof(HistoryViewIsActive))]
    private ViewModelBase _currentView;

    public bool HomeViewIsActive => CurrentView == _home;
    public bool ProcessViewIsActive => CurrentView == _process;
    public bool ActionsViewIsActive => CurrentView == _actions;
    public bool MacrosViewIsActive => CurrentView == _macros;
    public bool ReporterViewIsActive => CurrentView == _reporter;
    public bool HistoryViewIsActive => CurrentView == _history;

    private readonly HomeViewModel _home = new HomeViewModel();
    private readonly ProcessViewModel _process = new ProcessViewModel();
    private readonly ActionsViewModel _actions = new ActionsViewModel();
    private readonly MacrosViewModel _macros = new MacrosViewModel();
    private readonly ReporterViewModel _reporter = new ReporterViewModel();
    private readonly HistoryViewModel _history = new HistoryViewModel();

    public MainWindowViewModel()
    {
        CurrentView = _home;
    }

    [RelayCommand]
    private void SideMenuResize() => IsExpanded = !IsExpanded;

    [RelayCommand]
    private void GoToHome() => CurrentView = _home;

    [RelayCommand]
    private void GoToProcess() => CurrentView = _process;
    [RelayCommand]
    private void GoToActions() => CurrentView = _actions;
    [RelayCommand]
    private void GoToMacros() => CurrentView = _macros;
    [RelayCommand]
    private void GoToReporter() => CurrentView = _reporter;
    [RelayCommand]
    private void GoToHistory() => CurrentView = _history;

}
