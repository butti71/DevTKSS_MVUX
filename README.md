
MVUX example for populate TabBar:
```
public IListState<KeyValuePair<string, string>> TabItems => ListFeed
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
```
![image](https://github.com/user-attachments/assets/23fe1dfa-858a-4c45-ae26-b1a4655a473d)

