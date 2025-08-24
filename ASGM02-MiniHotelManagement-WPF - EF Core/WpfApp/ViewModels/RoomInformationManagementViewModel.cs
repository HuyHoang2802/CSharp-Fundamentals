using BusinessObject;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp.ViewModels
{
    public class RoomInformationManagementViewModel : BaseViewModel
    {
        private readonly IRoomInformationService _roomInformationService;
        private readonly IRoomTypeService _roomTypeService;
        private ObservableCollection<RoomInformation> _roomInformations;
        private string _displayError = string.Empty;
        private string _keyword = string.Empty;

        public string Keyword
        {
            get => _keyword;
            set
            {
                _keyword = value;
                OnPropertyChanged(nameof(Keyword));
                ExecuteSearchRoom();
            }
        }

        public string DisplayError
        {
            get => _displayError;
            set
            {
                _displayError = value;
                OnPropertyChanged(nameof(DisplayError));
            }
        }
        public ObservableCollection<RoomInformation> RoomInformations
        {
            get => _roomInformations;
            set
            {
                _roomInformations = value;
                OnPropertyChanged(nameof(RoomInformations));
            }
        }

        public ICommand LoadRoom { get; }
        public ICommand AddRoom { get; }
        public ICommand UpdateRoom { get; }
        public ICommand DeleteRoom { get; }

        public RoomInformationManagementViewModel(IRoomInformationService roomInformationService, IRoomTypeService roomTypeService)
        {
            _roomInformationService = roomInformationService;
            _roomTypeService = roomTypeService;
            RoomInformations = new ObservableCollection<RoomInformation>();
            DisplayError = string.Empty;
            LoadRoom = new RelayCommand(ExecuteLoadRoom);
            AddRoom = new RelayCommand(ExecuteAddRoom);
            UpdateRoom = new RelayCommand(ExecuteUpdateRoom);
            DeleteRoom = new RelayCommand(ExecuteDeleteRoom);
            LoadRoom.Execute(null); // Load rooms when the view model is initialized
        }

        private void ExecuteDeleteRoom(object obj)
        {
            if (obj is RoomInformation roomInformation && MessageBox.Show($"Bạn có chắc muốn xóa phòng {roomInformation.RoomNumber}?", "Xác nhận xóa", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (_roomInformationService.DeleteRoomInformation(roomInformation.RoomId))
                {
                    LoadRoom.Execute(null); // Reload customers after deletion
                }
                else
                {
                    DisplayError = "Failed to delete customer.";
                }
            }
        }

        private void ExecuteUpdateRoom(object obj)
        {
            if (obj is not RoomInformation roomInfo)
            {
                DisplayError = "Invalid room information provided for update.";
                return;
            }
            var listRoomTypes = _roomTypeService.GetRoomTypes();
            var dialog = new Views.RoomInformationDialogWindow(roomInfo, false, listRoomTypes);
            if (dialog.ShowDialog() == false)
            {
                return;
            }

            _roomInformationService.UpdateRoomInformation(roomInfo);
            LoadRoom.Execute(null); // Reload rooms after adding a new room
        }

        private void ExecuteAddRoom(object room)
        {
            var roomInfo = new RoomInformation();
            var listRoomTypes = _roomTypeService.GetRoomTypes();
            var dialog = new Views.RoomInformationDialogWindow(roomInfo, false, listRoomTypes);
            if (dialog.ShowDialog() == false)
            {
                return;
            }

            _roomInformationService.AddRoomInformation(roomInfo);
            LoadRoom.Execute(null); // Reload rooms after adding a new room
        }

        private void ExecuteLoadRoom(object obj)
        {
            RoomInformations.Clear();
            var rooms = _roomInformationService.LoadRoomInformation();
            if (rooms != null)
            {
                foreach (var room in rooms)
                {
                    RoomInformations.Add(room);
                }
            }
            else
            {
                // Handle the case where no rooms are found or an error occurs
                DisplayError = "No rooms found or an error occurred while loading rooms.";
            }
        }

        private void ExecuteSearchRoom()
        {
            RoomInformations.Clear();
            var rooms = _roomInformationService.SearchRoomInformation(Keyword);
            if (rooms != null)
            {
                foreach (var room in rooms)
                {
                    RoomInformations.Add(room);
                }
            }
            else
            {
                // Handle the case where no rooms are found or an error occurs
                DisplayError = "No rooms found or an error occurred while loading rooms.";
            }
        }
    }
}
