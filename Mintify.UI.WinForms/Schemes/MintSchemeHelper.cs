using System.ComponentModel;
using System.Drawing;
using Mintify.UI.WinForms.Design;
using System.Drawing.Design;

namespace Mintify.UI.WinForms.Schemes
{
    [TypeConverter(typeof(MintSchemeConverter))]
    public class MintSchemeHelper
    {
        public TargetScheme SchemeFor { get; set; } = TargetScheme.Control;


        [Category("Form Appearance")]
        [TypeConverter(typeof(MintColorConverter))]
        [Editor(typeof(MintColorEditor), typeof(UITypeEditor))]
        public Color ForeColor { get; set; }

        [Category("Form Appearance")]
        [TypeConverter(typeof(MintColorConverter))]
        [Editor(typeof(MintColorEditor), typeof(UITypeEditor))]
        public Color BackColor { get; set; }


        [Category("Control Appearance")]
        [TypeConverter(typeof(MintColorConverter))]
        [Editor(typeof(MintColorEditor), typeof(UITypeEditor))]
        public Color TextColor { get; set; }

        [Category("Control Appearance")]
        [TypeConverter(typeof(MintColorConverter))]
        [Editor(typeof(MintColorEditor), typeof(UITypeEditor))]
        public Color FillColor { get; set; }

        [Category("Control Appearance")]
        [TypeConverter(typeof(MintColorConverter))]
        [Editor(typeof(MintColorEditor), typeof(UITypeEditor))]
        public Color BorderColor { get; set; }

        public MintSchemeHelper() { }


        public MintSchemeHelper(Color foreground, Color background)
        {
            SchemeFor = TargetScheme.Form;
            ForeColor = foreground;
            BackColor = background;

        }

        public MintSchemeHelper(Color textColor, Color fillColor, Color borderColor)
        {
            SchemeFor = TargetScheme.Control;
            TextColor = textColor;
            FillColor = fillColor;
            BorderColor = borderColor;

        }

    }

    public enum ThemeMode
    {
        Light,
        Dark
    }

    public enum TargetScheme
    {
        Form,
        Control
    }
}
