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
using elementary.ViewModel;
using System;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace elementary.Control
{
    /// <summary>
    /// Displays a clickable block in the periodic table.
    /// </summary>
    public sealed partial class PeriodicTableBlock : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a click event is detected on this block.
        /// </summary>
        public event RoutedEventHandler Clicked;

        /// <summary>
        /// Occurs when a property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        /// <summary>
        /// Gets or sets the ElementBlock represented by this block.
        /// </summary>
        public ElementBlock Element
        {
            get { return (ElementBlock)GetValue(ElementProperty); }
            set { SetValue(ElementProperty, value); }
        }
        public static readonly DependencyProperty ElementProperty =
            DependencyProperty.Register("Element", typeof(ElementBlock), typeof(PeriodicTableBlock), new PropertyMetadata(0));

        /// <summary>
        /// Gets or sets the Margin property of the atomic number.
        /// </summary>
        private Thickness NumberMargin { get; set; }

        /// <summary>
        /// Gets or sets the FontSize of the atomic number.
        /// </summary>
        private double NumberFontSize { get; set; } = 1.0;

        /// <summary>
        /// Gets or sets the Margin property of the element symbol.
        /// </summary>
        private Thickness SymbolMargin { get; set; }

        /// <summary>
        /// Gets or sets the FontSize of the element symbol.
        /// </summary>
        private double SymbolFontSize { get; set; } = 1.0;

        /// <summary>
        /// Gets or sets the Margin property of the block subtext.
        /// </summary>
        private Thickness SubtextMargin { get; set; }

        /// <summary>
        /// Gets or sets the FontSize of the block subtext.
        /// </summary>
        private double SubtextFontSize { get; set; } = 1.0;

        /// <summary>
        /// Constructor.
        /// </summary>
        public PeriodicTableBlock()
        {
            InitializeComponent();
            SizeChanged += OnSizeChanged;
            PointerPressed += OnDown;
        }

        /// <summary>
        /// Calculates and sets the properties of the Control when the size changes.
        /// </summary>
        /// <param name="sender">This PeriodicTableBlock.</param>
        /// <param name="e">The event arguments.</param>
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var blockSize = Math.Min(e.NewSize.Width, e.NewSize.Height);

            NumberFontSize = blockSize / 4;
            NumberMargin = new Thickness(blockSize / 20, 0, 0, 0);

            SymbolFontSize = blockSize / 2;
            SymbolMargin = new Thickness(0, 0, 0, blockSize / 12);

            SubtextFontSize = blockSize / 5;
            SubtextMargin = new Thickness(0, 0, 0, blockSize / 20);

            PropertyChanged(this, new PropertyChangedEventArgs(null));
        }

        /// <summary>
        /// Activates the selection indicator when the pointer is pressed.
        /// </summary>
        /// <param name="sender">This PeriodicTableBlock.</param>
        /// <param name="e">The event arguments.</param>
        private void OnDown(object sender, PointerRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "PressedState", true);
            PointerReleased += OnUp;
            PointerReleased += OnClicked;
            PointerExited += OnUp;
        }

        /// <summary>
        /// Deactivates the selection indicator when the pointer is released or moved out of the
        /// block.
        /// </summary>
        /// <param name="sender">This PeriodicTableBlock.</param>
        /// <param name="e">The event arguments.</param>
        private void OnUp(object sender, PointerRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "NormalState", true);
            PointerReleased -= OnUp;
            PointerReleased -= OnClicked;
            PointerExited -= OnUp;
        }

        /// <summary>
        /// Handler for the Clicked event.
        /// </summary>
        /// <param name="sender">The object where the event handler is attached.</param>
        /// <param name="e">The event data.</param>
        private void OnClicked(object sender, PointerRoutedEventArgs e)
        {
            Clicked(sender, new RoutedEventArgs());
        }
    }
}
