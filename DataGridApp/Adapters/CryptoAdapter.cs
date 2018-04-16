using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using DataGridApp.Models;

namespace DataGridApp.Adapters
{
    public class CryptoAdapter : BaseAdapter<Crypto>, IDraggableListAdapter
    {
        private MainActivity activity;
        private List<Crypto> list;
        private LinearLayout layoutOneCrypto;
        private TextView txtRank;
        private TextView txtName;
        private TextView txtMarketCap;
        private TextView txtPrice;
        private TextView txtVolume;
        private TextView txtCirSupply;
        private Spinner spnChange;

        public int mMobileCellPosition { get; set; }

        public CryptoAdapter(MainActivity activity, List<Crypto> list)
        {
            this.activity = activity;
            this.list = list;
        }

        public List<Crypto> CryptoList
        {
            set => list = value; 
        }

        public override Crypto this[int position] => list[position];

        public override int Count => list.Count;

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            
            View rowview = LayoutInflater.From(activity).Inflate(Resource.Layout.list_item_of_crypto, null, false);

            layoutOneCrypto = rowview.FindViewById<LinearLayout>(Resource.Id.layoutOneCrypto);
            txtRank = rowview.FindViewById<TextView>(Resource.Id.txtRank_OneCrypto);
            txtName = rowview.FindViewById<TextView>(Resource.Id.txtName_OneCrypto);
            txtMarketCap = rowview.FindViewById<TextView>(Resource.Id.txtMarketCap_OneCrypto);
            txtPrice = rowview.FindViewById<TextView>(Resource.Id.txtPrice_OneCrypto);
            txtVolume = rowview.FindViewById<TextView>(Resource.Id.txtVolume_OneCrypto);
            txtCirSupply = rowview.FindViewById<TextView>(Resource.Id.txtCirSupply_OneCrypto);
            spnChange = rowview.FindViewById<Spinner>(Resource.Id.spnChange_OneCrypto);

            txtRank.Text = (position + 1).ToString();
            txtName.Text = list[position].Name;
            txtMarketCap.Text = "$" + KiloFormat(list[position].MarketCap);
            txtPrice.Text = list[position].Price.ToString("c2");
            txtVolume.Text = "$" + KiloFormat(list[position].Volume);
            txtCirSupply.Text = KiloFormat(list[position].CirSupply);

            layoutOneCrypto.Tag = position;
            layoutOneCrypto.Click += LayoutOneCrypto_Click;

            List<string> spinnerList = new List<string>();
            spinnerList.Add("Change1");
            spinnerList.Add("Change2");
            spnChange.Adapter = new ArrayAdapter<String>(activity, Resource.Layout.spinner_item, spinnerList);

            return rowview;
        }

        public string KiloFormat(long num)
        { 

            if (num >= 100000000000000)
                return (num / 1000000000000).ToString("#,0 T");

            if (num >= 10000000000000)
                return (num / 1000000000000).ToString("0.#") + " T";

            if (num >= 100000000000)
                return (num / 1000000000).ToString("#,0 G");

            if (num >= 10000000000)
                return (num / 1000000000).ToString("0.#") + " G";

            if (num >= 100000000)
                return (num / 1000000).ToString("#,0 M");

            if (num >= 10000000)
                return (num / 1000000).ToString("0.#") + " M";

            if (num >= 100000)
                return (num / 1000).ToString("#,0 K");

            if (num >= 10000)
                return (num / 1000).ToString("0.#") + " K";

            return num.ToString("#,0");
        }

        void LayoutOneCrypto_Click(object sender, EventArgs e)
        {
            LinearLayout layout = (LinearLayout)sender;
            int position = (int) layout.Tag;
            DetailDialog detailDialog = new DetailDialog(activity, position);
            detailDialog.Show();
        }

        public void SwapItems(int indexOne, int indexTwo)
        {
            if (IsValidateIndex(indexOne) && IsValidateIndex(indexTwo))
            {
                var oldValue = list[indexOne];
                list[indexOne] = list[indexTwo];
                list[indexTwo] = oldValue;
                mMobileCellPosition = indexTwo;
                NotifyDataSetChanged();
            }
        }

        private bool IsValidateIndex(int index)
        {
            return (index >= 0) && (index < list.Count);
        }


    }
}
