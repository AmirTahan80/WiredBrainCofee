﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WiredBrainCofee.CustumrsApp.ViewModels
{
    public class BasicViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
