using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Mintify.UI.WinForms.Design;
using Mintify.UI.WinForms.Helpers;
using Mintify.UI.WinForms.Schemes;

namespace Mintify.UI.WinForms.Controls
{
    [Designer(typeof(TextBoxControlDesigner))]
    public class MintTextBox : MintControl
    {
        #region *** fields ***
        private bool multiline;

        private bool focused => txtField.Focused;
        private bool disabled;
        private bool hovered;
        private bool pressed;

        private TextBox txtField = new TextBox();
        private MintSchemeHelper normalState;
        private MintSchemeHelper hoverState;
        private MintSchemeHelper focusState;
        private MintSchemeHelper disableState;
        private readonly StringFormat @string = new StringFormat();


        #endregion

        #region *** events ***
        #endregion

        #region *** properties ***

        
        
        public MintSchemeHelper NormalState
        {
            get => normalState;
            set
            {
                if (ThemeProvider == null)
                    normalState = value;

                Invalidate();
            }
        }

        public MintSchemeHelper HoverState
        {
            get => hoverState;
            set
            {
                if (ThemeProvider == null)
                    hoverState = value;

                Invalidate();
            }
        }

        public MintSchemeHelper FocusState
        {
            get => focusState;
            set
            {
                if (ThemeProvider == null)
                    focusState = value;

                Invalidate();
            }
        }

        public MintSchemeHelper DisableState
        {
            get => disableState;
            set
            {
                if (ThemeProvider == null)
                    disableState = value;

                Invalidate();
            }
        }

        [Category("Behavior")]
        public bool Multiline
        {
            get => multiline;
            set
            {
                multiline = value;
                txtField.Multiline = value;
                Invalidate();
            }
        }

        public new bool Enabled
        {
            get => base.Enabled;
            set
            {
                base.Enabled = value;
                OnStateChanged();
                Invalidate();
            }
        }

        [DefaultValue(null)]
        public override string Text
        {
            get => txtField.Text ?? string.Empty;
            set
            {
                if (txtField != null)
                    txtField.Text = value ?? string.Empty;

                base.Text = value;
                Invalidate();
            }
        }

        

        #endregion

        #region *** constructors ***
        public MintTextBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            UpdateStyles();

            DoubleBuffered = true;
            BorderThickness = 1;
            Size = new Size(150, 25);

            @string.Alignment = StringAlignment.Near;
            @string.LineAlignment = StringAlignment.Center;

            normalState = new MintSchemeHelper
            {
                FillColor = MintColor.White,
                BorderColor = MintColor.Gray200,
                TextColor = MintColor.Gray300
            };

            hoverState = new MintSchemeHelper
            {
                FillColor = MintColor.White,
                BorderColor = MintColor.Mint200,
                TextColor = MintColor.Mint200
            };

            focusState = new MintSchemeHelper
            {
                FillColor = MintColor.White,
                BorderColor = MintColor.Mint500,
                TextColor = MintColor.Mint500
            };

            disableState = new MintSchemeHelper
            {
                FillColor = MintColor.White,
                BorderColor = MintColor.Gray400,
                TextColor = MintColor.Gray400
            };

            OnStateChanged();
            OnCreateTxtField();
            Controls.Add(txtField);
            
            Text = null;


            
        }
        #endregion

        #region *** methods ***
        private void OnCreateTxtField()
        {
            txtField = new TextBox
            {
                Name = "TextInput",
                BorderStyle = BorderStyle.None,
                Font = new Font(Font.FontFamily, Font.Size + 0.8F),
                Text = Text,
                Width = Width - 20,
                BackColor = BackColor,
                ForeColor = ForeColor,
                Location = new Point(10, 5)
            };
            
            txtField.TextChanged += (s, e) => { OnTextChanged(e); };
            txtField.FontChanged += (s, e) => { OnFontChanged(e); };
            txtField.SizeChanged += (s, e) => { OnSizeChanged(e); };

            txtField.KeyDown += (s, e) => { OnKeyDown(e); };
            txtField.KeyPress += (s, e) => { OnKeyPress(e); };
            txtField.KeyUp += (s, e) => { OnKeyUp(e); };

            txtField.GotFocus += (s, e) => { OnGotFocus(e); };
            txtField.LostFocus += (s, e) => { OnLostFocus(e); };

            txtField.MouseEnter += (s, e) => { OnMouseEnter(e); };
            txtField.MouseLeave += (s, e) => { OnMouseLeave(e); };

            //txtField.EnabledChanged += (s, e) => { OnEnabledChanged(e); };
        }

        private void OnHandleResize()
        {
            if (!multiline)
            {
                Height = txtField.ClientSize.Height + 10;
                txtField.Width = Width - 20;
                return;
            }

            txtField.Width = Width - 20;
            txtField.Height = Height - 10;
            Invalidate();
        }

        private void OnStateChanged()
        {
            if (ThemeProvider == null)
            {
                
                if(focused)
                {
                    ForeColor = FocusState.TextColor;
                    BackColor = FocusState.FillColor;
                    BorderColor = FocusState.BorderColor;
                }

                else if (hovered)
                {
                    ForeColor = HoverState.TextColor;
                    BackColor = HoverState.FillColor;
                    BorderColor = HoverState.BorderColor;
                }
                else if (!Enabled)
                {
                    ForeColor = DisableState.TextColor;
                    BackColor = DisableState.FillColor;
                    BorderColor = DisableState.BorderColor;
                }
                else
                {
                    ForeColor = NormalState.TextColor;
                    BackColor = NormalState.FillColor;
                    BorderColor = NormalState.BorderColor;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //OnStateChanged();

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

                // Draw border
                if (BorderThickness >= 1)
                {
                    using (Pen pen = new Pen(BorderColor, BorderThickness))
                        g.DrawPath(pen, path);
                }

            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            txtField.Text = Text;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            OnHandleResize();
            Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            OnHandleResize();
            Invalidate();
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);

            txtField.BackColor = BackColor;
            Invalidate();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            txtField.ForeColor = ForeColor;
            Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Text = txtField.Text;
            Invalidate();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e); 
            txtField.Font = Font;
            using (var g = CreateGraphics())
            {
                var size = TextRenderer.MeasureText(g, txtField.Text, Font,
                    new Size(int.MaxValue, int.MaxValue),
                    TextFormatFlags.TextBoxControl);
                Size = new Size(size.Width + 20, size.Height + 10);
            }
            Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            OnStateChanged();
            txtField.Focus();
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            OnStateChanged();
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            hovered = true;
            OnStateChanged();
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            hovered = false;
            OnStateChanged();
            Invalidate();
        }

        #endregion
    }
}
