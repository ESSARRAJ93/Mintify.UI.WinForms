using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Mintify.UI.WinForms.Controls;

namespace Mintify.UI.WinForms.Helpers
{
    public class MintControlDesigner
    {
    }

    public class LabelControlDesigner : ControlDesigner
    {
        public override SelectionRules SelectionRules
        {
            get
            {
                if (Control is MintLabel label && label.AutoSize)
                    return SelectionRules.Moveable;
                return base.SelectionRules;
            }
        }

        private DesignerActionListCollection actionLists;
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new LabelActionList(this.Component));
                }

                return actionLists;
            }
        }

        internal class LabelActionList : DesignerActionList
        {
            private MintLabel label;

            public LabelActionList(IComponent component) : base(component)
            {
                label = component as MintLabel;
            }

            public bool AutoSize
            {
                get => label.AutoSize;
                set
                {
                    SetProperty("AutoSize", value);
                    label.Invalidate();
                }
            }

            public string Text
            {
                get => label.Text;
                set
                {
                    SetProperty("Text", value);
                    label.Invalidate();
                }
            }

            public Font Font
            {
                get => label.Font;
                set
                {
                    SetProperty("Font", value);
                    label.Invalidate();
                }
            }

            public Padding Padding
            {
                get => label.Padding;
                set
                {
                    SetProperty("Padding", value);
                    label.Invalidate();
                }
            }

            public int BorderRadius
            {
                get => label.BorderRadius;
                set
                {
                    SetProperty("BorderRadius", value);
                    label.Invalidate();
                }
            }

            public int BorderThickness
            {
                get => label.BorderThickness;
                set
                {
                    SetProperty("BorderThickness", value);
                    label.Invalidate();
                }
            }

            private void SetProperty(string prop, object value)
            {
                PropertyDescriptor pd = TypeDescriptor.GetProperties(label)[prop];
                pd.SetValue(label, value);
            }

            public override DesignerActionItemCollection GetSortedActionItems()
            {
                DesignerActionItemCollection items = new DesignerActionItemCollection
                {
                    new DesignerActionHeaderItem("Appearance"),
                    new DesignerActionHeaderItem("Layout"),

                    new DesignerActionPropertyItem
                    (
                        "Text",
                        "Text",
                        "Appearance",
                        "Set the control text"
                    ),

                    new DesignerActionPropertyItem
                    (
                        "Font",
                        "Font",
                        "Appearance",
                        "Set the control font"
                    ),

                    new DesignerActionPropertyItem
                    (
                        "AutoSize",
                        "AutoSize",
                        "Layout",
                        "Set the control AutoSize property"
                    ),

                    new DesignerActionPropertyItem
                    (
                        "Padding",
                        "Padding",
                        "Layout",
                        "Set the control padding"
                    ),

                    new DesignerActionPropertyItem
                    (
                        "BorderRadius",
                        "Border Radius",
                        "Appearance",
                        "Set the control border radius"
                    ),

                    new DesignerActionPropertyItem
                    (
                        "BorderThickness",
                        "Border Thickness",
                        "Appearance",
                        "Set the control border thickness"
                    )
                };
                return items;
            }
        }
    }
}
