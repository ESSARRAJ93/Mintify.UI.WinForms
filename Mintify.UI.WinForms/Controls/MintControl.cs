using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using Mintify.UI.WinForms.Helpers;
using System;
using System.ComponentModel;

namespace Mintify.UI.WinForms.Controls
{
    public class MintControl : Control
    {
        #region *** fields ***

        private string _text;
        private ContentAlignment _textAlign = ContentAlignment.MiddleLeft;

        /* ** integer fields ** */
        private int borderRadius;
        private int borderThickness;

        /* ** colors fields ** */
        private Color foreColor;
        private Color backColor;
        private Color borderColor;

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
                int maxRadius = Math.Min(Height, Width);
                borderRadius = Math.Max(0, Math.Min(value, maxRadius));
                Invalidate(); // Redraw the control when border radius changes
            }
        }

        /* ** colors properties ** */
        public virtual new Color ForeColor
        {
            get => foreColor;
            set
            {
                foreColor = value;
                Invalidate(); // Redraw the control when foreground color changes
            }
        }

        public virtual new Color BackColor
        {
            get => backColor;
            set
            {
                backColor = value;
                Invalidate(); // Redraw the control when background color changes
            }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get => borderColor;
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

        public new virtual string Text
        {
            get => _text;
            set
            {
                _text = value;
                Invalidate(); // Redraw the control when text changes
            }
        }

        #endregion

        #region *** constructors ***
        public MintControl()
        {
            SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();
            DoubleBuffered = true;

            Size = new Size(100, 30);
        }
        #endregion

        #region *** methods ***

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Ensure the border radius does not exceed the control's height
            if (borderRadius > Height)
                BorderRadius = Height;

            UpdateMinHeight(); // Update minimum height based on text and padding
            Invalidate(); // Redraw the control when resized

        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);

            UpdateMinHeight(); // Update minimum height based on font change
            Invalidate(); // Redraw the control when font changes
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);

            UpdateMinHeight(); // Update minimum height based on padding change
            Invalidate(); // Redraw the control when padding changes
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Parent?.BackColor ?? SystemColors.Control);

            Rectangle rect = new Rectangle(0,0, Width - 1, Height - 1);
            int offset = BorderThickness / 2;
            int radius = BorderRadius - BorderThickness - 1;

            rect.Inflate(-offset, -offset); // Adjust for border thickness

            using (GraphicsPath path = MintDrawing.CreateRoundedRectangle(rect, radius))
            {
                // Fill background
                using (SolidBrush brush = new SolidBrush(BackColor))
                    g.FillPath(brush, path);

                // Draw border
                if (BorderThickness >= 1)
                {
                    using (Pen pen = new Pen(BorderColor, BorderThickness))
                        g.DrawPath(pen, path);
                }

            }
            Rectangle paddedRect = Rectangle.Inflate(rect, -Padding.Horizontal / 2, -Padding.Vertical / 2);

            // Draw text
            TextRenderer.DrawText(g, Text, Font, paddedRect, ForeColor, GetTextFormatFlags(TextAlign));
        }

        private TextFormatFlags GetTextFormatFlags(ContentAlignment align)
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

        private void UpdateMinHeight()
        {
            // Calculate minimum height based on text + padding
            var flags = GetTextFormatFlags(TextAlign);
            var textSize = TextRenderer.MeasureText(Text, Font, new Size(Width, int.MaxValue), flags);

            // Add vertical padding + margin
            int minHeight = textSize.Height + Padding.Top + Padding.Bottom + 10;
            MinimumSize = new Size(0, minHeight);
        }
        #endregion
    }
}
