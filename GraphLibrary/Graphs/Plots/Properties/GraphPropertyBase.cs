﻿using GraphLibrary.Generics.Constant;
using GraphLibrary.Labels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Graphs.Plots
{
    public class GraphPropertyBase : IGraphPropertyGetter, IGraphPropertySetter, IEquatable<IGraphPropertyGetter>
    {
        protected PlotProperty plotProperty;

        public GraphPropertyBase()
        {
            this.plotProperty = DefaultProperty.GetDefaultProperty();
        }

        public bool Equals(IGraphPropertyGetter other)
        {
            return this.plotProperty.PlotName == other.GetName();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as GraphPropertyBase);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Color GetColor()
        {
            return this.plotProperty.PlotColor;
        }

        public string GetName()
        {
            return this.plotProperty.PlotName;
        }

        public float GetSize()
        {
            return this.plotProperty.Size;
        }

        public void SetColor(Color color)
        {
            if (color == null) throw new ArgumentNullException();
            this.plotProperty.PlotColor = color;
        }

        public void SetName(string name)
        {
            if(String.IsNullOrEmpty(name)) throw new ArgumentNullException();
            this.plotProperty.PlotName = name;
        }

        public void SetSize(float _size)
        {
            if (_size < 1) throw new ValueSettingException();
            this.plotProperty.Size = _size;
        }
    }
}
