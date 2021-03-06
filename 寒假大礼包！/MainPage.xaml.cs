﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace 寒假大礼包_
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if(rssURL.Text!="")
            {
                RssService.GetRssItems(
                    rssURL.Text,
                    async (items) =>
                    {
                        await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                            {
                                listbox.ItemsSource = items;
                            });
                    },
                    async (exception) =>
                    {
                        await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                         {
                             await new MessageDialog(exception).ShowAsync();
                         });
                    },
                    null
                    );
            }
            else
            {
                await new MessageDialog("请输入RSS地址").ShowAsync();
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listbox.SelectedItem == null)
                return;
            var template = (RssItem)listbox.SelectedItem;
            Frame.Navigate(typeof(DetailPage), template);
            listbox.SelectedItem = null;
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Share.IsSelected) { rssURL.Text = "http://www.zhihu.com/rss"; }
            else if (Favourite.IsSelected) { rssURL.Text = "http://news.163.com/special/00011K6L/rss_newstop.xml"; }
        }

        private void HanmbergerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitview.IsPaneOpen = !MySplitview.IsPaneOpen;
        }

        private void Address_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
