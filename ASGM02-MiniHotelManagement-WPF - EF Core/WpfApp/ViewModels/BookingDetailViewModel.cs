using BusinessObject;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace WpfApp.ViewModels
{
    public class BookingDetailViewModel : BaseViewModel, IDataErrorInfo
    {
        private readonly BookingDetail _bookingDetail;
        private ObservableCollection<RoomInformation> _rooms;
        private bool _isNew;
        private Window _window;

        public ObservableCollection<RoomInformation> Rooms
        {
            get => _rooms;
            set
            {
                _rooms = value;
                OnPropertyChanged(nameof(Rooms));
            }
        }

        public int RoomId 
        {
            get => _bookingDetail.RoomId;
            set
            {
                _bookingDetail.RoomId = value;
                OnPropertyChanged();
            } 
        }

        public DateOnly StartDate
        {
            get => _bookingDetail.StartDate;
            set
            {
                _bookingDetail.StartDate = value;
                OnPropertyChanged();
            }
        }

        public DateOnly EndDate
        {
            get => _bookingDetail.EndDate;
            set
            {
                _bookingDetail.EndDate = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(RoomId):
                        if (RoomId <= 0)
                            return "Vui lòng chọn phòng.";
                        break;

                    case nameof(StartDate):
                        if (StartDate < DateOnly.FromDateTime(DateTime.Today))
                            return "Ngày bắt đầu không được nhỏ hơn hôm nay.";
                        break;

                    case nameof(EndDate):
                        if (EndDate <= StartDate)
                            return "Ngày kết thúc phải sau ngày bắt đầu.";
                        break;
                }
                return null;
            }
        }

        public BookingDetailViewModel(BookingDetail bookingDetail, bool isNew, List<RoomInformation> rooms, Window window)
        {
            _bookingDetail = bookingDetail;
            _isNew = isNew;
            _window = window;
            Rooms = new ObservableCollection<RoomInformation>(rooms);

            SaveCommand = new RelayCommand(Save,CanSave);
            CancelCommand = new RelayCommand(Cancel);
        }

        public void Save(object parameter)
        {
            var props = TypeDescriptor.GetProperties(this);
            foreach (PropertyDescriptor prop in props)
            {
                if (!string.IsNullOrEmpty(this[prop.Name]))
                {
                    MessageBox.Show("Dữ liệu không hợp lệ. Vui lòng kiểm tra lại.");
                    return;
                }
            }
            _window.DialogResult = true;
            _window.Close();
        }

        public bool CanSave(object parameter)
        {
            return true;
        }

        public void Cancel(object parameter)
        {
            _window.DialogResult = false;
            _window.Close();
        }
    }
}
