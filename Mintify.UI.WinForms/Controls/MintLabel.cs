using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Mintify.UI.WinForms.Helpers;

namespace Mintify.UI.WinForms.Controls
{
    [Designer(typeof(LabelControlDesigner))]
    public class MintLabel : MintControl
    {
        #region *** fields ***
        #endregion

        #region *** properties ***

        [Browsable(true)]
        [DefaultValue(true)]
        public override bool AutoSize
        {
            get => base.AutoSize;
            set
            {
                base.AutoSize = value;
                UpdateSizeBounds();
                Invalidate();
            }
        }

        public override int BorderRadius { get => base.BorderRadius; set => base.BorderRadius = value; }
        #endregion

        #region *** constructors ***

        public MintLabel()
        {
            SetStyle
            (
                ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor, true
            );
            //UpdateStyles();


            DoubleBuffered = true;
            AutoSize = true;

            Size = new Size(100, 22);

            BorderRadius = 5;

        }

        #endregion

        #region *** methods ***

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Parent.BackColor);

            Rectangle baseRect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle txtRect = Rectangle.Inflate(baseRect, -Padding.Horizontal / 2, -Padding.Vertical / 2);
            
            int offset = BorderThickness / 2;
            int radius = BorderRadius - BorderThickness - 1;
            
            baseRect.Inflate(-offset, -offset); // Adjust for border thickness

            using (GraphicsPath path = MintDrawing.CreateRoundedRectangle(baseRect, radius))
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


            TextRenderer.DrawText(g, Text, Font, txtRect, ForeColor, GetTextFormatFlags(TextAlign));
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (AutoSize)
                UpdateSizeBounds();

            Invalidate();
        }
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);

            if (AutoSize)
                UpdateSizeBounds();

            Invalidate();
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);

            if (AutoSize)
                UpdateSizeBounds();

            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (AutoSize)
                UpdateSizeBounds();
            Invalidate();
        }

        private void UpdateSizeBounds()
        {
            // Calculate minimum height based on text + padding
            var flags = GetTextFormatFlags(TextAlign);
            var textSize = TextRenderer.MeasureText(Text, Font, Size.Empty, flags);

            // Add vertical padding + margin
            int minHeight = textSize.Height + Padding.Top + Padding.Bottom + 2;
            int minWidth = textSize.Width + Padding.Left + Padding.Right;
            Size = new Size(minWidth, minHeight);
        }
        #endregion
    }
}
