using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using DataGridApp.Models;
using DataGridApp.Adapters;
using System.Drawing;
using Android.Views;

namespace DataGridApp
{
    [Activity(Label = "DataGridApp", MainLauncher = true, Icon = "@mipmap/icon", WindowSoftInputMode = SoftInput.AdjustNothing )]
    public class MainActivity : Activity
    {
        private DraggableListView listViewCrypto;
        public List<Crypto> listCrypto;
        public CryptoAdapter cryptoAdapter;
        private SearchView searchView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            listViewCrypto = FindViewById<DraggableListView>(Resource.Id.listViewCrypto);
            searchView = FindViewById<SearchView>(Resource.Id.searchView);


            SetInit();
        }

        private void SetInit() {
            listCrypto = new List<Crypto>
            {
                new Crypto("Bitcoin", 159010055274, 9402.78f, 6595810000, 16910962, "change1"),
                new Crypto("Ethereum", 71893913561, 732.87f, 1835810000, 98099270, "change1"),
                new Crypto("Ripple", 32611370307, 0.834222f, 716917000, 39091956706, "change1"),
                new Crypto("Bitcoin Cash", 17821429077, 1047.72f, 418281000, 17009725, "change1"),
                new Crypto("Litecoin", 10390823403, 187.01f, 834576000, 55564118, "change1"),
                new Crypto("NEO", 6011330000, 92.48f, 170323000, 65000000, "change1"),
                new Crypto("Stellar", 5754487975, 0.311080f, 29763700, 18498418332, "change1"),
                new Crypto("Cardano", 5662524060, 0.218402f, 166294000, 25927070538, "change1"),
                new Crypto("Monero", 4526770906, 286.35f, 103598000, 15808690, "change1"),
                new Crypto("EOS", 4428154830, 6.16f, 327224000, 718589166, "change1"),
                new Crypto("Dash", 4113657634, 518.25f, 101188000, 7937532, "change1"),
                new Crypto("IOTA", 3998910218, 1.44f, 40928400, 2779530283, "change1")
            };
            cryptoAdapter = new CryptoAdapter(this, listCrypto);

            listViewCrypto.Adapter = cryptoAdapter;

            searchView.QueryTextChange += SearchView_QueryTextChange;  

        }

        void SearchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            if (e.NewText.Trim() == "")
            {
                cryptoAdapter.CryptoList = listCrypto;
                cryptoAdapter.NotifyDataSetChanged();
            }
            else
            {
                List<Crypto> filteredList = new List<Crypto>();
                foreach (Crypto oneCrypto in listCrypto)
                {
                    if (oneCrypto.Name.ToLower().Contains(e.NewText.ToLower()))
                        filteredList.Add(oneCrypto);
                }
                cryptoAdapter.CryptoList = filteredList;
                cryptoAdapter.NotifyDataSetChanged();
            }
        }
    }
}

