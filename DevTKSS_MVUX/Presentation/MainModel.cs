namespace DevTKSS_MVUX.Presentation;

public partial record MainModel
{
    private INavigator _navigator;

    public MainModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator)
    {
        _navigator = navigator;
        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";
    }

    public IListFeed<KeyValuePair<string, string>> TabItems => ListFeed
       .Async(
           static async (ct) =>
           {
               return ImmutableList<KeyValuePair<string, string>>.Empty.AddRange(new Dictionary<string, string>
               {
                    { "Tab1", "FeedView + GridView XAML" },
                    { "Tab2", "C# in Model" },
                    { "Tab3", "DI Service Resw" },
                    { "Tab4", "DI Service without Resw" },
                    { "Tab5", "C# Record" },
                    { "Tab6", "XAML DataTemplate" }
               });
           })
           .Selection(SelectedTabItem);

    public IState<KeyValuePair<string, string>> SelectedTabItem => State<KeyValuePair<string, string>>.Empty(this);

    public async Task Command(object sender)
    {
        await Name.UpdateAsync(_ => sender.ToString() ?? string.Empty);
    }
    public string? Title { get; }


    public IState<string> Name => State<string>.Value(this, () => string.Empty);

    public async Task GoToSecond()
    {
        var name = await Name;
        await _navigator.NavigateViewModelAsync<SecondModel>(this, data: new Entity(name!));
    }

}
