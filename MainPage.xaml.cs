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
using Windows.UI.Xaml.Media.Animation;
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
            dtReloj = new DispatcherTimer();

            Storyboard sb = (Storyboard)this.Resources["Correr"];
            sb.AutoReverse= true;
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Begin();
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

        private void cambioColor(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.elipseBrazoDerecho.Resources["sbBrazoDerechoKey"];
            sb.Begin();
        }

        private void morder(object sender, PointerRoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            Storyboard sb = new Storyboard();
            sb.Duration = new Duration(TimeSpan.FromMilliseconds(300));
            sb.Children.Add(da);
            sb.BeginTime = TimeSpan.FromSeconds(0);
            ptBoca.RenderTransform = (Transform)new ScaleTransform();
            Storyboard.SetTarget(da, ptBoca.RenderTransform);
            Storyboard.SetTargetProperty(da, "ScaleY");
            da.From = 1;
            da.To = 1.1;
            sb.AutoReverse = true;
            sb.RepeatBehavior = new RepeatBehavior(3);
            sb.Begin();
        }
    }
}
