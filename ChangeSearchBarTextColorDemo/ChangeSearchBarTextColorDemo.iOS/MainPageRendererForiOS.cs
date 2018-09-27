using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChangeSearchBarTextColorDemo;
using ChangeSearchBarTextColorDemo.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MainPage), typeof(MainPageRendererForiOS))]
namespace ChangeSearchBarTextColorDemo.iOS
{
    public class MainPageRendererForiOS : PageRenderer
    {
        UISearchController searchController;

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            searchController = new UISearchController(searchResultsController: null)
            {
                HidesNavigationBarDuringPresentation = true,
                DimsBackgroundDuringPresentation = false,
                //ObscuresBackgroundDuringPresentation = true
            };
            searchController.SearchBar.SearchBarStyle = UISearchBarStyle.Default;
            NavigationController.TopViewController.NavigationItem.SearchController = searchController;

            //var element = (SearchPage)this.Element;

            //searchController.SearchBar.CancelButtonClicked += (s, e) =>
            //{
            //    element?.SearchCommand?.Execute(null);
            //};

            //searchController.SearchBar.TextChanged += (s, e) =>
            //{
            //    element?.SearchCommand?.Execute(e.SearchText);
            //};
        }
        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();

            using (var searchKey = new NSString("searchField"))
            {
                var textField = (UITextField)searchController.SearchBar.ValueForKey(searchKey);
                textField.TextColor = UIColor.Red;
                //You can also do other textField's configuration here
                UIView backgroundView = textField.Subviews.FirstOrDefault();
                if (backgroundView != null)
                {
                    backgroundView.BackgroundColor = UIColor.Blue;
                    backgroundView.Layer.CornerRadius = 10;
                    backgroundView.ClipsToBounds = true;
                }
            }
        }
    }
}