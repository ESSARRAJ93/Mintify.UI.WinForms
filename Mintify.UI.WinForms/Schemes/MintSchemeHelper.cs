using System.ComponentModel;
using System.Drawing;

namespace Mintify.UI.WinForms.Schemes
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class MintSchemeHelper
    {

        [Category("Form Appearance")]
        public Color ForeColor { get; set; }
        
        [Category("Form Appearance")]
        public Color BackColor { get; set; }


        [Category("Control Appearance")]
        public Color TextColor { get; set; }
        
        [Category("Control Appearance")]
        public Color FillColor { get; set; }
        
        [Category("Control Appearance")]
        public Color BorderColor { get; set; }

        public MintSchemeHelper()
        {
        }

        public MintSchemeHelper(Color background, Color foreground, Color border, Color fill, Color text)
        {
            BackColor = background;
            ForeColor = foreground;

            FillColor = fill;
            TextColor = text;
            BorderColor = border;
        }

    }

    public enum ThemeMode
    {
        Light,
        Dark
    }
}
