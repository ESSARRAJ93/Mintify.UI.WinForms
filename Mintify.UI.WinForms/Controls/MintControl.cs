using System.Drawing;
using System.Windows.Forms;
using System;
using System.ComponentModel;
using Mintify.UI.WinForms.Components;
using Mintify.UI.WinForms.Schemes;


namespace Mintify.UI.WinForms.Controls
{
    [DesignerCategory("Code")]
    public class MintControl : Control
    {
        #region *** fields ***

        private TargetScheme schemeFor = TargetScheme.Control;
        private ContentAlignment _textAlign = ContentAlignment.MiddleLeft;
        
        private MintThemeProvider _provider;

        /* ** integer fields ** */
        private int borderRadius;
        private int borderThickness;

        /* ** colors fields ** */
        private Color borderColor = Color.Black;

        #endregion

        #region *** properties ***

        /* ** integer properties ** */
        [Category("Appearance")]
        public virtual int BorderThickness
        {
            get => borderThickness;
            set
            {
                borderThickness = value;
                Invalidate(); // Redraw the control when border thickness changes
            }
        }

        [Category("Appearance")]
        public virtual int BorderRadius
        {
            get => borderRadius;
            set
            {
                //int maxRadius = Math.Min(Height, Width);
                borderRadius = value;
                Invalidate(); // Redraw the control when border radius changes
            }
        }

        /* ** colors properties ** */
        public override Color ForeColor 
        { 
            get => GetThemeColor(theme => theme.ForeColor, base.ForeColor); 
            set {
                base.ForeColor = value;
                Invalidate();
            } 
        }

        public override Color BackColor
        {
            get => GetThemeColor(theme => theme.BackColor, base.BackColor);
            set
            {
                base.BackColor = value;
                Invalidate(); // Redraw the control when background color changes
            }
        }

        [Category("Appearance")]
        public virtual Color BorderColor
        {
            get => GetThemeColor(theme => theme.BorderColor, borderColor);
            set
            {
                borderColor = value;
                Invalidate(); // Redraw the control when border color changes
            }
        }


        [Category("Appearance")]
        [Description("Gets or sets the alignment of the text.")]
        public virtual ContentAlignment TextAlign
        {
            get => _textAlign;
            set
            {
                _textAlign = value;
                Invalidate();
            }
        }

        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                Invalidate(); // Redraw the control when text changes
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="MintThemeProvider"/> associated with the control.
        /// This property allows the control to apply a theme, such as colors and styles,
        /// based on the provided <see cref="MintThemeProvider"/>.
        /// </summary>
        /// <value>
        /// The <see cref="MintThemeProvider"/> instance that defines the theme for the control.
        /// </value>
        /// <remarks>
        /// Setting this property triggers a redraw of the control to reflect any theme changes.
        /// </remarks>
        [Category("Behavior")]
        [Description("Gets or sets the MintThemeProvider that defines the control's appearance.")]

        public MintThemeProvider ThemeProvider
        {
            get => _provider;
            set
            {
                _provider = value;
                Invalidate(); // Redraw the control when theme provider changes
            }
        }

        public virtual TargetScheme SchemeFor
        {
            get => schemeFor;
        }
        #endregion

        #region *** constructors ***
        public MintControl() { }
        #endregion

        #region *** methods ***

        public virtual TextFormatFlags GetTextFormatFlags(ContentAlignment align)
        {
            TextFormatFlags flags = TextFormatFlags.GlyphOverhangPadding;

            switch (align)
            {
                case ContentAlignment.TopLeft:
                    flags |= TextFormatFlags.Top | TextFormatFlags.Left;
                    break;
                case ContentAlignment.TopCenter:
                    flags |= TextFormatFlags.Top | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.TopRight:
                    flags |= TextFormatFlags.Top | TextFormatFlags.Right;
                    break;
                case ContentAlignment.MiddleLeft:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
                    break;
                case ContentAlignment.MiddleCenter:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.MiddleRight:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Right;
                    break;
                case ContentAlignment.BottomLeft:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.Left;
                    break;
                case ContentAlignment.BottomCenter:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.BottomRight:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.Right;
                    break;
                default:
                    flags = TextFormatFlags.Default;
                    break;
            }

            return flags;
        }

        protected virtual Color GetThemeColor(Func<MintSchemeHelper, Color> selector, Color fallback)
        {
            return ThemeProvider != null
                ? (ThemeProvider.Theme == ThemeMode.Dark
                    ? selector(ThemeProvider.DarkTheme)
                    : selector(ThemeProvider.LightTheme))
                : fallback;
        }
        #endregion
    }
}
