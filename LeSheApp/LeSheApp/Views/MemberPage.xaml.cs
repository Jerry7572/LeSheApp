using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeSheApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MemberPage : TabbedPage
    {
        public MemberPage()
        {
            InitializeComponent();
        }
    }
}