using OpiumWare.Classes;
using UnityEngine;
using static OpiumWare.Menu.Main;

namespace OpiumWare
{
    internal class Settings
    {
        public static ExtGradient backgroundColor = new ExtGradient{colors = GetSolidGradient(Color.black)};
        public static ExtGradient[] buttonColors = new ExtGradient[]
        {
            new ExtGradient{colors = GetSolidGradient(Color.gray)}, // Disabled
            new ExtGradient{colors = GetSolidGradient(Color.white)} // Enabled
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
        public static int buttonsPerPage = 8;
    }
}
