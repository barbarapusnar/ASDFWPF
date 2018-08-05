using System;
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


namespace ASDFWPF
{
    /// <summary>
    /// Interaction logic for Tipkovnica.xaml
    /// </summary>
    public partial class Tipkovnica : UserControl
    {
        TipkovnicaViewModel _vm;
        public Tipkovnica(int i)
        {
            InitializeComponent();
            _vm = new TipkovnicaViewModel(i);
            _vm.JeNarobe = false;
            _vm.Sklop = PrivzetiViewModel.GetSkupinaVaje(i);
            var a = Console.CapsLock;
            if (a)
                _vm.IsCapsLock = true;
            else
                _vm.IsCapsLock = false;
            _vm.Ena = "1";
            _vm.Ena = "1";
            _vm.Dva = "2";
            _vm.Tri = "3";
            _vm.Štiri = "4";
            _vm.Pet = "5";
            _vm.Šest = "6";
            _vm.Sedem = "7";
            _vm.Osem = "8";
            _vm.Devet = "9";
            _vm.Nič = "0";
            _vm.Apostrof = "'";
            _vm.Plus = "+";
            this.DataContext = _vm;
        }
        public void Preveri(object sender, KeyEventArgs e)
        {
            var a = Console.CapsLock;
            if (e.Key == Key.CapsLock)
            {
                if (a )
                    _vm.IsCapsLock = true;
                else
                    _vm.IsCapsLock = false;
            }
        }
        public void PreveriShift()
        {
            _vm.Ena = "!";
            _vm.Dva = "\"";
            _vm.Tri = "#";
            _vm.Štiri = "$";
            _vm.Pet = "%";
            _vm.Šest = "&";
            _vm.Sedem = "/";
            _vm.Osem = "(";
            _vm.Devet = ")";
            _vm.Nič = "=";
            _vm.Apostrof = "?";
            _vm.Plus = "*";
        }

        public void VrniShift()
        {
            _vm.Ena = "1";
            _vm.Dva = "2";
            _vm.Tri = "3";
            _vm.Štiri = "4";
            _vm.Pet = "5";
            _vm.Šest = "6";
            _vm.Sedem = "7";
            _vm.Osem = "8";
            _vm.Devet = "9";
            _vm.Nič = "0";
            _vm.Apostrof = "'";
            _vm.Plus = "+";
        }

        internal void PobarvajNapačno(Key Key)
        {
            switch (Key)
            {
                case Key.A:
                    btnVK_A.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.B:
                    btnVK_B.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.C:
                    btnVK_C.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.D:
                    btnVK_D.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.E:
                    btnVK_E.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.F:
                    btnVK_F.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.G:
                    btnVK_G.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.H:
                    btnVK_H.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.I:
                    btnVK_I.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.J:
                    btnVK_J.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.K:
                    btnVK_K.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.L:
                    btnVK_L.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.M:
                    btnVK_M.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.N:
                    btnVK_N.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.O:
                    btnVK_O.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.P:
                    btnVK_P.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.R:
                    btnVK_R.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.S:
                    btnVK_S.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.T:
                    btnVK_T.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.U:
                    btnVK_U.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.V:
                    btnVK_V.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.Z:
                    btnVK_Z.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.X:
                    btnVK_X.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.Y:
                    btnVK_Y.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.W:
                    btnVK_W.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.Q:
                    btnVK_Q.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case Key.Space:
                    btnVK_SPACE.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                //case Key.D0:
                //    btnVK_0.BorderBrush = new SolidColorBrush(Colors.Red);
                //    break;
                //case Key.Number1:
                //    btnVK_1.BorderBrush = new SolidColorBrush(Colors.Red);
                //    break;
                //case Key.Number2:
                //    btnVK_2.BorderBrush = new SolidColorBrush(Colors.Red);
                //    break;
                //case Key.Number3:
                //    btnVK_3.BorderBrush = new SolidColorBrush(Colors.Red);
                //    break;
                //case Key.Number4:
                //    btnVK_4.BorderBrush = new SolidColorBrush(Colors.Red);
                //    break;
                //case Key.Number5:
                //    btnVK_5.BorderBrush = new SolidColorBrush(Colors.Red);
                //    break;
                //case Key.Number6:
                //    btnVK_6.BorderBrush = new SolidColorBrush(Colors.Red);
                //    break;
                //case Key.Number7:
                //    btnVK_7.BorderBrush = new SolidColorBrush(Colors.Red);
                //    break;
                //case Key.Number8:
                //    btnVK_8.BorderBrush = new SolidColorBrush(Colors.Red);
                //    break;
                //case Key.Number9:
                //    btnVK_9.BorderBrush = new SolidColorBrush(Colors.Red);
                //    break;
                //case (Key)(187):
                //    btnVK_OemPlus.BorderBrush = new SolidColorBrush(Colors.Red);
                //    break;
                //case (Key)(191):
                //    btnVK_OemMinus.BorderBrush = new SolidColorBrush(Colors.Red);
                //    break;
                case (Key)(188):
                    btnVK_OemComma.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case (Key)(190):
                    btnVK_OemPeriod.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case (Key)(189):
                    btnVK_OemQuestion.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case (Key)(186): //č
                    btnVK_Oem1.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case (Key)(222): //ć
                    btnVK_Oem7.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case (Key)(220): //ž
                    btnVK_Oem8.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case (Key)(219): //š
                    btnVK_OemOpenBrackets.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
                case (Key)(221): //Đ
                    btnVK_Oem6.BorderBrush = new SolidColorBrush(Colors.Red);
                    break;
            }
        }

        internal void Ponastavi(List<Key> narobe)
        {
            foreach (var x in narobe)
            {
                switch (x)
                {
                    case Key.A:
                        btnVK_A.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.B:
                        btnVK_B.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.C:
                        btnVK_C.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.D:
                        btnVK_D.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.E:
                        btnVK_E.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.F:
                        btnVK_F.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.G:
                        btnVK_G.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.H:
                        btnVK_H.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.I:
                        btnVK_I.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.J:
                        btnVK_J.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.K:
                        btnVK_K.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.L:
                        btnVK_L.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.M:
                        btnVK_M.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.N:
                        btnVK_N.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.O:
                        btnVK_O.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.P:
                        btnVK_P.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.R:
                        btnVK_R.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.S:
                        btnVK_S.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.T:
                        btnVK_T.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.U:
                        btnVK_U.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.V:
                        btnVK_V.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.Z:
                        btnVK_Z.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.X:
                        btnVK_X.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.Y:
                        btnVK_Y.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.W:
                        btnVK_W.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.Q:
                        btnVK_Q.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case Key.Space:
                        btnVK_SPACE.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    //case Key.Number0:
                    //    btnVK_0.BorderBrush = new SolidColorBrush(Colors.White);
                    //    break;
                    //case Key.Number1:
                    //    btnVK_1.BorderBrush = new SolidColorBrush(Colors.White);
                    //    break;
                    //case Key.Number2:
                    //    btnVK_2.BorderBrush = new SolidColorBrush(Colors.White);
                    //    break;
                    //case Key.Number3:
                    //    btnVK_3.BorderBrush = new SolidColorBrush(Colors.White);
                    //    break;
                    //case Key.Number4:
                    //    btnVK_4.BorderBrush = new SolidColorBrush(Colors.White);
                    //    break;
                    //case Key.Number5:
                    //    btnVK_5.BorderBrush = new SolidColorBrush(Colors.White);
                    //    break;
                    //case Key.Number6:
                    //    btnVK_6.BorderBrush = new SolidColorBrush(Colors.White);
                    //    break;
                    //case Key.Number7:
                    //    btnVK_7.BorderBrush = new SolidColorBrush(Colors.White);
                    //    break;
                    //case Key.Number8:
                    //    btnVK_8.BorderBrush = new SolidColorBrush(Colors.White);
                    //    break;
                    //case Key.Number9:
                    //    btnVK_9.BorderBrush = new SolidColorBrush(Colors.White);
                    //    break;
                    //case (Key)(187):
                    //    btnVK_OemPlus.BorderBrush = new SolidColorBrush(Colors.White);
                    //    break;
                    //case (Key)(191):
                    //    btnVK_OemMinus.BorderBrush = new SolidColorBrush(Colors.White);
                    //    break;
                    case (Key)(188):
                        btnVK_OemComma.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case (Key)(190):
                        btnVK_OemPeriod.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case (Key)(189):
                        btnVK_OemQuestion.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case (Key)(186): //č
                        btnVK_Oem1.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case (Key)(222): //ć
                        btnVK_Oem7.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case (Key)(220): //ž
                        btnVK_Oem8.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case (Key)(219): //š
                        btnVK_OemOpenBrackets.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                    case (Key)(221): //Đ
                        btnVK_Oem6.BorderBrush = new SolidColorBrush(Colors.White);
                        break;
                }
            }
        }

    }
}
