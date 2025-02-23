using opiumMenu.Classes;
using UnityEngine;
using static opiumMenu.Menu.Main;

namespace opiumMenu
{
    internal class Settings
    {
        public static ExtGradient backgroundColor = new ExtGradient{colors = GetSolidGradient(Color.magenta)};
        public static ExtGradient[] buttonColors = new ExtGradient[]
        {
            new ExtGradient{colors = GetSolidGradient(Color.black) }, // Disabled
            new ExtGradient{isRainbow = true} // Enabled
        };
        public static Color[] textColors = new Color[]
        {
            Color.white, // Disabled
            Color.black // Enabled
        };

        public static Font currentFont = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);

        public static bool fpsCounter = true;
        public static bool disconnectButton = true;
        public static bool rightHanded = false;
        public static bool disableNotifications = false;

        public static KeyCode keyboardButton = KeyCode.Q;

        public static Vector3 menuSize = new Vector3(0.05f, 0.9f, 1.2f); // Depth, Width, Height
        public static int buttonsPerPage = 9;
    }
}
