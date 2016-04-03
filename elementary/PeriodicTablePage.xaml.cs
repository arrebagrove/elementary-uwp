﻿/*
  The MIT License (MIT)
  Copyright © 2016 Steve Guidetti

  Permission is hereby granted, free of charge, to any person obtaining a copy
  of this software and associated documentation files (the “Software”), to deal
  in the Software without restriction, including without limitation the rights
  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
  copies of the Software, and to permit persons to whom the Software is
  furnished to do so, subject to the following conditions:

  The above copyright notice and this permission notice shall be included in
  all copies or substantial portions of the Software.

  THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
  THE SOFTWARE.
*/
using elementary.Control;
using elementary.Model;
using elementary.ViewModel;
using System;
using System.ComponentModel;
using Windows.ApplicationModel.Resources;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace elementary
{
    /// <summary>
    /// Page that displays the Periodic Table.
    /// </summary>
    public sealed partial class PeriodicTablePage : Page, INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        /// <summary>
        /// Gets or sets the FontSize of the row and column headers.
        /// </summary>
        private double HeaderSize { get; set; } = 1.0;

        /// <summary>
        /// Gets or sets the FontSize of the title.
        /// </summary>
        private double TitleSize { get; set; } = 1.0;

        /// <summary>
        /// Gets or sets the distance between the table and the Lantha/Actinides.
        /// </summary>
        private double SpacerWidth { get; set; } = 1.0;

        /// <summary>
        /// Gets or sets the Margin around the row and column headers.
        /// </summary>
        private Thickness HeaderMargin { get; set; }

        /// <summary>
        /// Gets or sets the Margin around the color legend.
        /// </summary>
        private Thickness LegendMargin { get; set; }

        /// <summary>
        /// The format string for the title of the element details dialog.
        /// </summary>
        private readonly string _detailsTitleFormat = ResourceLoader.GetForCurrentView().GetString("Title/ElementDetails");

        /// <summary>
        /// The current title of the element details dialog.
        /// </summary>
        private string _detailsTitle;

        /// <summary>
        /// Gets the title of the element details dialog or sets the name of the element to include
        /// in the title.
        /// </summary>
        private string DetailsTitle
        {
            get
            {
                return _detailsTitle;
            }
            set
            {
                _detailsTitle = string.Format(_detailsTitleFormat, value);
                PropertyChanged(this, new PropertyChangedEventArgs("DetailsTitle"));
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public PeriodicTablePage()
        {
            InitializeComponent();
            SizeChanged += OnSizeChanged;
            LoadBlocks();
        }

        /// <summary>
        /// Locks the screen in landscape mode when the Page is navigated to.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape | DisplayOrientations.LandscapeFlipped;
        }

        /// <summary>
        /// Unlocks the screen orientation when the Page is navigated away from.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.None;
        }

        /// <summary>
        /// Calculates and sets the properties when the size of the Page changes.
        /// </summary>
        /// <param name="sender">The Page.</param>
        /// <param name="e">The event arguments.</param>
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var blockSize = Math.Min(ActualWidth / 18, ActualHeight / 9);

            HeaderSize = blockSize / 4;
            TitleSize = blockSize / 2;
            SpacerWidth = blockSize / 4;
            HeaderMargin = new Thickness(0, 0, blockSize / 5, blockSize / 5);
            LegendMargin = new Thickness(blockSize / 3, blockSize * 0.75, blockSize / 3, blockSize / 4);

            PropertyChanged(this, new PropertyChangedEventArgs(null));
        }

        /// <summary>
        /// Loads the ElementBlocks into the Grid.
        /// </summary>
        private void LoadBlocks()
        {
            foreach (ElementBlock el in DBHelper.GetElementTable())
            {
                var block = new PeriodicTableBlock() { Element = el };
                block.Clicked += BlockClicked; ;
                Grid.SetRow(block, el.Row);
                Grid.SetColumn(block, el.Col);
                PeriodicTable.Children.Add(block);
            }
        }

        /// <summary>
        /// Opens the ContentDialog to display the details of an element when it is selected.
        /// </summary>
        /// <param name="sender">The clicked PeriodicTableBlock.</param>
        /// <param name="e">The event arguments.</param>
        private async void BlockClicked(object sender, RoutedEventArgs e)
        {
            var id = (sender as PeriodicTableBlock).Element.Element._ID;
            var element = DBHelper.GetElement(id);
            DetailsFrame.Navigate(typeof(ElementPage), element);
            DetailsTitle = element.Name;
            await DetailsDialog.ShowAsync();
        }
    }
}
