using System;
using System.ComponentModel;
using System.Linq;
using Mintify.UI.WinForms.Schemes;

namespace Mintify.UI.WinForms.Design
{
    public class MintSchemeConverter : ExpandableObjectConverter
    {
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            var helper = value as MintSchemeHelper;
            if (helper == null)
                return base.GetProperties(context, value, attributes);

            var props = TypeDescriptor.GetProperties(helper);

            // Filter based on the 'target' property
            string[] visibleProps;

            switch (helper.SchemeFor)
            {
                case TargetScheme.Form:
                    visibleProps = new[] { "ForeColor", "BackColor" };
                    break;
                case TargetScheme.Control:
                    visibleProps = new[] { "TextColor", "FillColor", "BorderColor" };
                    break;
                default:
                    visibleProps = new string[0];
                    break;
            }

            // Filter the properties based on the visibleProps array
            var filtered = props.Cast<PropertyDescriptor>()
                                .Where(p => visibleProps.Contains(p.Name))
                                .ToArray();

            return new PropertyDescriptorCollection(filtered);
        }
    }
}