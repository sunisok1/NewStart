using System;
using System.Collections.Generic;

public class ObservableValue<T>
{
    private T _value;

    // Define an event for value changes using Action<T>
    public event Action<T> ValueChanged;

    // Property to get or set the value and notify listeners
    public T Value
    {
        get { return _value; }
        set
        {
            // Check if the new value is different from the current value
            if (!EqualityComparer<T>.Default.Equals(_value, value))
            {
                _value = value;

                // Notify listeners about the value change
                ValueChanged?.Invoke(value);
            }
        }
    }

    // Add a listener for value changes
    public void AddListener(Action<T> listener)
    {
        ValueChanged += listener;
    }

    // Remove a listener for value changes
    public void RemoveListener(Action<T> listener)
    {
        ValueChanged -= listener;
    }

    // Remove all listeners for value changes
    public void RemoveAllListeners()
    {
        ValueChanged = null;
    }
}
