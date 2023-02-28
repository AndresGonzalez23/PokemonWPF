using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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
        DispatcherTimer controlTiempos;

        public MainPage()
        {
            this.InitializeComponent();
            dtReloj = new DispatcherTimer();
            controlTiempos = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(2000);
            dtReloj.Tick += usePotionRed;
            controlTiempos.Interval = TimeSpan.FromMilliseconds(2000);
            controlTiempos.Tick += useEnergyPotion;

            Storyboard sb = (Storyboard)this.Resources["Correr"];
            Storyboard sb2 = (Storyboard)this.Resources["MoverOrejas"];
            sb.AutoReverse= true;
            sb2.AutoReverse= true;
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb2.RepeatBehavior = RepeatBehavior.Forever;
            sb.Begin();
            sb2.Begin();
        }
        
        private void usePotionRed(object sender, object e)
        {
            imgPocionUsada.Visibility=Visibility.Collapsed;
            imgPocion.Visibility = Visibility.Visible;
            dtReloj.Stop();
        }

        private void increaseHealth(object sender, PointerRoutedEventArgs e)
        {
            PVida.Value = PVida.Value + 20;
            dtReloj.Start();
            imgPocion.Visibility = Visibility.Collapsed;
            imgPocionUsada.Visibility = Visibility.Visible;
        }

        private void increaseEnergy(object sender, PointerRoutedEventArgs e)
        {
            PEnergia.Value = PEnergia.Value + 10;
            controlTiempos.Start();
            imgElixir.Visibility = Visibility.Collapsed;
            imgElixirUsada.Visibility = Visibility.Visible;
        }

        private void useEnergyPotion(object sender, object e)
        {
            imgElixirUsada.Visibility = Visibility.Collapsed;
            imgElixir.Visibility = Visibility.Visible;
            controlTiempos.Stop();

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
