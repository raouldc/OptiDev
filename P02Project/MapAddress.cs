using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
//using Microsoft.Maps.MapControl.WPF;

namespace P02Project {
    public class MapAddress
    {
        public string Title;
        public string Address;
        public string PostalAddress;
        public string Phone;
        public string ContactName;
        public string ContactTitle;
        public string ContactPhone;
        public string ContactEmail;
        //public Location Location;
    }

    public class MapAddressService {
        public static void GetMapAddresses(EventHandler<MapAddressEventArgs> callback) {
            //get data from xml, store in a list then do next line 
            //var data = new List<MapAddress>{
            //                                new MapAddress{
            //                                                  Address = "76 Grafton Road\nGrafton\nAuckland",
            //                                                  Title = "Auckland Family Place",
            //                                                  Location = new Location(-36.857769, 174.769119)
            //                                              }
            //                            };
            //callback(null, new MapAddressEventArgs(data));
        }
    }

    public class MapAddressEventArgs : EventArgs {
        public List<MapAddress> Locations { get; set; }

        public MapAddressEventArgs(List<MapAddress> locations) {
            Locations = locations;
        }
    }

    public class MapAddressViewModel : INotifyPropertyChanged {
        private ObservableCollection<MapAddress> _addresses;
        public ObservableCollection<MapAddress> Addresses {
            get { return _addresses; }
            set {
                _addresses = value;
                OnPropertyChanged("Addresses");
            }
        }
        public MapAddressViewModel() {
            MapAddressService.GetMapAddresses((o, ea) => {
                Addresses = new ObservableCollection<MapAddress>(ea.Locations);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
