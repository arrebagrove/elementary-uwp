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
using elementary.Model;
using elementary.Util;
using System.ComponentModel;
using Windows.UI.Xaml.Media;

namespace elementary.ViewModel
{
    /// <summary>
    /// Contains the data backing an item in the element list.
    /// </summary>
    public class ElementListItem : ElementBase, INotifyPropertyChanged
    {
        /// <summary>
        /// The element number as a string.
        /// </summary>
        public string Number
        {
            get
            {
                return Element.Number.ToString();
            }
        }

        /// <summary>
        /// The element symbol.
        /// </summary>
        public string Symbol
        {
            get
            {
                return Element.Symbol;
            }
        }

        /// <summary>
        /// The element name.
        /// </summary>
        public string Name
        {
            get
            {
                return ElementUtils.GetElementName(Element.Number);
            }
        }

        /// <summary>
        /// The background color of the block.
        /// </summary>
        public Brush Color
        {
            get
            {
                return ElementUtils.GetBlockColor(Element);
            }
        }

        /// <summary>
        /// Occurs when a mutable property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="el">The Element to represent.</param>
        public ElementListItem(Element el) : base(el)
        {
            Settings.SettingChanged += OnSettingChanged;
        }

        /// <summary>
        /// Sets the Color when the setting for element colors is changed.
        /// </summary>
        /// <param name="key">The key for the setting that has changed.</param>
        /// <param name="val">The new value for the setting.</param>
        private void OnSettingChanged(Settings.Key key, object val)
        {
            if (key == Settings.Key.ElementColors)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Color"));
            }
        }
    }
}