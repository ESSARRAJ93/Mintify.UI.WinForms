using System.Drawing.Design;
using System.Reflection;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace Mintify.UI.WinForms.Design
{
    public class MintColorEditor : ColorEditor
    {
        private static readonly Type ColorUIType = typeof(ColorEditor).GetNestedType("ColorUI", BindingFlags.NonPublic);
        private static readonly ConstructorInfo ColorUIConstructor = ColorUIType.GetConstructors()[0];
        private static readonly Type ColorEditorListBoxType = ColorUIType.GetNestedType("ColorEditorListBox", BindingFlags.NonPublic);
        private static readonly MethodInfo OnListClickMethod = ColorUIType.GetMethod("OnListClick", BindingFlags.NonPublic | BindingFlags.Instance);
        private static readonly MethodInfo OnListDrawItemMethod = ColorUIType.GetMethod("OnListDrawItem", BindingFlags.NonPublic | BindingFlags.Instance);
        private static readonly MethodInfo OnListKeyDownMethod = ColorUIType.GetMethod("OnListKeyDown", BindingFlags.NonPublic | BindingFlags.Instance);
        private static readonly FieldInfo ColorUIField = typeof(ColorEditor).GetField("colorUI", BindingFlags.NonPublic | BindingFlags.Instance);

        public override object EditValue(ITypeDescriptorContext
        context, System.IServiceProvider provider, object value)
        {

            var colorUI = (Control)ColorUIConstructor.Invoke(new[] { this });
            ColorUIField.SetValue(this, colorUI);

            var listBox = (ListBox)Activator.CreateInstance(ColorEditorListBoxType);

            listBox.Dock = DockStyle.Fill;
            listBox.DrawMode = DrawMode.OwnerDrawFixed;
            listBox.BorderStyle = BorderStyle.FixedSingle;

            listBox.Sorted = false;
            listBox.ItemHeight = 20;
            listBox.IntegralHeight = false;

            listBox.DrawItem += ListBox_DrawItem; ;
            listBox.Items.AddRange(MintColor.Palette.Values.Cast<object>().ToArray());

            listBox.Click += (sender, e) => OnListClickMethod.Invoke(colorUI, new[] { sender, e });
            listBox.KeyDown += (sender, e) => OnListKeyDownMethod.Invoke(colorUI, new[] { sender, e });



            var tabControl = colorUI.Controls.OfType<TabControl>().FirstOrDefault();
            if (tabControl != null)
            {
                var mintTabPage = new TabPage("Mint");
                mintTabPage.Controls.Add(listBox);
                tabControl.TabPages.Add(mintTabPage);

                if (colorUI.IsHandleCreated)
                    SelectedCurrentColor(value as Color?, colorUI, tabControl, mintTabPage, listBox);
                else
                {
                    colorUI.HandleCreated += (_, __) =>
                    {
                        SelectedCurrentColor(value as Color?, colorUI, tabControl, mintTabPage, listBox);
                    };
                }
            }

            return base.EditValue(context, provider, value);
        }

        private void SelectedCurrentColor(Color? value, Control colorUI, TabControl tabControl, TabPage mintTabPage, ListBox listBox)
        {
            if (value is Color currentColor && MintColor.Palette.Any(p => p.Value.ToArgb() == currentColor.ToArgb()))
            {
                colorUI.CreateControl();
                colorUI.PerformLayout();

                tabControl.SelectedTab = mintTabPage;

                int index = listBox.Items
                    .Cast<Color>()
                    .ToList()
                    .FindIndex(c => c.ToArgb() == currentColor.ToArgb());

                if (index >= 0)
                {
                    listBox.SelectedIndex = index;
                    listBox.TopIndex = index;
                }
            }
        }

        private void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            var colorNames = MintColor.Palette.ToDictionary(p => p.Value.ToArgb(), p => p.Key);

            if (e.Index < 0) return;

            ListBox lb = (ListBox)sender;
            object value = lb.Items[e.Index];

            e.DrawBackground();

            var color = (Color)value;
            var swatchRect = new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, 27, e.Bounds.Height - 5);

            // [DRAW COLOR PALLETE ON LISTBOX]
            this.PaintValue(value, e.Graphics,
                new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, 27, e.Bounds.Height - 5));
            e.Graphics.DrawRectangle(SystemPens.WindowText,
                new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, 27, e.Bounds.Height - 5));


            // {[DRAW COLOR NAME ON LISTBOX]
            var name = colorNames.TryGetValue(color.ToArgb(), out var label) ? label : color.Name;

            using (var foreBrush = new SolidBrush(e.ForeColor))
                e.Graphics.DrawString(name, lb.Font, foreBrush, e.Bounds.X + 32, e.Bounds.Y);
        }
    }

    public class MintColorConverter : ColorConverter
    {

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) => true;

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) => false;

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(MintColor.Palette.Values);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string s && MintColor.Palette.TryGetValue(s, out var color))
                return color;

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is Color c)
            {
                foreach (var kv in MintColor.Palette)
                {
                    if (kv.Value.ToArgb() == c.ToArgb())
                        return kv.Key;
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
