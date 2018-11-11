using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using System.Xml.Serialization;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

/*
namespace DebtBookApp.ViewModel
{
    public class AddDebtHistory_ViewModel : ObservableCollection<DebtBook.Model.DebtBook>, INotifyPropertyChanged
    {

        string filename = "";

        public AddDebtHistory_ViewModel()
        {
            if ((bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                // In Design mode
                Add(DebtBook());
                Add(DebtBook());
            }
        }


        private void INotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Commands

        ICommand _addCommand;

        public ICommand AddCommand => _addCommand ?? (_addCommand = new RelayCommand<ListView>(
         list =>
         {
             ((list.ItemsSource) as ObservableCollection<DebtBook.Model.DebtBook>)?[list.SelectedIndex]?.Debts
                                                       .Add(new Debit());
         }));

        ICommand _SaveCommand;
        public ICommand SaveCommand
        {
            get { return _SaveCommand ?? (_SaveCommand = new RelayCommand(SaveFileCommand_Execute, SaveFileCommand_CanExecute)); }
        }

        private void SaveFileCommand_Execute()
        {
            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(global::DebtBook.Model.DebtBook));
            TextWriter writer = new StreamWriter(filename);
            // Serialize all the Debit.
            serializer.Serialize(writer, this);
            writer.Close();
        }

        private bool SaveFileCommand_CanExecute()
        {
            return (filename != "") && (Count > 0);
        }

        private ICommand _CancelCommand;

        // public ICommand CancelCommand
        // {
        //Do something
        // }

        #endregion

        #region Properties

        int currentIndex = -1;

        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                if (currentIndex != value)
                {
                    currentIndex = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public new event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }


    /* jeg tænkte noget i stil med:
     *  public class AddDebtHistory_ViewModel :INotifyPropertyChanged
    {
        // ALTERNATIV 1: 
         private Debtbook.Model.DebtBook DebtBook;
         private string name_ ;
         private long initialAmount_;

        public AddDebtHistory_ViewModel(DebtBook.Model.DebtBook debtBook)
        {
            DebtBook = debtBook;
        }
        
        //  Følgende skal laves med commands og er bare pseudokode fra min side

        // COMMAND NAME CHANGED --- opdater  name_;

        // COMMAND INTITIL AMOUNT CHANED -- opdater initialAmount_;

        // COMMAND SAVE ----
        {
                DebtBook.AddNewHistory(name_, initialAmount_);
        }

       // _________________________________________________________________________________________

         // ALTERNATIV 2: Hvis det er fåstået sådan at vi kun må have Model classes i viewModel

         private Debtbook.Model.DebtBook DebtBook;
         private Debtbook.Model.DebtHistory history => new Debtbook.Model.DebtHistory()

        public AddDebtHistory_ViewModel(DebtBook.Model.DebtBook debtBook)
        {
            DebtBook = debtBook;
        }
        
        //  Følgende skal laves med commands og er bare pseudokode fra min side

        // COMMAND NAME CHANGED --- opdater  history.Debtor;

        // COMMAND INTITIL AMOUNT CHANED -- idk kræver ændringer til DebtHistory, hvilket også er fint 
        
    // COMMAND SAVE ----
        {
                DebtBook.AddNewHistory(history); // kræver en AddNewHistory(Debtbook.Model.DebtHistory history) tilføjes til DebtBook..
        }
        
}

     */
