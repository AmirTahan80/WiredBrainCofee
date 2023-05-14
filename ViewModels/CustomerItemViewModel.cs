using WiredBrainCofee.CustumrsApp.Model;

namespace WiredBrainCofee.CustumrsApp.ViewModels
{
    public class CustomerItemViewModel : BasicViewModel
    {
        #region Injection
        private Customer _model;
        #endregion

        #region Constructor
        public CustomerItemViewModel(Customer model)
        {
            _model = model;
        }
        #endregion

        #region Properties
        public int Id => _model.Id;
        public string? FirstName { get => _model.FirstName; set { _model.FirstName = value; RaisePropertyChanged(); } }
        public string? LastName { get => _model.LastName; set { _model.LastName = value; RaisePropertyChanged(); } }
        public bool IsDeveloper { get => _model.IsDeveloper; set { _model.IsDeveloper = value; RaisePropertyChanged(); } }
        #endregion

        #region Methods

        #endregion

    }
}
