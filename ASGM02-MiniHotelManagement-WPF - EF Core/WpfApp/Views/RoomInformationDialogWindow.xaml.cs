using BusinessObject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.ViewModels;

namespace WpfApp.Views
{
    public partial class RoomInformationDialogWindow : Window
    {
        public RoomInformationDialogWindow(RoomInformation room, bool isNew, List<RoomType> listRoomType)
        {
            InitializeComponent();
            DataContext = new RoomInformationViewModel(room, isNew, listRoomType, this);
        }
    }
}
