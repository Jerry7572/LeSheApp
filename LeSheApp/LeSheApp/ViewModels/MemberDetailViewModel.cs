using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace LeSheApp.ViewModels
{
    [QueryProperty(nameof(memberId), nameof(memberId))]
    class MemberDetailViewModel : BaseViewModel
    {
        private string memberId;
        private string email;
        private string address;
        public string Id { get; set; }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }

        public string MemberId
        {
            get
            {
                return memberId;
            }
            set
            {
                memberId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string memberId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(memberId);
                Id = item.Id;
                Email = item.Text;
                Address = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

    }
}
