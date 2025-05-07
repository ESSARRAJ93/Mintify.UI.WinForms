using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Mintify.UI.WinForms.Schemes;

namespace Mintify.UI.WinForms.Components
{
    public partial class MintThemeProvider : Component
    {
        #region *** fields ***
        private Form _form;
        private ThemeMode _mode = ThemeMode.Light;
        private MintSchemeHelper _light = new MintSchemeHelper() { BackColor = Color.FromArgb(248, 250, 252), ForeColor = Color.FromArgb(15, 23, 42) };
        private MintSchemeHelper _dark = new MintSchemeHelper() { BackColor = Color.FromArgb(30, 41, 59), ForeColor = Color.White };
        #endregion

        #region *** events ***
        public event EventHandler ThemeChanged;
        #endregion

        #region *** properties ***

        /// <summary>
        /// The target form to apply the selected theme to.
        /// </summary>
        [Category("Behavior")]
        [Description("The target form to apply the selected theme to.")]
        public Form TargetForm
        {
            get => _form;
            set
            {
                _form = value;
                ApplyTheme();
                _form?.Invalidate();
            }
        }

        /// <summary>
        /// The current theme mode applied to the target form.
        /// </summary>
        [Category("Appearance")]
        [Description("The current theme mode applied to the target form.")]
        public ThemeMode Theme
        {
            get => _mode;
            set
            {
                _mode = value;
                ApplyTheme();
                _form?.Invalidate();
            }
        }

        /// <summary>
        /// The color scheme to use when the theme is set to Light mode.
        /// </summary>
        [Category("Appearance")]
        [Description("The color scheme to use when the theme is set to Light mode.")]
        public MintSchemeHelper LightTheme
        {
            get => _light;
            set
            {
                _light = value;
                ApplyTheme();
                _form?.Invalidate();
            }
        }


        /// <summary>
        /// The color scheme to use when the theme is set to Dark mode.
        /// </summary>
        [Category("Appearance")]
        [Description("The color scheme to use when the theme is set to Dark mode.")]
        public MintSchemeHelper DarkTheme
        {
            get => _dark;
            set
            {
                _dark = value;
                ApplyTheme();
                _form?.Invalidate();
            }
        }
        #endregion

        #region *** constructors ***
        public MintThemeProvider()
        {
            InitializeComponent();
        }

        public MintThemeProvider(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region *** methods ***

        /// <summary>
        /// Applies the selected theme to the application.
        /// </summary>
        private void ApplyTheme()
        {
            MintSchemeHelper theme = _mode == ThemeMode.Dark ? DarkTheme : LightTheme;

            if (TargetForm != null)
            {
                _form.BackColor = theme.BackColor;
                _form.ForeColor = theme.ForeColor;
                _form.Invalidate();
            }

            ThemeChanged?.Invoke(this, EventArgs.Empty);

        }

        /// <summary>
        /// Save the current theme mode to application settings
        /// </summary>
        public void SavePreference()
        {
            Properties.Settings.Default["ThemeMode"] = Theme.ToString();
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Loads and applies the previously saved theme mode from application settings.
        /// </summary>
        public void LoadPreference()
        {
            // 
            string saved = Properties.Settings.Default["ThemeMode"] as string;
            if (Enum.TryParse(saved, out ThemeMode savedMode))
                Theme = savedMode;
        }
        #endregion
    }
}
