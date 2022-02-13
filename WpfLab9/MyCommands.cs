using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfLab9
{
    internal class MyCommands
    {
        public static RoutedCommand Exit { get; set; }
        static MyCommands()
        {
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.Q, ModifierKeys.Control, "Ctrl+Q"));
            Exit = new RoutedCommand("Выход", typeof(MyCommands), inputs);
        }

    }

}
