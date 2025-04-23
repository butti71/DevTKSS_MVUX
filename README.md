
MVUX example for populate TabBar:
```
 public IListState<string> TabItems => ListFeed
             .Async(
                    static async (ct) =>
                    {
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
                    .Selection(SelectedTabItem);
    public IState<string> SelectedTabItem => State<string>.Empty(this);
```
![image](https://github.com/user-attachments/assets/62055c26-5ef9-42a5-9349-528573ddddaf)
