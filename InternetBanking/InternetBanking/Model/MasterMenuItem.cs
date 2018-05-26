using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace InternetBanking.Model
{
    public class MasterMenuItem
    {
        private string title;
        private string iconSource;
        private Color backgroundColor;
        private Type targetType;

        public MasterMenuItem(string title, string iconSource, Color backgroundColor, Type targetType)
        {
            this.Title = title;
            this.IconSource = iconSource;
            this.BackgroundColor = backgroundColor;
            this.TargetType = targetType;
        }

        public Type TargetType { get => targetType; set => targetType = value; }
        public Color BackgroundColor { get => backgroundColor; set => backgroundColor = value; }
        public string IconSource { get => iconSource; set => iconSource = value; }
        public string Title { get => title; set => title = value; }
    }
}
