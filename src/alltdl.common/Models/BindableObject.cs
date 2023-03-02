/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace alltdl.Models;

/// <summary>Implementation of <see cref="INotifyPropertyChanged"/> to simplify model binding.</summary>
public abstract class BindableObject : INotifyPropertyChanged
{
    /// <summary>Occurs when a property value changes.</summary>
    [field: NonSerialized]
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>Raises this object's PropertyChanged event.</summary>
    /// <param name="propertyName">
    /// Name of the property used to notify listeners. This value is optional and can be provided automatically when invoked from compilers that support <see cref="CallerMemberNameAttribute"/>.
    /// </param>
    protected void RaisePropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /// <summary>Raises this object's PropertyChanged event for each of the properties.</summary>
    /// <param name="propertyNames">The properties that have a new value.</param>
    protected void RaisePropertyChanged(params string[] propertyNames)
    {
        if (propertyNames == null) return;

        foreach (var name in propertyNames)
        {
            this.RaisePropertyChanged(name);
        }
    }

    /// <summary>Checks if a property already matches a desired value. Sets the property and notifies listeners only when necessary.</summary>
    /// <typeparam name="T">Type of the property.</typeparam>
    /// <param name="storage">     Reference to a property with both getter and setter.</param>
    /// <param name="value">       Desired value for the property.</param>
    /// <param name="propertyName">
    /// Name of the property used to notify listeners. This value is optional and can be provided automatically when invoked from compilers that support CallerMemberName.
    /// </param>
    /// <returns>True if the value was changed, false if the existing value matched the desired value.</returns>
    protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(storage, value)) return false;
        storage = value;
        RaisePropertyChanged(propertyName);
        return true;
    }

    /// <summary>Checks if a property already matches a desired value. Sets the property and notifies listeners only when necessary.</summary>
    /// <typeparam name="T">Type of the property.</typeparam>
    /// <param name="storage">     Reference to a property with both getter and setter.</param>
    /// <param name="value">       Desired value for the property.</param>
    /// <param name="propertyName">
    /// Name of the property used to notify listeners. This value is optional and can be provided automatically when invoked from compilers that support CallerMemberName.
    /// </param>
    /// <param name="onChanged">   Action that is called after the property value has been changed.</param>
    /// <returns>True if the value was changed, false if the existing value matched the desired value.</returns>
    protected bool SetProperty<T>(ref T storage, T value, Action onChanged, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(storage, value)) return false;

        storage = value;
        onChanged?.Invoke();
        RaisePropertyChanged(propertyName);

        return true;
    }
}