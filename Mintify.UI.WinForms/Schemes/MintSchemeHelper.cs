using System.ComponentModel;
using System.Drawing;

namespace Mintify.UI.WinForms.Schemes
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class MintSchemeHelper
    {

        public Color ForeColor { get; set; }
        public Color BackColor { get; set; }
        //public Color BorderColor { get; set; }
        
        
        //public Color FillColor { get; set; }
        //public Color TextColor { get; set; }

        public MintSchemeHelper()
        {
        }

        public MintSchemeHelper(Color background, Color foreground)
        {
            BackColor = background;
            ForeColor = foreground;
        }

    }

    public enum ThemeMode
    {
        Light,
        Dark
    }
}
