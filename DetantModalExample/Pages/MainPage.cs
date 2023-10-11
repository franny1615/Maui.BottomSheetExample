using DetantModalExample.PlatformViews;

namespace DetantModalExample.Pages;

public class MainPage : ContentPage
{
    public MainPage()
    {
        var button = new Button
        {
            Text = "Open Bottom Sheet"
        };
        button.Clicked += Button_Clicked;

        Content = new VerticalStackLayout 
        {
            Children =
            {
                button        
            }
        };
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        BottomSheet.ShowContent(new BottomSheetContent(), this);
    }
}

public class BottomSheetContent : ContentView
{
    public BottomSheetContent()
    {
        Content = new VerticalStackLayout
        {
            Children =
            {
                new Label
                {
                    Text = "Hello World from bottom sheet"
                }
            }
        };
    }
}