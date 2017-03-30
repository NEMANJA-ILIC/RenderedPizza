using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Weather3.Helpers
{
	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		// Used to set a property to a new value
		// set { SetProperty(ref _firstName, value); }
		protected virtual bool SetProperty<T>(ref T storage, T value, string propertyName = "")
		{
			if (EqualityComparer<T>.Default.Equals(storage, value))
				return false;
			storage = value;
			this.OnPropertyChanged(propertyName);
			return true;
		}
	}
}
