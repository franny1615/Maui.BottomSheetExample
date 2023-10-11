using Microsoft.Maui.Platform;
using UIKit;
using ContentView = Microsoft.Maui.Controls.ContentView;

namespace DetantModalExample.PlatformViews;

public partial class BottomSheet
{
    public static partial void ShowContent(ContentView view, Page page)
    {
        var viewController = new UIViewController();
        viewController.View = view.ToPlatform(page.Handler.MauiContext);

        viewController.ModalPresentationStyle = UIModalPresentationStyle.PageSheet;
        if (viewController.SheetPresentationController != null)
        {
            viewController.SheetPresentationController.Detents = new UISheetPresentationControllerDetent[] 
            {
                UISheetPresentationControllerDetent.CreateMediumDetent(),
                UISheetPresentationControllerDetent.CreateLargeDetent()
            };
        }

        Platform.GetCurrentUIViewController().PresentViewController(viewController, true, null);
    }
}
