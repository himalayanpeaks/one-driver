using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OneDriver.Framework.Base
{
    public class PropertyHandlers
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public event PropertyValidationEventHandler? PropertyChanging;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanging(object newValue, [CallerMemberName] string propertyName = null)
        {
            PropertyChanging?.Invoke(this, new PropertyValidationEventArgs(propertyName, newValue));
        }
        protected T GetProperty<T>([CallerMemberName] string propertyName = null)
        {
            return OnPropertyRequested<T>(propertyName);
        }
        protected virtual T OnPropertyRequested<T>([CallerMemberName] string propertyName = null)
        {
            var e = new PropertyReadRequestedEventArgs(propertyName);
            PropertyReadRequested?.Invoke(this, e);

            return (T)e.Value;
        }
        public event PropertyReadRequestedEventHandler PropertyReadRequested;

        protected virtual void OnPropertyReadRequest(object newValue, [CallerMemberName] string propertyName = null)
        {
            PropertyReadRequested?.Invoke(this, new PropertyReadRequestedEventArgs(propertyName));
        }
        public bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            try
            {
                OnPropertyChanging(value, propertyName);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Validation failed for property '{propertyName}': {ex.Message}");
                return false; // Prevent field update
            }
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected T GetProperty<T>(ref T field)
        {
            return field;
        }
    }

    public delegate void PropertyValidationEventHandler(object sender, PropertyValidationEventArgs e);

    public class PropertyValidationEventArgs : PropertyChangedEventArgs
    {
        /// <summary>
        /// Arguments for validation event
        /// </summary>
        /// <param name="propertyName">Name of property which is in changing state but hasn't changed yet</param>
        /// <param name="newValue">value against which the property has to be validated</param>
        public PropertyValidationEventArgs(string propertyName, object newValue) : base(propertyName)
        {
            NewValue = newValue;
        }
        /// <summary>
        /// value against which the property has to be validated
        /// </summary>
        public object NewValue { get; }
    }
    /// <summary>
    /// Implement this interface when it is desired to verify the (passed) value of a property before changing
    /// If the validation fails, an exception shall be thrown
    /// </summary>
    public interface IHasValidation
    {
        public event PropertyValidationEventHandler PropertyChanging;
    }
}
