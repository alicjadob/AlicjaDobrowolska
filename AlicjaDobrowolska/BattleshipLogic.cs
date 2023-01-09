using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AlicjaDobrowolska
{
    public class BattleshipLogic : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<int> _PersonIdOne = new ObservableCollection<int>
        { };
        ObservableCollection<int> _PersonIdTwo = new ObservableCollection<int>
        { };
        public ObservableCollection<int> PersonIdOne
        {
            get
            {
                return _PersonIdOne;
            }
            set
            {
                _PersonIdOne = value;
                OnPropertyChanged("PersonId");
            }
        }
        public ObservableCollection<int> PersonIdTwo
        {
            get
            {
                return _PersonIdTwo;
            }
            set
            {
                _PersonIdTwo = value;
                OnPropertyChanged("PersonId");
            }
        }
        public BattleshipLogic(int[] nPersonIdOne, int[] nPersonIdTwo)
        {
            foreach (int _person in nPersonIdOne)
            {
                _PersonIdOne.Add(_person);
            }

            foreach (int _person in nPersonIdTwo)
            {
                _PersonIdTwo.Add(_person);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool CheckWin(int shootsHit)
        {
            if (shootsHit == 20) return true;
            return false;
        }
    }
}
