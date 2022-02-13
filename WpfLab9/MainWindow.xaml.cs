using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfLab9


{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private readonly int styleIndex;

        public MainWindow()
        {
            InitializeComponent();
            this.Top = Properties.Settings.Default.Position.Top;
            this.Left = Properties.Settings.Default.Position.Left;
            this.Height = Properties.Settings.Default.Position.Height;
            this.Width = Properties.Settings.Default.Position.Width;

            List<string> styles = new List<string>() { "Светлая тема", "Тёмная тема" };
            styleBox.ItemsSource = styles;
            styleBox.SelectedIndex = 0;
            styleBox.SelectionChanged += ThemeChange;
            


        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            int styleIndex = styleBox.SelectedIndex;
            Uri uri = new Uri("Light.xaml", UriKind.Relative);
            if (styleIndex == 1)
            {
                uri = new Uri("Dark.xaml", UriKind.Relative);
            }
            if (styleIndex == 0)
            {
                uri = new Uri("Light.xaml", UriKind.Relative);
            }
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
            if (textBox != null)
            {
                if (textBox.Background == Brushes.White)
                {
                    textBox.Foreground = Brushes.Black;
                }
                if (textBox.Background == Brushes.Black)
                {
                    textBox.Foreground = Brushes.White;
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.Position = this.RestoreBounds;
            Properties.Settings.Default.Save();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontFamily = ((sender as ComboBox).SelectedItem as String);
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontFamily);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string fontSize = ((sender as ComboBox).SelectedItem as String);
            if (textBox != null)
            {
                textBox.FontSize = Convert.ToDouble(fontSize);
            }
        }


        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.FontWeight = FontWeights.Bold;
            }
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.FontWeight = FontWeights.Normal;
            }
        }

        private void ToggleButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.FontStyle = FontStyles.Italic;
            }
        }

        private void ToggleButton_Unchecked_1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.FontStyle = FontStyles.Normal;
            }
        }

        private void ToggleButton_Checked_2(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.TextDecorations = TextDecorations.Underline;
            }
        }

        private void ToggleButton_Unchecked_2(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.TextDecorations = null;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                if (textBox.Background == Brushes.White)
                {
                    textBox.Foreground = Brushes.Black;
                }
                if (textBox.Background ==Brushes.Black)
                {
                    textBox.Foreground = Brushes.White;
                }
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Red;
            }
        }

        #region Вариант на обработчиках событий
        //private void MenuItem_ClickOpen(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Текстовые файлы(*.txt)|*.txt|Все файлы(*.*)|*.*";
        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        textBox.Text = File.ReadAllText(openFileDialog.FileName);
        //    }

        //}

        //private void MenuItem_ClickSave(object sender, RoutedEventArgs e)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Filter = "Текстовые файлы(*.txt)|*.txt|Все файлы(*.*)|*.*";
        //    if (saveFileDialog.ShowDialog() == true)
        //    {
        //        File.WriteAllText(saveFileDialog.FileName, textBox.Text);
        //    }
        //}

        //private void MenuItem_ClickClose(object sender, RoutedEventArgs e)
        //{
        //    Application.Current.Shutdown();
        //}
        #endregion

        #region Вариант с командами
        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }



        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы(*.txt)|*.txt|Все файлы(*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }

        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы(*.txt)|*.txt|Все файлы(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void SaveCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (textBox.Text.Length == 0)
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        #endregion

        private void HelpExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("В редакторе есть три размера, типа, стиля шрифта и 2 цвета. Можно править, сохранять, открывать существующие файлы. Но если нажмешь закрыть без сохранения, он спокойненько сделает это, и даже не спросит =)", "Справка", MessageBoxButton.OK, MessageBoxImage.Question);
        }

    }

}
