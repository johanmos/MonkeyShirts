using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace MonkeyShirts
{
    public partial class Principal : PhoneApplicationPage
    {
        const String url = "";
        PhotoChooserTask photoTask;
        CameraCaptureTask cameraTask;

        BitmapImage image;
        ImageBrush imgBrush;

        public Principal()
        {
            InitializeComponent();
            photoTask = new PhotoChooserTask();
            photoTask.Completed += new EventHandler<PhotoResult>(task_Completed);

            cameraTask = new CameraCaptureTask();
            cameraTask.Completed += new EventHandler<PhotoResult>(task_Completed);

            image = new BitmapImage();
            imgBrush = new ImageBrush();
        }

        void task_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK) { 
            
                image.SetSource(e.ChosenPhoto);
               imgBrush.ImageSource=image;
               rect.Fill = imgBrush;
}
        }

        private void escoger(object sender, RoutedEventArgs e)
        {
            var btnSender = sender as Button;
            switch (btnSender.Name)
            {

                case "camara":
                    tomarFoto();
                    break;
                case "buscar":
                    cargarImagen();
                    break;
                case "folder":
                    buscarImagen();
                    break;
                case "texto":
                    agregarTexto();
                    break;


            }
        }

        private void agregarTexto()
        {
            
        }

        private void cargarImagen()
        {
            
        }

        private void buscarImagen()
        {
            photoTask.Show();
        }

        private void tomarFoto()
        {
            cameraTask.Show();
        }
    }
}