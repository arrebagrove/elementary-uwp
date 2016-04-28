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
namespace Elementary.Model
{
    /// <summary>
    /// Represents an Element.
    /// </summary>
    public class Element
    {
        /// <summary>
        /// The element number.
        /// </summary>
        public long Number { get; internal set; }

        /// <summary>
        /// The element symbol.
        /// </summary>
        public string Symbol { get; internal set; }

        /// <summary>
        /// The element group.
        /// </summary>
        public long Group { get; internal set; }

        /// <summary>
        /// The element period.
        /// </summary>
        public long Period { get; internal set; }

        /// <summary>
        /// The element block.
        /// </summary>
        public string Block { get; internal set; }

        /// <summary>
        /// The atomic weight of the element.
        /// </summary>
        public double Weight { get; internal set; }

        /// <summary>
        /// The density of the element in g/cm³.
        /// </summary>
        public double? Density { get; internal set; }

        /// <summary>
        /// The melting point of the element in K.
        /// </summary>
        public double? Melt { get; internal set; }

        /// <summary>
        /// The boiling point of the element in K.
        /// </summary>
        public double? Boil { get; internal set; }

        /// <summary>
        /// The heat of the element in J/g·K.
        /// </summary>
        public double? Heat { get; internal set; }

        /// <summary>
        /// The electronegativity of the element in V.
        /// </summary>
        public double? Negativity { get; internal set; }

        /// <summary>
        /// The abundance of the element in mg/kg.
        /// </summary>
        public double? Abundance { get; internal set; }

        /// <summary>
        /// The element category.
        /// </summary>
        public long Category { get; internal set; }

        /// <summary>
        /// The electron configuration of the element.
        /// </summary>
        public string Configuration { get; internal set; }

        /// <summary>
        /// The electrons per shell of the element.
        /// </summary>
        public string Electrons { get; internal set; }

        /// <summary>
        /// Whether the element is unstable.
        /// </summary>
        public bool Unstable { get; internal set; }

        /// <summary>
        /// The YouTube ID for the video associated with the element.
        /// </summary>
        public string Video { get; internal set; }
    }
}