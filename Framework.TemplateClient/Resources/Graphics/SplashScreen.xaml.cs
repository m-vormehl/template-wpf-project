﻿using SplashScreen;
using System.Windows.Controls;

namespace Framework.TemplateClient.Resources.Graphics
{
    /// <summary>
    /// more info on https://github.com/tom-englert/SplashScreen.Fody
    /// </summary>
    [SplashScreen(MinimumVisibilityDuration = 2, FadeoutDuration = 1)]
    public partial class SplashScreen : UserControl
    {
        public SplashScreen()
        {
            InitializeComponent();
        }
    }
}
