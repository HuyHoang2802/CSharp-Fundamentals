using BusinessObject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp.ViewModels
{

    public class RoomInformationViewModel : BaseViewModel, IDataErrorInfo
    {
        private RoomInformation _roomInformation;
        private readonly bool _isNew;
        private readonly Window _window;
        private ObservableCollection<RoomType> _types;

        public ObservableCollection<RoomType> RoomTypes 
        {
            get => _types ;
            set
            {
                _types = value;
                OnPropertyChanged(nameof(RoomTypes));
            }
        }
        public string Number
        {
            get => _roomInformation.RoomNumber;
            set
            {
                _roomInformation.RoomNumber = value;
                OnPropertyChanged();
            }
        }

        public string? Detail
        {
            get => _roomInformation.RoomDetailDescription;
            set
            {
                _roomInformation.RoomDetailDescription = value;
                OnPropertyChanged();
            }
        }
        public int? MaxCapacity
        {
            get => _roomInformation.RoomMaxCapacity;
            set
            {
                _roomInformation.RoomMaxCapacity = value;
                OnPropertyChanged();
            }
        }

        public int TypeId
        {
            get => _roomInformation.RoomTypeId;
            set
            {
                _roomInformation.RoomTypeId = value;
                OnPropertyChanged();
            }
        }
        public decimal? PricePerDay
        {
            get => _roomInformation.RoomPricePerDay;
            set
            {
                _roomInformation.RoomPricePerDay = value;
                OnPropertyChanged();
            }
        }
        public byte? Status
        {
            get => _roomInformation.RoomStatus;
            set
            {
                _roomInformation.RoomStatus = value;
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
                    case nameof(Number):
                        if (string.IsNullOrWhiteSpace(Number))
                            return "Số phòng không được để trống.";
                        break;
                    case nameof(MaxCapacity):
                        if (!MaxCapacity.HasValue || MaxCapacity <= 0)
                            return "Sức chứa phải lớn hơn 0.";
                        break;
                    case nameof(TypeId):
                        if (TypeId <= 0)
                            return "Vui lòng chọn loại phòng.";
                        break;
                    case nameof(PricePerDay):
                        if (!PricePerDay.HasValue || PricePerDay < 0)
                            return "Giá phải lớn hơn hoặc bằng 0.";
                        break;
                }
                return null;
            }
        }

        public RoomInformationViewModel(RoomInformation room, bool isNew, List<RoomType> listRoomTypes, Window window)
        {
            _roomInformation = room;
            _isNew = isNew;
            _window = window;
            RoomTypes = new ObservableCollection<RoomType>(listRoomTypes);

            SaveCommand = new RelayCommand(Save, CanSave);
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
