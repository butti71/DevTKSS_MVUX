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

    public IListState<string> TableItems => ListFeed
             .Async(
                    static async (ct) =>
                    {
                        //var result = await new;
                        //_logger.LogInformation($"After lookup API call, result is {result.Data.Select(o => o.Name)}");

                        return ImmutableList<string>.Empty.AddRange(new[]
                        {
                            "FeedView + GridView XAML",
                                    "C# in Model",
                                    "DI Service Resw",
                                    "DI Service without Resw",
                                    "C# Record",
                                    "XAML DataTemplate"
                        });
                    })
                    .Selection(SelectedTableItems);

    //public IState<DBTable> SelectedTableItem => State.Value(this, () => new DBTable());
    //public IState<DBTable> NewTableItem => State.Value(this, () => new DBTable());
    public IState<IImmutableList<string>> SelectedTableItems => State<IImmutableList<string>>.Empty(this);



    public string? Title { get; }

    public IState<string> Name => State<string>.Value(this, () => string.Empty);

    public async Task GoToSecond()
    {
        var name = await Name;
        await _navigator.NavigateViewModelAsync<SecondModel>(this, data: new Entity(name!));
    }

}
