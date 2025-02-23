using opiumMenu.Classes;
using opiumMenu.Mods;
using opiumMenu.Mods.Spammers;
using opiumMenu.Notifications;
using UnityEngine;
using static opiumMenu.Menu.Main;
using static opiumMenu.Settings;

namespace opiumMenu.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods
                new ButtonInfo { buttonText = "Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "Join Discord", method =() => SettingsV2.JoinDiscord(), isTogglable = false, toolTip = "Opens web to discord on PC."},
                new ButtonInfo { buttonText = "Menu", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Safety", method =() => SettingsMods.SafetySettings(), isTogglable = false, toolTip = "Opens the safety settings for the menu."},
                new ButtonInfo { buttonText = "Player", method =() => SettingsMods.PlayerSettings(), isTogglable = false, toolTip = "Opens the player settings for the menu."},
                new ButtonInfo { buttonText = "Visual", method =() => SettingsMods.VisualSettings(), isTogglable = false, toolTip = "Opens the visual settings for the menu."},
                new ButtonInfo { buttonText = "Movement", method =() => SettingsMods.MovementSettings(), isTogglable = false, toolTip = "Opens the movement settings for the menu."},
                new ButtonInfo { buttonText = "Projectile", method =() => SettingsMods.ProjectileSettings(), isTogglable = false, toolTip = "Opens the projectile settings for the menu."},
                new ButtonInfo { buttonText = "Overpowered", method =() => SettingsMods.OverpoweredSettings(), isTogglable = false, toolTip = "Opens the overpowered settings for the menu."},
                new ButtonInfo { buttonText = "Master", method =() => SettingsMods.MasterSettings(), isTogglable = false, toolTip = "Opens the master settings for the menu."},
                new ButtonInfo { buttonText = "Experimental", method =() => SettingsMods.ExperimentalSettings(), isTogglable = false, toolTip = "Opens the experimental settings for the menu."},
            },

            new ButtonInfo[] { // Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Quit Game", method =() => Application.Quit(), toolTip = "Quits game.", isTogglable = false},
                new ButtonInfo { buttonText = "Disconnect", method =() => SettingsV2.Disconnect(), toolTip = "Disconnects you from current room.", isTogglable = false},
                new ButtonInfo { buttonText = "Reconnect", method =() => SettingsV2.Reconnect(), toolTip = "Reconnects you to room.", isTogglable = false},
                new ButtonInfo { buttonText = "Join Random", method =() => SettingsV2.JoinRandom(), toolTip = "Connects you to a random public.", isTogglable = false},
                new ButtonInfo { buttonText = "Disable Network Triggers", enableMethod =() => SettingsV2.DisableNT(), disableMethod =() => SettingsV2.EnableNT(), toolTip = "Disables room triggers. UND", isTogglable = true},
                new ButtonInfo { buttonText = "Disable Map Triggers", enableMethod =() => SettingsV2.DisableMT(), disableMethod =() => SettingsV2.EnableMT(), toolTip = "Disables map room triggers. UND", isTogglable = true},
            },

            new ButtonInfo[] { // Menu Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Both Hands", enableMethod =() => SettingsMods.BothHandsOn(), disableMethod =() => SettingsMods.BothHandsOff(), toolTip = "Puts the menu on both of your hands."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => SettingsMods.EnableFPSCounter(), disableMethod =() => SettingsMods.DisableFPSCounter(), enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
            },

            new ButtonInfo[] { // Safety Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "AntiReport <color=grey>[</color><color=green>Disconnect</color><color=grey>]</color>", method =() => Safety.AntiReportD(), toolTip = "Kicks you when someone is trying to report you. UND", isTogglable = true},
                new ButtonInfo { buttonText = "No Finger Movement", method =() => Safety.NoFingers(), toolTip = "Disables your finger movements. UND", isTogglable = true},
            },

            new ButtonInfo[] { // Player Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Ghost (A)", method =() => Player.Ghost(), toolTip = "Makes you a ghost.", isTogglable = true},
                new ButtonInfo { buttonText = "Invisible (T)", method =() => Player.Invis(), toolTip = "Turns you invisible.", isTogglable = true},
                new ButtonInfo { buttonText = "Backwards Head", method =() => Player.BackwardHead(), disableMethod =() => Player.NormalHead(), toolTip = "Self-explainitory.", isTogglable = true},
                new ButtonInfo { buttonText = "Grab Rig (G)", method =() => Player.GrabRig(), toolTip = "Places your rig in your hand with grips are used.", isTogglable = true},
                new ButtonInfo { buttonText = "Rig Gun", method =() => Player.RigGunMod(), toolTip = "Places your rig wherever you shoot it.", isTogglable = true},
                new ButtonInfo { buttonText = "TP Gun", method =() => Player.TPGun(), toolTip = "TPs you wherever you shoot.", isTogglable = true},
                new ButtonInfo { buttonText = "Steam Long Arms", method =() => Player.EnableSteamLongArms(), disableMethod =() => Player.DisableSteamLongArms(), toolTip = "Gives you long arms similar to override world scale."},
                new ButtonInfo { buttonText = "Stick Long Arms", method =() => Player.StickLongArms(), toolTip = "Makes you look like you're using sticks."},
                new ButtonInfo { buttonText = "Multiplied Long Arms", method =() => Player.MultipliedLongArms(), toolTip = "Gives you a weird version of long arms."},
                new ButtonInfo { buttonText = "Vertical Long Arms", method =() => Player.VerticalLongArms(), toolTip = "Gives you a version of long arms to help you vertically."},
                new ButtonInfo { buttonText = "Horizontal Long Arms", method =() => Player.HorizontalLongArms(), toolTip = "Gives you a version of long arms to help you horizontally."},

            },

            new ButtonInfo[] { // Visual Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Tracers", method =() => Visual.Tracer(), toolTip = "Lines out of right hand showing players location", isTogglable = true},
                new ButtonInfo { buttonText = "BoxESP", method =() => Visual.BoxEsp(), toolTip = "Boxes showing players location", isTogglable = true},
                new ButtonInfo { buttonText = "Morning Time", method =() => Visual.MorningTime(), toolTip = "Turns the world to morning time.", isTogglable = false},
                new ButtonInfo { buttonText = "Day Time", method =() => Visual.DayTime(), toolTip = "Turns the world to day time.", isTogglable = false},
                new ButtonInfo { buttonText = "Evening Time", method =() => Visual.EveningTime(), toolTip = "Turns the world to evening time.", isTogglable = false},
                new ButtonInfo { buttonText = "Night Time", method =() => Visual.NightTime(), toolTip = "Turns the world to night time.", isTogglable = false},
                new ButtonInfo { buttonText = "Rainy Weather", method =() => Visual.Rain(), disableMethod =() => Visual.NoRain(), toolTip = "Turns the weather to rain.", isTogglable = true},
                new ButtonInfo { buttonText = "RGB Sky", method =() => Visual.RGBSky(), toolTip = "Turns sky RGB"},
                new ButtonInfo { buttonText = "Fix Sky", method =() => Visual.FixSky(), toolTip = "Turns sky normal"},
                new ButtonInfo { buttonText = "Get Sky (idk?)", method =() => Visual.GetSky(), toolTip = "???", isTogglable = true},
            },

            new ButtonInfo[] { // Movement Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Change Fly Speed", method =() => Movement.ChangeFlySpeed(), toolTip = "Changes flight speed.", isTogglable = false},
                new ButtonInfo { buttonText = "Platforms (G)", method =() => Movement.Platforms(), toolTip = "Creates boxes under your hands when grips are used.", isTogglable = true},
                new ButtonInfo { buttonText = "Fly", method =() => Movement.Fly(), toolTip = "Enables the ability to fly. UND", isTogglable = true},
                new ButtonInfo { buttonText = "No Clip (T)", method =() => Movement.Noclip(), toolTip = "Disables colliders", isTogglable = true},
                new ButtonInfo { buttonText = "Speedboost", method =() => Movement.SpB(), toolTip = "Enables a slight speed boost. UND", isTogglable = true},
                new ButtonInfo { buttonText = "Mosa Speedboost", method =() => Movement.MosaSpB(), toolTip = "Enables a slight speed boost. SUPER UND", isTogglable = true},
                new ButtonInfo { buttonText = "TP to Stump (NW)", method =() => Movement.TpToStump(), toolTip = "Places you in stump", isTogglable = true},
                new ButtonInfo { buttonText = "CarMonke", method =() => Movement.Drive(), toolTip = "Enables a car monkey. UND", isTogglable = true},
            },

            new ButtonInfo[] { // Projectile Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Snowball Spam (G)", method =() => Projectile.SnowSpam(), toolTip = "Spams snowballs. UND", isTogglable = true},
                new ButtonInfo { buttonText = "Ice Spam (G)", method =() => Projectile.IceSpam(), toolTip = "Spams snowballs. UND", isTogglable = true},
                new ButtonInfo { buttonText = "Web Spam (G)", method =() => Projectile.SpiderSpam(), toolTip = "Spams snowballs. UND", isTogglable = true},
                new ButtonInfo { buttonText = "Grab Bug", method =() => Projectile.GrabBug(), toolTip = "Places bug in your hand. UND", isTogglable = true},
                new ButtonInfo { buttonText = "Grab Bat", method =() => Projectile.GrabBat(), toolTip = "Places bat in your hand. UND", isTogglable = true},
            },

            new ButtonInfo[] { // Overpowered Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Tag Gun", method =() => Overpowered.TagGunMod(), toolTip = "Tags specific players you choose. UND", isTogglable = true},
                new ButtonInfo { buttonText = "Tag All", method =() => Overpowered.TagAll(), toolTip = "Tags all players. UND", isTogglable = true},
                new ButtonInfo { buttonText = "Tag Aura (NW)", toolTip = "Tags people nearest. UND", isTogglable = false},
            },

            new ButtonInfo[] { // Master Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Master Check", method =() => Master.MasterCheck(), toolTip = "Checks if you are server master.", isTogglable = false},
            },

            new ButtonInfo[] { // Experimental Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "FPS Boost (Bugged)", method =() => Experimental.BetterFPSBoost(), disableMethod =() => Experimental.DisableBetterFPSBoost(), toolTip = "Increases FPS by lowering quality by 99%.", isTogglable = true},
            },
        };
    }
}
