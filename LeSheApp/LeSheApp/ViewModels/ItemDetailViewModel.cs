using LeSheApp.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LeSheApp.ViewModels
{
    [QueryProperty(nameof(GarbageTruckSpotId), nameof(GarbageTruckSpotId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string arrivalTime;
        private string address;
        public string Id { get; set; }

        public string ArrivalTime
        {
            get => arrivalTime;
            set => SetProperty(ref arrivalTime, value);
        }

        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }

        public string GarbageTruckSpotId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                ArrivalTime = item.Text;
                Address = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
