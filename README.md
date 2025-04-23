
MVUX example for populating TabBar:

  public IListState<string> TableItems => ListFeed
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
                    .Selection(SelectedTableItems);

![image](https://github.com/user-attachments/assets/62055c26-5ef9-42a5-9349-528573ddddaf)
