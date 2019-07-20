using System;
using System.ComponentModel;
using System.Windows.Data;
using System.Linq;
using Caliburn.Micro;
using UI.WpfClient.Models;
using FakeItEasy;
using System.Collections.ObjectModel;

namespace UI.WpfClient.Modules.Search
{
    public class SearchViewModel : Screen, ISearch
    {
        #region Members
        public ICollectionView ViewSource { get; set; }
        public IObservableCollection<SearchCaseRecord> Items { get; set; }
        public IObservableCollection<object> QueryItems { get; set; }
        public object SelectedItem { get; set; }

        public bool StatusChecked { get; set; }

        public string SelectedRequestType { get; set; }
        public string SelectedRequestStatus { get; set; }
        public string SelectedCustomer { get; set; }
        public string SelectedJNumber { get; set; }
        public string SelectedRequestor { get; set; }
        public DateTime? SelectedDate { get; set; }
        public int DisplayedVolume { get; set; }

        public ListSortDirection  DefaultCreateDateSortDirection { get; set; } = ListSortDirection.Ascending;


        #endregion

        public SearchViewModel()
        {
            var fakeItems = A.CollectionOfDummy<SearchCaseRecord>(11);
            Items = new BindableCollection<SearchCaseRecord>(fakeItems);
        }

        private void ClearFilters()
        {
            StatusChecked = false;
            SelectedRequestor = "";
            SelectedJNumber = "";
            SelectedCustomer = "";
            SelectedRequestType = "";
            SelectedRequestStatus = "";

            ApplyFilters();
        }

        private void ApplyFilters()
        {
            //Items = QueryItems;
            //if (SelectedDate != null) Items = Items.Where(i => i.CreationDateTime == SelectedDate).ToList();
            //if (!string.IsNullOrEmpty(SelectedRequestor)) Items = Items.Where(i => i.Requestor.IndexOf(SelectedRequestor, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
            //if (!string.IsNullOrEmpty(SelectedJNumber)) Items = Items.Where(i => i.Jnumber.ToString().Contains(SelectedJNumber)).ToList();
            //if (!string.IsNullOrEmpty(SelectedCustomer)) Items = Items.Where(i => i.CustomerName.IndexOf(SelectedCustomer, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
            //if (!string.IsNullOrEmpty(SelectedRequestType) && RequestChecked) Items = Items.Where(i => i.RequestType.Contains(SelectedRequestType)).ToList();
            //if (!string.IsNullOrEmpty(SelectedRequestStatus) && StatusChecked) Items = Items.Where(i => i.RequestStatus.Contains(SelectedRequestStatus)).ToList();

            ViewSource = CollectionViewSource.GetDefaultView(Items);
            DisplayedVolume = ((ListCollectionView)ViewSource).Count;
        }
    }
}