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
using Windows.UI.Xaml.Media;

namespace elementary.ViewModel
{
    /// <summary>
    /// Represents a block on the periodic table.
    /// </summary>
    public class ElementBlock : ElementBase
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
        /// The string to display under the element symbol. For stable elements, this is the atomic
        /// weight with up to 4 decimal places. For unstable elements, this is the atomic weight as
        /// a whole number surrounded by square braces.
        /// </summary>
        public string Subtext
        {
            get
            {
                if (Element.Unstable)
                {
                    return string.Format("[{0:d}]", (long)Element.Weight);
                }
                return Element.Weight.ToString("0.####");
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
        /// The row number of the periodic table to place the block.
        /// </summary>
        public int Row { get; private set; }

        /// <summary>
        /// The column number of the periodic table to place the block.
        /// </summary>
        public int Col { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="el">The Element to represent.</param>
        public ElementBlock(Element el) : base(el)
        {
            CalcPosition(el);
        }

        /// <summary>
        /// Determines and sets the row and column of the element block.
        /// </summary>
        /// <param name="el">The Element represented by this block.</param>
        private void CalcPosition(Element el)
        {
            if (el.Group == 0)
            {
                if (el.Period == 6)
                {
                    Row = 9;
                    Col = (int)el.Number - 54;
                }
                else if (el.Period == 7)
                {
                    Row = 10;
                    Col = (int)el.Number - 86;
                }
            }
            else
            {
                Row = (int)el.Period;
                Col = (int)el.Group;
            }
        }
    }
}
