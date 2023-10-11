using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using AndroidX.CoordinatorLayout.Widget;
using Google.Android.Material.BottomSheet;
using Microsoft.Maui.Platform;

namespace DetantModalExample.PlatformViews;

public partial class BottomSheet
{
    public static partial void ShowContent(ContentView view, Page page)
    {
        BottomSheetPlatformView sheet = new(view, page);
        sheet.Show(Platform.CurrentActivity.GetFragmentManager(), null);
    }
}


internal class BottomSheetPlatformView : BottomSheetDialogFragment
{
    private Page _onPage;
    private ContentView _contentToDisplay;
    
    public BottomSheetPlatformView(ContentView contentView, Page onPage)
    {
        _contentToDisplay = contentView;
        _onPage = onPage;
    }

    public override void SetupDialog(Dialog dialog, int style)
    {
        base.SetupDialog(dialog, style);

        if (_contentToDisplay != null && _onPage != null && _onPage.Handler != null)
        {
            var mauiContext = _onPage.Handler.MauiContext;
            if (mauiContext != null)
            {
                dialog.SetContentView(_contentToDisplay.ToPlatform(mauiContext));
            }
        }
    }
}