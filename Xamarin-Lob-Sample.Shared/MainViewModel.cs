using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Xamarin_LoB_Sample.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private int _current;

        public MainViewModel()
        {
            NextCommand = new DelegateCommand(OnNextExecute, OnNextCanExecute);
            PreviousCommand = new DelegateCommand(OnPreviousExecute, OnPreviousCanExecute);
            Customers = new List<Customer>
            {
                new Customer {FirstName = "Beat", LastName = "Klaus", Email = "beat.klaus@bluewin.ch" },
                new Customer {FirstName = "Corina", LastName = "Peters", Email = "corina.peters@hotmail.com" },
                new Customer {FirstName = "Cornel", LastName = "Casada", Email = "cornel.casada@sgi.com" },
                new Customer {FirstName = "Manuel", LastName = "Degas", Email = "manuel.degas@supsi.ch" },
                new Customer {FirstName = "Raul", LastName = "Chillon", Email = "raul.chillon@pure.com" },
                new Customer {FirstName = "Olaf", LastName = "Olofsen", Email = "olaf.olofsen@gmail.com" },
                new Customer {FirstName = "Rene", LastName = "Haupt", Email = "rene.haupt@cablecom.ch" },
                new Customer {FirstName = "Rita", LastName = "Fokas", Email = "rita.fokas@sanitas.ch" },
                new Customer {FirstName = "Peter", LastName = "Corti", Email = "peter.corti@swiss.com" },
                new Customer {FirstName = "Simon", LastName = "Sorcerer", Email = "simon.sorcerer@placebo.com" },
                new Customer {FirstName = "Stefan", LastName = "Thut", Email = "stefan.thut@comparis.com" },
                new Customer {FirstName = "Susan", LastName = "Tobler", Email = "susan.tobler@vontobel.ch" },
                new Customer {FirstName = "Thomas", LastName = "Pilawa", Email = "thomas.pilawa@bmw.com" },
                new Customer {FirstName = "Veronika", LastName = "Bern", Email = "veronika.bern@moff.com" }
            };
        }

        public List<Customer> Customers { get; private set; }
        public Customer CurrentCustomer
        {
            get
            {
                if (_current < 0 || _current > Customers.Count - 1)
                    return null;

                return Customers[_current];
            }
        }

        public ICommand NextCommand { get; private set; }
        public ICommand PreviousCommand { get; private set; }

        private void OnNextExecute()
        {
            ++_current;
            RaisePropertyChanged("CurrentCustomer");
            InvalidateCommands();
        }

        private void OnPreviousExecute()
        {
            --_current;
            RaisePropertyChanged("CurrentCustomer");
            InvalidateCommands();
        }

        private bool OnPreviousCanExecute()
        {
            return _current > 0;
        }

        private bool OnNextCanExecute()
        {
            return _current < Customers.Count - 1;
        }

        private void InvalidateCommands()
        {
            ((DelegateCommand)NextCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)PreviousCommand).RaiseCanExecuteChanged();
        }
    }
}
