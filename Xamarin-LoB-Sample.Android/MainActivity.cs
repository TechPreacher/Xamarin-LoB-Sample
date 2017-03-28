using Android.App;
using Android.Widget;
using Android.OS;
using Xamarin_LoB_Sample.ViewModel;

namespace Xamarin_LoB_Sample.Android
{
    [Activity(Label = "Xamarin LoB Sample Application", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button _buttonPrevious;
        private Button _buttonNext;
        private EditText _txtFirstName;
        private EditText _txtLastName;
        private EditText _txtEmail;
        private MainViewModel _viewModel;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _viewModel = new MainViewModel();

            _buttonNext = FindViewById<Button>(Resource.Id.buttonNext);
            _buttonPrevious = FindViewById<Button>(Resource.Id.buttonPrevious);
            _txtFirstName = FindViewById<EditText>(Resource.Id.txtFirstName);
            _txtLastName = FindViewById<EditText>(Resource.Id.txtLastName);
            _txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);

            _buttonNext.Click += _buttonNext_Click;
            _buttonPrevious.Click += _buttonPrevious_Click;

            UpdateUI();
        }

        private void UpdateUI()
        {
            _txtFirstName.Text = _viewModel.CurrentCustomer.FirstName;
            _txtLastName.Text = _viewModel.CurrentCustomer.LastName;
            _txtEmail.Text = _viewModel.CurrentCustomer.Email;

            _buttonNext.Enabled = _viewModel.NextCommand.CanExecute(null);
            _buttonPrevious.Enabled = _viewModel.PreviousCommand.CanExecute(null);
        }

        private void _buttonPrevious_Click(object sender, System.EventArgs e)
        {
            _viewModel.PreviousCommand.Execute(null);
            UpdateUI();
        }

        private void _buttonNext_Click(object sender, System.EventArgs e)
        {
            _viewModel.NextCommand.Execute(null);
            UpdateUI();
        }
    }
}

