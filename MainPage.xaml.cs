using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace PokemonWPF
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DispatcherTimer dtReloj;
        public MainPage()
        {
            this.InitializeComponent();
        }
        
        private void usePotionRed(object sender, object e)
        {
            PVida.Value += 0.2;
            if(this.PVida.Value >= 100)
            {
                dtReloj.Stop();
                imgPocion.Opacity = 1;
            }
        }

        private void increaseHealth(object sender, PointerRoutedEventArgs e)
        {
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(100);
            dtReloj.Tick += usePotionRed;
            dtReloj.Start();
            imgPocion.Opacity = 0.1;
        }
    }
}
