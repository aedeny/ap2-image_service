﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageServiceGUI.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class LogView : UserControl
    {
        public LogView()
        {
            InitializeComponent();
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