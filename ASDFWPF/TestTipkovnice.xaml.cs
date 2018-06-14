using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace ASDFWPF
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public partial class TestTipkovnice :Window
    {
        Tipkovnica m;
        PrivzetiViewModel vm = new PrivzetiViewModel();
        public TestTipkovnice()
        {
            this.InitializeComponent();
            PrivzetiViewModel.NaložiRezultate();
            int št = 163;
            m = new Tipkovnica(št);
            vsebnik.Children.Add(m);
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        
    }
}
