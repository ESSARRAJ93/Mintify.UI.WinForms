using System.Drawing;
using System.Windows.Forms;
using Mintify.UI.WinForms.Helpers;
using System.Drawing.Drawing2D;
using Mintify.UI.WinForms.Design;
using System;

namespace Mintify.UI.WinForms.Controls
{
    public class MintButton : MintControl
    {
        #region *** fields ***
        private StringFormat @string = new StringFormat();

        private bool hovered;
        private bool pressed;
        #endregion

        #region *** properties ***
        /* ** colors of control ** */
        public override Color ForeColor
        {
            get => GetThemeColor(theme => theme.TextColor, base.ForeColor);
            set
            {
                base.ForeColor = value;
                Invalidate();
            }
        }
        #endregion

        #region *** events ***
        #endregion

        #region *** constructors ***
        public MintButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            DoubleBuffered = true;
            Size = new Size(100, 30);

            @string.Alignment = StringAlignment.Center;
            @string.LineAlignment = StringAlignment.Center;

            ForeColor = MintColor.White;
            BackColor = MintColor.Mint500;
            BorderColor = MintColor.Mint500;
        }
        #endregion

        #region *** methods ***
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.Clear(Parent.BackColor);

            Rectangle baseRect = new Rectangle(0, 0, Width - 1, Height - 1);

            int offset = BorderThickness / 2;
            int radius = BorderRadius - BorderThickness - 1;

            baseRect.Inflate(-offset, -offset); // Adjust for border thickness

            using (GraphicsPath path = MintDrawing.CreateRoundedRectangle(baseRect, radius))
            {
                // Fill background
                g.FillPath(new SolidBrush(BackColor), path);

                if (hovered)
                    g.FillPath(new SolidBrush(MintColor.WithAlpha(MintColor.White, 30)), path);
                if (pressed)
                    g.FillPath(new SolidBrush(MintColor.WithAlpha(MintColor.Black, 60)), path);

                g.SetClip(path);

                // Draw border
                if (BorderThickness >= 1)
                {
                    using (Pen pen = new Pen(BorderColor, BorderThickness))
                    {
                        
                        g.DrawPath(pen, path);
                        if (hovered)
                            g.DrawPath(new Pen(MintColor.WithAlpha(MintColor.White, 30)),path);
                        if (pressed)
                            g.DrawPath(new Pen(MintColor.WithAlpha(MintColor.Black, 60)), path);
                    }
                }

            }

            g.DrawString(Text, Font, new SolidBrush(ForeColor), ClientRectangle, @string);

        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Invalidate();
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            hovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            hovered = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            pressed = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            pressed = false;
            Invalidate();
        }
        #endregion
    }
}
