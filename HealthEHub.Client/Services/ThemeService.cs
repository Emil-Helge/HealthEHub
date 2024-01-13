namespace HealthEHub.Client.Services
{
    public class ThemeService
    {
        private bool _isDarkMode;
        public bool IsDarkMode
        {
            get => _isDarkMode;
            set
            {
                if (_isDarkMode != value)
                {
                    _isDarkMode = value;
                    NotifyThemeChanged();
                }
            }
        }

        public event Action OnThemeChanged;

        private void NotifyThemeChanged() => OnThemeChanged?.Invoke();
    }

}
