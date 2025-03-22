using OneDriver.Framework.Base;
using System.ComponentModel;

namespace OneDriver.Framework.Libs.Validator
{
    public class ValidatorViewModel : PropertyHandlers, IParameter
    {
        private string _userInput;
        private bool _isValid;
        private IValidator _validator;


        public ValidatorViewModel(IValidator validator)
        {
            Validator = validator;
            PropertyChanged += ValidatorViewModel_PropertyChanged;
            PropertyChanging += ValidatorViewModel_PropertyChanging;
            IsValid = false;
            UserInput = Validator.GetExample();

        }

        private void ValidatorViewModel_PropertyChanging(object sender, PropertyValidationEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(UserInput):
                    string s = (string)e.NewValue;
                    if (string.IsNullOrEmpty(s) || !Validator.Validate(s))
                    {
                        IsValid = false;
                    }
                    else
                        IsValid = true;
                    break;
            }
        }



        private void ValidatorViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Validator):
                    OnPropertyChanged(nameof(ExampleText));
                    break;
            }
        }



        // The validator instance
        public IValidator Validator
        {
            get => GetProperty(ref _validator);
            set
            {
                SetProperty(ref _validator, value);
                OnPropertyChanged(nameof(ExampleText));
            }
        }

        // User input bound to the TextBox
        public string UserInput
        {
            get => GetProperty(ref _userInput);
            set => SetProperty(ref _userInput, value);
        }

        // Validation result
        public bool IsValid
        {
            get => GetProperty(ref _isValid);
            private set => SetProperty(ref _isValid, value);
        }

        // Example text provided by the validator
        public string ExampleText => Validator?.GetExample() ?? string.Empty;



        // Validate the current input
        private void ValidateInput()
        {
            if (Validator == null || string.IsNullOrEmpty(UserInput))
            {
                IsValid = false;
            }
            else
            {
                IsValid = Validator.Validate(UserInput);
            }
        }

    }
}
