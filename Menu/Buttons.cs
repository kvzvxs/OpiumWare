using kennMenu.Classes;
using kennMenu.Mods;
using kennMenu.Mods.Spammers;
using kennMenu.Notifications;
using UnityEngine;
using static kennMenu.Menu.Main;
using static kennMenu.Settings;

namespace kennMenu.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods
                new ButtonInfo { buttonText = "Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "Join Discord", method =() => Important.JoinDiscord(), isTogglable = false, toolTip = "Opens web to discord on PC."},
                new ButtonInfo { buttonText = "Panic", method =() => SettingsMods.Panic(), isTogglable = false, toolTip = "Disables all mods."},
                new ButtonInfo { buttonText = "Menu", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Safety", method =() => SettingsMods.SafetySettings(), isTogglable = false, toolTip = "Opens the safety settings for the menu."},
                new ButtonInfo { buttonText = "Player", method =() => SettingsMods.PlayerSettings(), isTogglable = false, toolTip = "Opens the player settings for the menu."},
                new ButtonInfo { buttonText = "Visual", method =() => SettingsMods.VisualSettings(), isTogglable = false, toolTip = "Opens the visual settings for the menu."},
                new ButtonInfo { buttonText = "Movement", method =() => SettingsMods.MovementSettings(), isTogglable = false, toolTip = "Opens the movement settings for the menu."},
                new ButtonInfo { buttonText = "Projectile <color=grey>[</color><color=red>NW</color><color=grey>]</color>", method =() => SettingsMods.ProjectileSettings(), isTogglable = false, toolTip = "Opens the projectile settings for the menu."},
                new ButtonInfo { buttonText = "Overpowered", method =() => SettingsMods.OverpoweredSettings(), isTogglable = false, toolTip = "Opens the overpowered settings for the menu."},
                new ButtonInfo { buttonText = "Master", method =() => SettingsMods.MasterSettings(), isTogglable = false, toolTip = "Opens the master settings for the menu."},
                new ButtonInfo { buttonText = "Experimental", method =() => SettingsMods.ExperimentalSettings(), isTogglable = false, toolTip = "Opens the experimental settings for the menu."},
            },

            new ButtonInfo[] { // Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Quit Game", method =() => Application.Quit(), toolTip = "Quits game.", isTogglable = false},
                new ButtonInfo { buttonText = "Disconnect", method =() => Important.Disconnect(), toolTip = "Disconnects you from current room.", isTogglable = false},
                new ButtonInfo { buttonText = "Reconnect", method =() => Important.Reconnect(), toolTip = "Reconnects you to room.", isTogglable = false},
                new ButtonInfo { buttonText = "Join Random", method =() => Important.JoinRandom(), toolTip = "Connects you to a random public.", isTogglable = false},
                new ButtonInfo { buttonText = "Join Random Ghost Code", method =() => Important.JoinGhostCode(), toolTip = "Connects you to a random ghost code.", isTogglable = false},
                new ButtonInfo { buttonText = "Disable Network Triggers", enableMethod =() => Important.DisableNT(), disableMethod =() => Important.EnableNT(), toolTip = "Disables room triggers.", isTogglable = true},
                new ButtonInfo { buttonText = "Disable Map Triggers", enableMethod =() => Important.DisableMT(), disableMethod =() => Important.EnableMT(), toolTip = "Disables map room triggers. UND", isTogglable = true},
                new ButtonInfo { buttonText = "First Person Camera", enableMethod =() => Important.EnableFPC(), method =() => Important.MoveFPC(), disableMethod =() => Important.DisableFPC(), toolTip = "Makes your camera output what you see in VR."},
                new ButtonInfo { buttonText = "Uncap FPS <color=grey>[</color><color=yellow>Unknown</color><color=grey>]</color>", method =() => Important.UncapFPS(), toolTip = "Unlocks full fps potential.", isTogglable = false},
                new ButtonInfo { buttonText = "Unlock Competitive Queue", method =() => Important.UnlockCompetitiveQueue(), toolTip = "Unlocks comp queue.", isTogglable = false},
                new ButtonInfo { buttonText = "Accept TOS", method =() => Important.AcceptTOS(), disableMethod =() => Important.DisableAcceptTOS(), toolTip = "Accepts the Terms of Service for you."},
            },

            new ButtonInfo[] { // Menu Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Both Hands <color=grey>[</color><color=red>NW</color><color=grey>]</color>", enableMethod =() => SettingsMods.BothHandsOn(), disableMethod =() => SettingsMods.BothHandsOff(), toolTip = "Puts the menu on both of your hands."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => SettingsMods.EnableFPSCounter(), disableMethod =() => SettingsMods.DisableFPSCounter(), enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
                new ButtonInfo { buttonText = "Clear Notifications", method =() => NotifiLib.ClearAllNotifications(), isTogglable = false, toolTip = "Clears your notifications. Good for when they get stuck."},
               // new ButtonInfo { buttonText = "Disable Ghostview", enableMethod =() => SettingsMods.DisableGhostview(), disableMethod =() => SettingsMods.EnableGhostview(), toolTip = "Disables the transparent rig when you're in ghost."},
               // new ButtonInfo { buttonText = "Legacy Ghostview", enableMethod =() => SettingsMods.LegacyGhostview(), disableMethod =() => SettingsMods.NewGhostview(), toolTip = "Reverts the transparent rig to the two balls when you're in ghost."},
            },

            new ButtonInfo[] { // Safety Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "AntiReport <color=grey>[</color><color=yellow>Untested</color><color=grey>]</color>", method =() => Safety.AntiReportD(), toolTip = "Kicks you when someone is trying to report you. UND", isTogglable = true},
                new ButtonInfo { buttonText = "AntiReport <color=grey>[</color><color=yellow>Untested</color><color=grey>]</color>", method =() => Safety.AntiReportR(), toolTip = "Kicks and reconnects you when someone is trying to report you. UND", isTogglable = true},
                new ButtonInfo { buttonText = "AntiReport <color=grey>[</color><color=yellow>Untested</color><color=grey>]</color>", method =() => Safety.AntiReportN(), toolTip = "Notifies you when someone is trying to report you. UND", isTogglable = true},
                new ButtonInfo { buttonText = "No Finger Movement", method =() => Safety.NoFingers(), toolTip = "Disables your finger movements. UND", isTogglable = true},
            },

            new ButtonInfo[] { // Player Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Ghost <color=grey>[</color><color=green>T</color><color=grey>]</color>", method =() => Player.Ghost(), toolTip = "Makes you a ghost.", isTogglable = true},
                new ButtonInfo { buttonText = "Invisible <color=grey>[</color><color=green>T</color><color=grey>]</color>", method =() => Player.Invis(), toolTip = "Turns you invisible.", isTogglable = true},
                new ButtonInfo { buttonText = "Backwards Head", method =() => Player.BackwardHead(), disableMethod =() => Player.NormalHead(), toolTip = "Self-explainitory.", isTogglable = true},
                new ButtonInfo { buttonText = "Grab Rig <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Player.GrabRig(), toolTip = "Places your rig in your hand with grips are used.", isTogglable = true},
                new ButtonInfo { buttonText = "Rig Gun", method =() => Player.RigGunMod(), toolTip = "Places your rig wherever you shoot it.", isTogglable = true},
                new ButtonInfo { buttonText = "Teleport Gun", method =() => Player.TPGun(), toolTip = "TPs you wherever you shoot.", isTogglable = true},
                new ButtonInfo { buttonText = "Steam Long Arms", method =() => Player.EnableSteamLongArms(), disableMethod =() => Player.DisableSteamLongArms(), toolTip = "Gives you long arms similar to override world scale."},
                new ButtonInfo { buttonText = "Stick Long Arms", method =() => Player.StickLongArms(), toolTip = "Makes you look like you're using sticks."},
                new ButtonInfo { buttonText = "Multiplied Long Arms", method =() => Player.MultipliedLongArms(), toolTip = "Gives you a weird version of long arms."},
                new ButtonInfo { buttonText = "Vertical Long Arms", method =() => Player.VerticalLongArms(), toolTip = "Gives you a version of long arms to help you vertically."},
                new ButtonInfo { buttonText = "Horizontal Long Arms", method =() => Player.HorizontalLongArms(), toolTip = "Gives you a version of long arms to help you horizontally."},
                new ButtonInfo { buttonText = "Loud Hand Taps", method =() => Player.LoudHandTaps(), disableMethod =() => Player.FixHandTaps(), toolTip = "Increases your hand tap sounds.", isTogglable = true},
                new ButtonInfo { buttonText = "Silent Hand Taps", method =() => Player.SilentHandTaps(), disableMethod =() => Player.FixHandTaps(), toolTip = "Lowers your hand tap sounds.", isTogglable = true},
                new ButtonInfo { buttonText = "Slippery Hands", enableMethod =() => Player.EnableSlipperyHands(), disableMethod =() => Player.DisableSlipperyHands(), toolTip = "Makes everything ice, as in extremely slippery."},
                new ButtonInfo { buttonText = "Grippy Hands", enableMethod =() => Player.EnableGrippyHands(), disableMethod =() => Player.DisableGrippyHands(), toolTip = "Covers your hands in grip tape, letting you wallrun as high as you want."},
                new ButtonInfo { buttonText = "Sticky Hands", method =() => Player.StickyHands(), disableMethod =() => Player.DisableStickyHands(), toolTip = "Makes your hands really sticky."},
                new ButtonInfo { buttonText = "Climby Hands <color=grey>[</color><color=yellow>Unknown</color><color=grey>]</color>", method =() => Player.ClimbyHands(), disableMethod =() => Player.DisableClimbyHands(), toolTip = "Lets you climb everything like a rope."},
                new ButtonInfo { buttonText = "Strobe Color", method =() => Player.StrobeColor(), toolTip = "Makes your character flash." },
                new ButtonInfo { buttonText = "Rainbow Color", method =() => Player.RainbowColor(), toolTip = "Makes your character rainbow." },
            },

            new ButtonInfo[] { // Visual Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Morning Time", method =() => Visual.MorningTime(), toolTip = "Makes time day."},
                new ButtonInfo { buttonText = "Day Time", method =() => Visual.DayTime(), toolTip = "Makes time day."},
                new ButtonInfo { buttonText = "Evening Time", method =() => Visual.EveningTime(), toolTip = "Makes time evening."},
                new ButtonInfo { buttonText = "Night Time", method =() => Visual.NightTime(), toolTip = "Makes time night."},
                new ButtonInfo { buttonText = "Fullbright", enableMethod =() => Visual.Fullbright(), disableMethod =() => Visual.Fullshade(), toolTip = "Makes everything bright."},
                new ButtonInfo { buttonText = "Rainy Weather", method =() => Visual.Rain(), toolTip = "Forces the weather to rain."},
                new ButtonInfo { buttonText = "Clear Weather", method =() => Visual.NoRain(), toolTip = "Forces the weather to sunny skies all day."},
                new ButtonInfo { buttonText = "Remove Leaves", enableMethod =() => Visual.EnableRemoveLeaves(), disableMethod =() => Visual.DisableRemoveLeaves(), toolTip = "Removes leaves on trees, good for branching."},
                new ButtonInfo { buttonText = "Tracers", method =() => Visual.Tracers(), toolTip = "Lines out of right hand showing players location", isTogglable = true},
                new ButtonInfo { buttonText = "BoxESP", method =() => Visual.BoxESP(), toolTip = "Boxes showing players location", isTogglable = true},
                new ButtonInfo { buttonText = "RGB Sky", method =() => Visual.RGBSky(), disableMethod =() => Visual.FixSky(), toolTip = "Turns sky RGB"},
            },

            new ButtonInfo[] { // Movement Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Change Fly Speed", method =() => Movement.ChangeFlySpeed(), toolTip = "Changes flight speed.", isTogglable = false},
                new ButtonInfo { buttonText = "Platforms <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Movement.Platforms(), toolTip = "Creates boxes under your hands when grips are used.", isTogglable = true},
                new ButtonInfo { buttonText = "Fly <color=grey>[</color><color=green>A</color><color=grey>]</color>", method =() => Movement.Fly(), toolTip = "Sends your character forwards when holding <color=green>A</color>."},
                new ButtonInfo { buttonText = "Trigger Fly <color=grey>[</color><color=green>T</color><color=grey>]</color>", method =() => Movement.TriggerFly(), toolTip = "Sends your character forwards when holding <color=green>trigger</color>."},
                new ButtonInfo { buttonText = "Noclip Fly <color=grey>[</color><color=green>A</color><color=grey>]</color>", method =() => Movement.NoclipFly(), toolTip = "Sends your character forwards and makes you go through objects when holding <color=green>A</color>."},
                new ButtonInfo { buttonText = "Slingshot Fly <color=grey>[</color><color=green>A</color><color=grey>]</color>", method =() => Movement.SlingshotFly(), toolTip = "Sends your character forwards, in a more elastic manner, when holding <color=green>A</color>."},
                new ButtonInfo { buttonText = "WASD Fly", method =() => Movement.WASDFly(), toolTip = "Enables the ability to fly with keyboard. UND", isTogglable = true},
                new ButtonInfo { buttonText = "No Clip <color=grey>[</color><color=green>T</color><color=grey>]</color>", method =() => Movement.Noclip(), toolTip = "Disables colliders", isTogglable = true},
                new ButtonInfo { buttonText = "Speed Boost", method =() => Movement.Speedboost(), toolTip = "Changes your speed to whatever you set it to."},
                new ButtonInfo { buttonText = "Grip Speed Boost <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Movement.GripSpeedboost(), toolTip = "Changes your speed to whatever you set it to when holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Trigger Speed Boost <color=grey>[</color><color=green>J</color><color=grey>]</color>", method =() => Movement.TriggerSpeedboost(), toolTip = "Changes your speed to whatever you set it to when holding <color=green>trigger</color>."},
                new ButtonInfo { buttonText = "TP 2 Stump <color=grey>[</color><color=green>A</color><color=grey>]</color>", method =() => Movement.TpToStump(), toolTip = "Places you in stump", isTogglable = true},
                new ButtonInfo { buttonText = "Up And Down <color=grey>[</color><color=green>A</color><color=grey>]</color>", method =() => Movement.UpAndDown(), toolTip = "Makes you go up when holding your <color=green>trigger</color>, and down when holding your <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Left And Right <color=grey>[</color><color=green>A</color><color=grey>]</color>", method =() => Movement.LeftAndRight(), toolTip = "Makes you go left when holding your <color=green>trigger</color>, and right when holding your <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Forwards And Backwards <color=grey>[</color><color=green>A</color><color=grey>]</color>", method =() => Movement.ForwardsAndBackwards(), toolTip = "Makes you go forwards when holding your <color=green>trigger</color>, and backwards when holding your <color=green>grip</color>."},
                new ButtonInfo { buttonText = "IronMonke <color=grey>[</color><color=green>A</color><color=grey>]</color>", method =() => Movement.IronMan(), toolTip = "Enables ironman thrusters.", isTogglable = true},
                new ButtonInfo { buttonText = "SpiderMonke <color=grey>[</color><color=green>G</color><color=grey>]</color> <color=grey>[</color><color=red>NW</color><color=grey>]</color>", method =() => Movement.SpiderMan(), disableMethod =() => Movement.DisableSpiderMan(), toolTip = "Turns you into spider man, use your <color=green>grips</color> to shoot webs."},
                new ButtonInfo { buttonText = "Uncap Max Velocity", method =() => Movement.UncapMaxVelocity(), toolTip = "Lets you go as fast as you want without hitting the velocity limit."},
                new ButtonInfo { buttonText = "Always Max Velocity <color=grey>[</color><color=yellow>Unknown</color><color=grey>]</color>", method =() => Movement.AlwaysMaxVelocity(), toolTip = "Always makes you go as fast as the velocity limit."},
                new ButtonInfo { buttonText = "Force Tag Freeze", method =() => Movement.ForceTagFreeze(), disableMethod =() => Movement.NoTagFreeze(), toolTip = "Forces tag freeze on your character."},
                new ButtonInfo { buttonText = "No Tag Freeze", method =() => Movement.NoTagFreeze(), toolTip = "Disables tag freeze on your character."},
                new ButtonInfo { buttonText = "Low Gravity", method =() => Movement.LowGravity(), toolTip = "Makes gravity lower on your character."},
                new ButtonInfo { buttonText = "Zero Gravity", method =() => Movement.ZeroGravity(), toolTip = "Disables gravity on your character."},
                new ButtonInfo { buttonText = "High Gravity", method =() => Movement.HighGravity(), toolTip = "Makes gravity higher on your character."},
            },

            new ButtonInfo[] { // Projectile Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Snowball Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.SBSpam(), toolTip = "Spams your snowballs when holding <color=green>grip</color>." },
                new ButtonInfo { buttonText = "Water Balloon Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.WBSpam(), toolTip = "Spams your water balloons when holding <color=green>grip</color>." },
                new ButtonInfo { buttonText = "Ice Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.IceSpam(), toolTip = "Spams your ice when holding <color=green>grip</color>." },
                new ButtonInfo { buttonText = "Slingshot Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.SlingshotSpam(), toolTip = "Spams your slingshot when holding <color=green>grip</color>." },
                new ButtonInfo { buttonText = "Deadshot Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.DeadshotSpam(), toolTip = "Spams your deadshot when holding <color=green>grip</color>." },
                new ButtonInfo { buttonText = "Cloud Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.CloudSpam(), toolTip = "Spams your cloud when holding <color=green>grip</color>." },
                new ButtonInfo { buttonText = "Cupid Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.CupidSpam(), toolTip = "Spams your cupid when holding <color=green>grip</color>." },
                new ButtonInfo { buttonText = "Elf Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.ElfSpam(), toolTip = "Spams your elf when holding <color=green>grip</color>." },
                new ButtonInfo { buttonText = "Rock Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.RockSpam(), toolTip = "Spams your rock when holding <color=green>grip</color>." },
                new ButtonInfo { buttonText = "Pepper Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.PepperSpam(), toolTip = "Spams your pepper when holding <color=green>grip</color>." },
                new ButtonInfo { buttonText = "Spider Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.SpiderSpam(), toolTip = "Spams your spider when holding <color=green>grip</color>." },
                new ButtonInfo { buttonText = "Square Gift Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.SquareSpam(), toolTip = "Spams your square gifts when holding <color=green>grip</color>." },
                new ButtonInfo { buttonText = "Round Gift Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.RoundSpam(), toolTip = "Spams your round gift when holding <color=green>grip</color>." },
                new ButtonInfo { buttonText = "Roll Gift Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.RollSpam(), toolTip = "Spams your roll gift when holding <color=green>grip</color>." },
                new ButtonInfo { buttonText = "Candy Cane Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.CCSpam(), toolTip = "Spams your candy canes when holding <color=green>grip</color>." },
                new ButtonInfo { buttonText = "Coal Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.CoalSpam(), toolTip = "Spams your coal when holding <color=green>grip</color>." },
                // new ButtonInfo { buttonText = "Grab Bug", method =() => Projectile.GrabBug(), toolTip = "Places bug in your hand.", isTogglable = true},
                // new ButtonInfo { buttonText = "Grab Bat", method =() => Projectile.GrabBat(), toolTip = "Places bat in your hand.", isTogglable = true},
            },

            new ButtonInfo[] { // Overpowered Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Tag Self", method =() => Overpowered.TagSelf(), toolTip = "Tags self.", isTogglable = true},
                new ButtonInfo { buttonText = "Tag Gun", method =() => Overpowered.TagGunMod(), toolTip = "Tags specific players you choose. UND", isTogglable = true},
                new ButtonInfo { buttonText = "Tag All", method =() => Overpowered.TagAll(), toolTip = "Tags all players. UND", isTogglable = true},
                new ButtonInfo { buttonText = "Tag Aura", method =() => Overpowered.TagAura(), toolTip = "Tags all players in your range. UND", isTogglable = true},
            },

            new ButtonInfo[] { // Master Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Master Check", method =() => Master.MasterCheck(), toolTip = "Checks if you are server master.", isTogglable = false},
                new ButtonInfo { buttonText = "Tag Lag <color=grey>[</color><color=yellow>Untested</color><color=grey>]</color>", enableMethod =() => Master.TagLag(), disableMethod =() => Master.NahTagLag(), toolTip = "Forces tag lag in the lobby, letting no one get tagged."},
                new ButtonInfo { buttonText = "Spam Tag Self <color=grey>[</color><color=yellow>Untested</color><color=grey>]</color>", method =() => Master.SpamTagSelf(), toolTip = "Adds and removes you from the list of tagged players."},
                new ButtonInfo { buttonText = "Spam Tag All <color=grey>[</color><color=yellow>Untested</color><color=grey>]</color>", method =() => Master.SpamTagAll(), toolTip = "Adds and removes everyone from the list of tagged players."},
                new ButtonInfo { buttonText = "Infection to Tag <color=grey>[</color><color=yellow>Untested</color><color=grey>]</color>", method =() => Master.InfectionToTag(), isTogglable = false, toolTip = "Turns the game into tag instead of infection." },
                new ButtonInfo { buttonText = "Tag to Infection <color=grey>[</color><color=yellow>Untested</color><color=grey>]</color>", method =() => Master.TagToInfection(), isTogglable = false, toolTip = "Turns the game into infection instead of tag." },
            },

            new ButtonInfo[] { // Experimental Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "FPS Boost", method =() => Experimental.EnableFPSBoost(), disableMethod =() => Experimental.DisableFPSBoost(), toolTip = "Increases FPS by lowering quality by 99%.", isTogglable = true},
                new ButtonInfo { buttonText = "Max Badge Score SS", method =() => Experimental.SetMaxLevel(), toolTip = "Sets your badge score to max.", isTogglable = false},
                new ButtonInfo { buttonText = "Draw <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Experimental.Draw(), toolTip = "Allows you to draw with your fingers while holding <color=green>grip</color>.."},
            },
        };
    }
}
