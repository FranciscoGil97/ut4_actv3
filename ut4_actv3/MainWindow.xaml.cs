using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ut4_actv3
{
    public partial class MainWindow : Window
    {
        enum cambioPagina { anterior = -1, sigiente = 1, actual = 0 }
        private int numeroActualSuperHeroe = 1;
        List<Superheroe> superheroes;
        Superheroe superheroe;
        public MainWindow()
        {
            InitializeComponent();

            superheroe = new Superheroe
            {
                Heroe = true
            };
            superheroes = Superheroe.GetSamples();
            ActualizaVista(cambioPagina.actual);
            nuevoSuperheroe.DataContext = superheroe;
        }

        private void SiguienteSuperheroe_Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (numeroActualSuperHeroe < superheroes.Count)
                ActualizaVista(cambioPagina.sigiente);
        }
        private void AnteriorSuperheroe_Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (1 < numeroActualSuperHeroe)
                ActualizaVista(cambioPagina.anterior);
        }

        private void ActualizaVista(cambioPagina tipo)
        {
            numeroActualSuperHeroe += (int)tipo;
            numeroSuperheroes.Text = numeroActualSuperHeroe + "/" + superheroes.Count;
            verHeroes.DataContext = superheroes[numeroActualSuperHeroe - 1];
        }

        private void AceptarButton_Click(object sender, RoutedEventArgs e)
        {
            superheroes.Add(superheroe);
            MessageBox.Show("Se ha insertado el nuevo superhéroe");
            ActualizaVista(0);
            superheroe = new Superheroe
            {
                Heroe = true
            };
            nuevoSuperheroe.DataContext = superheroe;
        }

        private void LimpiarButton_Click(object sender, RoutedEventArgs e)
        {
            LimpiaFormulario();
        }

        private void LimpiaFormulario()
        {
            nombreSuperheroeTextBox.Text = "";
            urlImagenTextBox.Text = "";
            heroeRadiobutton.IsChecked = true;
            villanoRadiobutton.IsChecked = false;
            vengadoreCheckBox.IsChecked = false;
            xmenCheckBox.IsChecked = false;

        }
    }
}
