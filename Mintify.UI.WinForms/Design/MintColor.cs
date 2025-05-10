using System.Collections.Generic;
using System.Drawing;

namespace Mintify.UI.WinForms.Design
{
    public class MintColor
    {
        #region ## colors ##
        public static Color Black => ColorTranslator.FromHtml("#000000");
        public static Color White => ColorTranslator.FromHtml("#FFFFFF");
        public static Color Transparent => ColorTranslator.FromHtml("#00FFFFFF");

        /* ** Mint Color */
        #region *** Mint ***
        public static Color Mint50 => ColorTranslator.FromHtml("#F0FAF6");
        public static Color Mint100 => ColorTranslator.FromHtml("#E1F5ED");
        public static Color Mint200 => ColorTranslator.FromHtml("#BEE9D9");
        public static Color Mint300 => ColorTranslator.FromHtml("#95DAC1");
        public static Color Mint400 => ColorTranslator.FromHtml("#67CBA6");
        public static Color Mint500 => ColorTranslator.FromHtml("#3EB489");
        public static Color Mint600 => ColorTranslator.FromHtml("#38A37C");
        public static Color Mint700 => ColorTranslator.FromHtml("#308C6B");
        public static Color Mint800 => ColorTranslator.FromHtml("#287659");
        public static Color Mint900 => ColorTranslator.FromHtml("#1D533F");
        #endregion

        /* ** Gray Color */
        #region *** Gray ***
        public static Color Gray50 => ColorTranslator.FromHtml("#F5F5F5");
        public static Color Gray100 => ColorTranslator.FromHtml("#EDEDED");
        public static Color Gray200 => ColorTranslator.FromHtml("#D9D9D9");
        public static Color Gray300 => ColorTranslator.FromHtml("#BFBFBF");
        public static Color Gray400 => ColorTranslator.FromHtml("#A3A3A3");
        public static Color Gray500 => ColorTranslator.FromHtml("#808080");
        public static Color Gray600 => ColorTranslator.FromHtml("#737373");
        public static Color Gray700 => ColorTranslator.FromHtml("#666666");
        public static Color Gray800 => ColorTranslator.FromHtml("#545454");
        public static Color Gray900 => ColorTranslator.FromHtml("#383838");
        #endregion

        #endregion

        #region ## colors dictionary ##

        public static readonly Dictionary<string, Color> Palette = new Dictionary<string, Color>()
        {
            #region *** Black & White Colors ***
            { "Black", Black },
            { "White", White },
            #endregion

            #region *** Mint Colors ***
            { "Mint50", Mint50 },
            { "Mint100", Mint100 },
            { "Mint200", Mint200 },
            { "Mint300", Mint300 },
            { "Mint400", Mint400 },
            { "Mint500", Mint500 },
            { "Mint600", Mint600 },
            { "Mint700", Mint700 },
            { "Mint800", Mint800 },
            { "Mint900", Mint900 },
            #endregion

            #region *** Gray Colors ***
            { "Gray50", Gray50 },
            { "Gray100", Gray100 },
            { "Gray200", Gray200 },
            { "Gray300", Gray300 },
            { "Gray400", Gray400 },
            { "Gray500", Gray500 },
            { "Gray600", Gray600 },
            { "Gray700", Gray700 },
            { "Gray800", Gray800 },
            { "Gray900", Gray900 },
            #endregion

        };

        #endregion

        #region ## methods ##
        /// <summary>
        /// Converts a hex color string to a System.Drawing.Color instance.
        /// Accepts both shorthand (#FFF) and full (#FFFFFF) formats.
        /// </summary>
        /// <param name="hex">Hexadecimal color string (e.g., "#ffcc00").</param>
        /// <returns>Corresponding Color object.</returns>
        public static Color FromHex(string hex)
        {
            return ColorTranslator.FromHtml(hex);
        }

        /// <summary>
        /// Returns the color with the specified alpha (transparency) value.
        /// </summary>
        /// <param name="color">The base color.</param>
        /// <param name="alpha">Alpha value (0 to 255).</param>
        /// <returns>New color with applied alpha.</returns>
        public static Color WithAlpha(Color color, int alpha) => Color.FromArgb(alpha, color);
        #endregion
    }
}
