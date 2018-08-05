using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ASDFWPF
{
    public class SelectableTextBox : TextBox
    {
        public SelectableTextBox() : base()
        {
            this.AddHandler(SelectableTextBox.KeyDownEvent, new RoutedEventHandler(HandleHandledKeyDown), true);
        }

        public void HandleHandledKeyDown(object sender, RoutedEventArgs e)
        {
            KeyEventArgs ke = e as KeyEventArgs;
            if (ke.Key == Key.Space)
            {
                ke.Handled = false;
            }
        }
    
}
}
