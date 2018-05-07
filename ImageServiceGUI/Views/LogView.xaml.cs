﻿using ImageServiceGUI.ViewModels;

namespace ImageServiceGUI.Views
{
    /// <summary>
    ///     Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class LogView
    {
        public LogView()
        {
            InitializeComponent();
            DataContext = new LogViewModel();
        }

        //public string TabText
        //{
        //    get => (string) GetValue(TabTextProperty);
        //    set => SetValue(TabTextProperty, value);
        //}

        //public static readonly DependencyProperty TabTextProperty = DependencyProperty.Register("TabText",
        //    typeof(string), typeof(SettingsView), new PropertyMetadata("Default"));
    }
}