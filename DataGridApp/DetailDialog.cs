using System;
using System.Globalization;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using DataGridApp.Models;

namespace DataGridApp
{
    public class DetailDialog : Dialog
    {
        private MainActivity activity;
        private int index;
        private Button btnSave;
        private Button btnDelete;
        private ImageButton btnClose;
        private EditText edtName;
        private EditText edtMarketCap;
        private EditText edtPrice;
        private EditText edtVolume;
        private EditText edtSupply;

        public DetailDialog(MainActivity activity, int index) : base(activity)
        {
            this.activity = activity;
            this.index = index;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature((int)WindowFeatures.NoTitle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.dialog_detail);

            FindViews();
            SetInit();

        }

        private void FindViews() 
        {
            btnSave = FindViewById<Button>(Resource.Id.btnSave_DetailDialog);
            btnDelete = FindViewById<Button>(Resource.Id.btnDelete_DetailDialog);
            btnClose = FindViewById<ImageButton>(Resource.Id.btnClose_DetailDialog);
            edtName = FindViewById<EditText>(Resource.Id.edtName_DetailDialog);
            edtMarketCap = FindViewById<EditText>(Resource.Id.edtMarketCap_DetailDialog);
            edtPrice = FindViewById<EditText>(Resource.Id.edtPrice_DetailDialog);
            edtVolume = FindViewById<EditText>(Resource.Id.edtVolume_DetailDialog);
            edtSupply = FindViewById<EditText>(Resource.Id.edtSupply_DetailDialog);
        }

        private void SetInit() 
        {
            Crypto crypto = this.activity.listCrypto[index];
            edtName.Text = crypto.Name;
            edtMarketCap.Text = crypto.MarketCap.ToString();
            edtPrice.Text = crypto.Price.ToString();
            edtVolume.Text = crypto.Volume.ToString();
            edtSupply.Text = crypto.CirSupply.ToString();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClose.Click += (s, e) => Dismiss();
        }

        void BtnSave_Click(object sender, EventArgs e)
        {
            this.activity.listCrypto[index].Name = edtName.Text;
            this.activity.listCrypto[index].MarketCap = Int64.Parse(edtMarketCap.Text);
            this.activity.listCrypto[index].Price = float.Parse(edtPrice.Text, CultureInfo.InvariantCulture.NumberFormat);
            this.activity.listCrypto[index].Volume = Int64.Parse(edtVolume.Text);
            this.activity.listCrypto[index].CirSupply = Int64.Parse(edtSupply.Text);
            this.activity.cryptoAdapter.NotifyDataSetChanged();
            Dismiss();
        }

        void BtnDelete_Click(object sender, EventArgs e)
        {
            this.activity.listCrypto.RemoveAt(index);
            this.activity.cryptoAdapter.NotifyDataSetChanged();
            Dismiss();
        }

    }
}
