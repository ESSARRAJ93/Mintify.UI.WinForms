using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Mintify.UI.WinForms.Helpers;
using Mintify.UI.WinForms.Design;
using Mintify.UI.WinForms.Schemes;

namespace Mintify.UI.WinForms.Controls
{
    [DefaultEvent("CheckedChanged")]
    public class MintSwitch : MintControl
    {
        #region *** Fields ***
        
        // Rectangles to represent the switch background and toggle knob
        Rectangle _switch;
        Rectangle _toggle;

        // Color schemes for checked and unchecked states
        private MintSchemeHelper _checkSwitch;
        private MintSchemeHelper _checkToggle;
        private MintSchemeHelper _uncheckSwitch;
        private MintSchemeHelper _uncheckToggle;

        // Current state of the switch (on/off)
        private bool _checked = false;

        #endregion

        #region *** events ***
        [Category("Behavior")]
        [Description("Occurs when the Checked property value changes.")]
        public event EventHandler CheckedChanged;
        #endregion

        #region *** Properties ***

        /* ** Toggle state (on/off) ** */

        [Category("Behavior")]
        [Description("Determines whether the switch is in the checked state.")]
        public bool Checked
        {
            get => _checked;
            set
            {
                _checked = value;
                Invalidate();
                OnCheckedChanged(EventArgs.Empty);
            }
        }

        /* ** Custom color schemes for checked/unchecked states ** */

        [Category("Appearance")]
        [Description("Color scheme for the switch track when checked.")]
        public MintSchemeHelper CheckedSwitchColor
        {
            get => _checkSwitch;
            set
            {
                _checkSwitch = value;
                Invalidate(); // Redraw the control when theme provider changes
            }
        }

        [Category("Appearance")]
        [Description("Color scheme for the toggle knob when checked.")]
        public MintSchemeHelper CheckedToggleColor
        {
            get => _checkToggle;
            set
            {
                _checkToggle = value;
                Invalidate(); // Redraw the control when theme provider changes
            }
        }

        [Category("Appearance")]
        [Description("Color scheme for the switch track when unchecked.")]
        public MintSchemeHelper UncheckedSwitchColor
        {
            get => _uncheckSwitch;
            set
            {
                _uncheckSwitch = value;
                Invalidate(); // Redraw the control when theme provider changes
            }
        }

        [Category("Appearance")]
        [Description("Color scheme for the toggle knob when unchecked.")]
        public MintSchemeHelper UncheckedToggleColor
        {
            get => _uncheckToggle;
            set
            {
                _uncheckToggle = value;
                Invalidate(); // Redraw the control when theme provider changes
            }
        }



        [Browsable(true)]
        [DefaultValue(true)]
        [Category("Layout")]
        [Description("Gets or sets whether the control should resize to fit its content.")]
        public override bool AutoSize
        {
            get => base.AutoSize;
            set
            {
                base.AutoSize = value;
                Invalidate();
            }
        }


        // Prevent border customization for this control
        [Browsable(false)]
        public override int BorderRadius { get => base.BorderRadius; set => base.BorderRadius = value; }

        [Browsable(false)]
        public override int BorderThickness { get => base.BorderThickness; set => base.BorderThickness = value; }

        [Browsable(false)]
        public override Color BorderColor { get => base.BorderColor; set => base.BorderColor = value; }

        [Browsable(false)]
        public override Color BackColor { get => base.BackColor; set => base.BackColor = value; }

        [Browsable(false)]
        public override Color ForeColor { get => base.ForeColor; set => base.ForeColor = value; }

        [Browsable(false)]
        public override ContentAlignment TextAlign { get => base.TextAlign; set => base.TextAlign = value; }

        [Browsable(false)]
        public override string Text { get => base.Text; set => base.Text = value; }

        [Browsable(false)]
        public override Image BackgroundImage { get => base.BackgroundImage; set => base.BackgroundImage = value; }

        [Browsable(false)]
        public override ImageLayout BackgroundImageLayout { get => base.BackgroundImageLayout; set => base.BackgroundImageLayout = value; }





        #endregion

        #region *** Constructors ***
        public MintSwitch()
        {
            SetStyle
            (
                ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor, true
            );

            DoubleBuffered = true;
            AutoSize = true;
            Checked = false;
            Size = new Size(50, 22);

            // Initialize default color schemes
            _checkSwitch = new MintSchemeHelper() { TextColor = MintColor.White, FillColor = MintColor.Mint500, BorderColor = MintColor.Mint500 };
            _checkToggle = new MintSchemeHelper() { TextColor = MintColor.White, FillColor = MintColor.White, BorderColor = MintColor.Mint500 };

            _uncheckSwitch = new MintSchemeHelper() { TextColor = Color.White, FillColor = MintColor.Transparent, BorderColor = Color.Gray };
            _uncheckToggle = new MintSchemeHelper() { TextColor = Color.White, FillColor = Color.Gray, BorderColor = Color.Gray };

        }
        #endregion

        #region *** Methods ***
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            g.Clear(Parent.BackColor); // Clear the background with the parent control's color


            _switch = new Rectangle(1, 1, Width - 3, Height - 3);
            _toggle = new Rectangle(Checked ? _switch.Width - _switch.Height + 5 : 5, 5, _switch.Height - 8, _switch.Height - 8);

            //g.DrawPath(new Pen(Color.Gray, 2), path);

            using (GraphicsPath path = MintDrawing.CreateRoundedRectangle(_switch, Height - 3))
            {


                using (Pen pen = new Pen(Checked ? CheckedSwitchColor.BorderColor : UncheckedSwitchColor.BorderColor, 2))
                {
                    g.FillPath(new SolidBrush(Checked ? CheckedSwitchColor.FillColor : UncheckedSwitchColor.FillColor), path);
                    g.FillEllipse(new SolidBrush(Checked ? CheckedToggleColor.FillColor : UncheckedToggleColor.FillColor), _toggle);
                    g.DrawPath(pen, path);
                    g.DrawEllipse(new Pen(Checked ? CheckedToggleColor.BorderColor : UncheckedToggleColor.BorderColor), _toggle);
                }

            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            _switch = new Rectangle(1, 1, Width - 4, Height - 4);
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            _switch = new Rectangle(1, 1, Width - 4, Height - 4);

            Width = Height * 2 + 5;

        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            
            Checked = !Checked;
            Invalidate();
        }

        protected virtual void OnCheckedChanged(EventArgs e)
        {
            CheckedChanged?.Invoke(this, e);
        }
        #endregion
    }
}
