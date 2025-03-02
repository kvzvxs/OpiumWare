using OpiumWare.Classes;
using OpiumWare.Mods;
using OpiumWare.Mods.Spammers;
using OpiumWare.Notifications;
using UnityEngine;
using static OpiumWare.Menu.Main;
using static OpiumWare.Settings;

namespace OpiumWare.Menu
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
                new ButtonInfo { buttonText = "Projectile", method =() => SettingsMods.ProjectileSettings(), isTogglable = false, toolTip = "Opens the projectile settings for the menu."},
                new ButtonInfo { buttonText = "Overpowered", method =() => SettingsMods.OverpoweredSettings(), isTogglable = false, toolTip = "Opens the overpowered settings for the menu."},
                new ButtonInfo { buttonText = "Master", method =() => SettingsMods.MasterSettings(), isTogglable = false, toolTip = "Opens the master settings for the menu."},
                new ButtonInfo { buttonText = "Experimental", method =() => SettingsMods.ExperimentalSettings(), isTogglable = false, toolTip = "Opens the experimental settings for the menu."},
            },

            new ButtonInfo[] { // Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Quit Gorilla Tag", method =() => Application.Quit(), toolTip = "Exits Gorilla Tag", isTogglable = false},
                new ButtonInfo { buttonText = "Restart Gorilla Tag", method =() => Important.RestartGame(), isTogglable = false, toolTip = "Restarts Gorilla Tag."},
                new ButtonInfo { buttonText = "Clear Notifications", method =() => NotifiLib.ClearAllNotifications(), isTogglable = false, toolTip = "Clears your notifications. Good for when they get stuck."},
                new ButtonInfo { buttonText = "Disconnect", method =() => Important.Disconnect(), toolTip = "Disconnects you from current room.", isTogglable = false},
                new ButtonInfo { buttonText = "Reconnect", method =() => Important.Reconnect(), toolTip = "Reconnects you to room.", isTogglable = false},
                new ButtonInfo { buttonText = "Join Random", method =() => Important.JoinRandom(), toolTip = "Connects you to a random public.", isTogglable = false},
                new ButtonInfo { buttonText = "Join Random Ghost Code", method =() => Important.JoinGhostCode(), toolTip = "Connects you to a random ghost code.", isTogglable = false},
                new ButtonInfo { buttonText = "Join Menu Room", method =() => Important.OpiumWareRoom(), isTogglable = false, toolTip = "Connects you to a room that is exclusive to <b>OpiumWare</b> users." },
                new ButtonInfo { buttonText = "PC Button Click", method =() => Important.PCButtonClick(), toolTip = "Lets you click in-game buttons with your mouse."},
                new ButtonInfo { buttonText = "Disable Network Triggers", enableMethod =() => Important.DisableNT(), disableMethod =() => Important.EnableNT(), toolTip = "Disables room triggers.", isTogglable = true},
                new ButtonInfo { buttonText = "Disable Map Triggers", enableMethod =() => Important.DisableMT(), disableMethod =() => Important.EnableMT(), toolTip = "Disables map room triggers. UND", isTogglable = true},
                new ButtonInfo { buttonText = "First Person Camera <color=grey>[</color><color=red>NW</color><color=grey>]</color>", enableMethod =() => Important.EnableFPC(), method =() => Important.MoveFPC(), disableMethod =() => Important.DisableFPC(), toolTip = "Makes your camera output what you see in VR."},
                new ButtonInfo { buttonText = "Uncap FPS <color=grey>[</color><color=yellow>Unknown</color><color=grey>]</color>", method =() => Important.UncapFPS(), toolTip = "Unlocks full fps potential.", isTogglable = false},
                new ButtonInfo { buttonText = "60 FPS", method =() => Important.ForceLagGame(), toolTip = "Caps your FPS at 60 frames per second."},
                new ButtonInfo { buttonText = "Unlock Competitive Queue", method =() => Important.UnlockCompetitiveQueue(), toolTip = "Unlocks comp queue.", isTogglable = false},
                new ButtonInfo { buttonText = "Accept TOS", method =() => Important.AcceptTOS(), disableMethod =() => Important.DisableAcceptTOS(), toolTip = "Accepts the Terms of Service for you."},
                new ButtonInfo { buttonText = "Tag Lag Detector", method =() => Important.TagLagDetector(), toolTip = "Detects when the master client is not currently allowing tag requests."},
            },

            new ButtonInfo[] { // Menu Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Disable Notifications", enableMethod =() => SettingsMods.DisableNotifications(), disableMethod =() => SettingsMods.EnableNotifications(), toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "Disable FPS Counter", enableMethod =() => SettingsMods.DisableFPSCounter(), disableMethod =() => SettingsMods.EnableFPSCounter(), toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disable Disconnect Button", enableMethod =() => SettingsMods.DisableDisconnectButton(), disableMethod =() => SettingsMods.EnableDisconnectButton(), toolTip = "Toggles the disconnect button."},
            },

            new ButtonInfo[] { // Safety Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "AntiReport <color=grey>[</color><color=green>Disconnect</color><color=grey>]</color> <color=grey>[</color><color=red>NW</color><color=grey>]</color>", method =() => Safety.AntiReportD(), toolTip = "Kicks you when someone is trying to report you. UND", isTogglable = true},
                new ButtonInfo { buttonText = "AntiReport <color=grey>[</color><color=green>Reconnect</color><color=grey>]</color> <color=grey>[</color><color=red>NW</color><color=grey>]</color>", method =() => Safety.AntiReportR(), toolTip = "Kicks and reconnects you when someone is trying to report you. UND", isTogglable = true},
                new ButtonInfo { buttonText = "AntiReport <color=grey>[</color><color=green>Notify</color><color=grey>]</color> <color=grey>[</color><color=red>NW</color><color=grey>]</color>", method =() => Safety.AntiReportN(), toolTip = "Notifies you when someone is trying to report you. UND", isTogglable = true},
                new ButtonInfo { buttonText = "No Finger Movement", method =() => Safety.NoFingers(), toolTip = "Disables your finger movements. UND", isTogglable = true},
            },

            new ButtonInfo[] { // Player Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Ghost <color=grey>[</color><color=green>A</color><color=grey>]</color>", method =() => Player.Ghost(), toolTip = "Keeps your rig still when holding <color=green>A</color>."},
                new ButtonInfo { buttonText = "Invisible <color=grey>[</color><color=green>B</color><color=grey>]</color>", method =() => Player.Invis(), toolTip = "Makes you go invisible when holding <color=green>B</color>."},
                new ButtonInfo { buttonText = "Upside Down Head", method =() => Player.UpsideDownHead(), disableMethod =() => Player.FixHead(), toolTip = "Flips your head upside down on the Z axis."},
                new ButtonInfo { buttonText = "Backwards Head", method =() => Player.BackwardsHead(), disableMethod =() => Player.FixHead(), toolTip = "Rotates your head 180 degrees on the Y axis."},
                new ButtonInfo { buttonText = "Broken Neck", method =() => Player.BrokenNeck(), disableMethod =() => Player.FixHead(), toolTip = "Rotates your head 90 degrees on the Z axis."},
                new ButtonInfo { buttonText = "Spin Head X", method =() => Player.SpinHeadX(), disableMethod =() => Player.FixHead(), toolTip = "Spins your head on the X axis."},
                new ButtonInfo { buttonText = "Spin Head Y", method =() => Player.SpinHeadY(), disableMethod =() => Player.FixHead(), toolTip = "Spins your head on the Y axis."},
                new ButtonInfo { buttonText = "Spin Head Z", method =() => Player.SpinHeadZ(), disableMethod =() => Player.FixHead(), toolTip = "Spins your head on the Z axis."},
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
                new ButtonInfo { buttonText = "Climby Hands <color=grey>[</color><color=red>NW</color><color=grey>]</color>", method =() => Player.ClimbyHands(), disableMethod =() => Player.DisableClimbyHands(), toolTip = "Lets you climb everything like a rope."},
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
                new ButtonInfo { buttonText = "Name Tags <color=grey>[</color><color=red>NW</color><color=grey>]</color>", method =() => Visual.NameTags(), disableMethod =() => Visual.DisableNameTags(), toolTip = "Gives players name tags above their heads."},
            },

            new ButtonInfo[] { // Movement Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Change Fly Speed", method =() => Movement.ChangeFlySpeed(), toolTip = "Changes flight speed.", isTogglable = false},
                new ButtonInfo { buttonText = "Platforms <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Movement.Platforms(), toolTip = "Creates boxes under your hands when grips are used.", isTogglable = true},
                new ButtonInfo { buttonText = "Fly <color=grey>[</color><color=green>A</color><color=grey>]</color>", method =() => Movement.Fly(), toolTip = "Sends your character forwards when holding <color=green>A</color>."},
                new ButtonInfo { buttonText = "Trigger Fly <color=grey>[</color><color=green>T</color><color=grey>]</color> <color=grey>[</color><color=red>NW</color><color=grey>]</color>", method =() => Movement.TriggerFly(), toolTip = "Sends your character forwards when holding <color=green>trigger</color>."},
                new ButtonInfo { buttonText = "Noclip Fly <color=grey>[</color><color=green>A</color><color=grey>]</color>", method =() => Movement.NoclipFly(), toolTip = "Sends your character forwards and makes you go through objects when holding <color=green>A</color>."},
                new ButtonInfo { buttonText = "Slingshot Fly <color=grey>[</color><color=green>A</color><color=grey>]</color>", method =() => Movement.SlingshotFly(), toolTip = "Sends your character forwards, in a more elastic manner, when holding <color=green>A</color>."},
                new ButtonInfo { buttonText = "WASD Fly", method =() => Movement.WASDFly(), toolTip = "Enables the ability to fly with keyboard.", isTogglable = true},
                new ButtonInfo { buttonText = "No Clip <color=grey>[</color><color=green>T</color><color=grey>]</color>", method =() => Movement.Noclip(), toolTip = "Disables colliders", isTogglable = true},
                new ButtonInfo { buttonText = "Speed Boost", method =() => Movement.Speedboost(), toolTip = "Changes your speed to whatever you set it to."},
                new ButtonInfo { buttonText = "Grip Speed Boost <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Movement.GripSpeedboost(), toolTip = "Changes your speed to whatever you set it to when holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "TP to Stump <color=grey>[</color><color=green>A</color><color=grey>]</color>", method =() => Movement.TpToStump(), toolTip = "Places you in stump", isTogglable = true},
                new ButtonInfo { buttonText = "Up And Down <color=grey>[</color><color=red>NW</color><color=grey>]</color>", method =() => Movement.UpAndDown(), toolTip = "Makes you go up when holding your <color=green>trigger</color>, and down when holding your <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Left And Right <color=grey>[</color><color=red>NW</color><color=grey>]</color>", method =() => Movement.LeftAndRight(), toolTip = "Makes you go left when holding your <color=green>trigger</color>, and right when holding your <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Forwards And Backwards <color=grey>[</color><color=red>NW</color><color=grey>]</color>", method =() => Movement.ForwardsAndBackwards(), toolTip = "Makes you go forwards when holding your <color=green>trigger</color>, and backwards when holding your <color=green>grip</color>."},
                new ButtonInfo { buttonText = "IronMonke <color=grey>[</color><color=green>A</color><color=grey>]</color>", method =() => Movement.IronMan(), toolTip = "Enables ironman thrusters.", isTogglable = true},
                new ButtonInfo { buttonText = "SpiderMonke <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Movement.SpiderMan(), disableMethod =() => Movement.DisableSpiderMan(), toolTip = "Turns you into spider man, use your <color=green>grips</color> to shoot webs."},
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
                new ButtonInfo { buttonText = "Snowball Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.SnowballGun(), toolTip = "Spams your selected projectile(s) when holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Water Balloon Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.WaterBalloonGun(), toolTip = "Spams your selected projectile(s) when holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Ice Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.IceGun(), toolTip = "Spams your selected projectile(s) when holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Slingshot Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.SlingshotGun(), toolTip = "Spams your selected projectile(s) when holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Deadshot Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.DeadshotGun(), toolTip = "Spams your selected projectile(s) when holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Cloud Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.CloudGun(), toolTip = "Spams your selected projectile(s) when holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Cupid Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.CupidGun(), toolTip = "Spams your selected projectile(s) when holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Elf Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.ElfGun(), toolTip = "Spams your selected projectile(s) when holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Rock Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.RockGun(), toolTip = "Spams your selected projectile(s) when holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Pepper Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.PepperGun(), toolTip = "Spams your selected projectile(s) when holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Spider Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.SpiderGun(), toolTip = "Spams your selected projectile(s) when holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Square Gift Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.SquareGun(), toolTip = "Spams your selected projectile(s) when holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Round Gift Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.RoundGun(), toolTip = "Spams your selected projectile(s) when holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Roll Gift Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.RollGun(), toolTip = "Spams your selected projectile(s) when holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Candy Cane Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.CandyCaneGun(), toolTip = "Spams your selected projectile(s) when holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Coal Spam <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Projectile.CoalGun(), toolTip = "Spams your selected projectile(s) when holding <color=green>grip</color>."},
            },

            new ButtonInfo[] { // Overpowered Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Tag Self", method =() => Overpowered.TagSelf(), toolTip = "Tags self.", isTogglable = true},
                new ButtonInfo { buttonText = "Tag Gun", method =() => Overpowered.TagGunMod(), toolTip = "Tags specific players you choose.", isTogglable = true},
                new ButtonInfo { buttonText = "Tag All", method =() => Overpowered.TagAll(), toolTip = "Tags all players.", isTogglable = true},
                new ButtonInfo { buttonText = "Tag Aura", method =() => Overpowered.TagAura(), toolTip = "Tags all players in your range.", isTogglable = true},
            },

            new ButtonInfo[] { // Master Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Master Check", method =() => Master.MasterCheck(), toolTip = "Checks if you are server master.", isTogglable = false},
                new ButtonInfo { buttonText = "Tag Lag", enableMethod =() => Master.TagLag(), disableMethod =() => Master.NahTagLag(), toolTip = "Forces tag lag in the lobby, letting no one get tagged."},
                new ButtonInfo { buttonText = "Spam Tag Self", method =() => Master.SpamTagSelf(), toolTip = "Adds and removes you from the list of tagged players."},
                new ButtonInfo { buttonText = "Spam Tag All", method =() => Master.SpamTagAll(), toolTip = "Adds and removes everyone from the list of tagged players."},
                new ButtonInfo { buttonText = "Infection to Tag", method =() => Master.InfectionToTag(), isTogglable = false, toolTip = "Turns the game into tag instead of infection." },
                new ButtonInfo { buttonText = "Tag to Infection", method =() => Master.TagToInfection(), isTogglable = false, toolTip = "Turns the game into infection instead of tag." },
                new ButtonInfo { buttonText = "Battle Start Game", method =() => Master.BattleStartGame(), isTogglable = false, toolTip = "Starts the game. Requires master." },
                new ButtonInfo { buttonText = "Battle End Game", method =() => Master.BattleEndGame(), isTogglable = false, toolTip = "Ends the game. Requires master." },
                new ButtonInfo { buttonText = "Battle Restart Game", method =() => Master.BattleRestartGame(), isTogglable = false, toolTip = "Restarts the game. Requires master." },
                new ButtonInfo { buttonText = "Battle Restart Spam", method =() => Master.BattleRestartGame(), toolTip = "Spam starts and ends the game. Requires master." },
                new ButtonInfo { buttonText = "Battle Balloon Spam Self", method =() => Master.BattleBalloonSpamSelf(), toolTip = "Spam pops and unpops your balloons. Requires master." },
                new ButtonInfo { buttonText = "Battle Balloon Spam All", method =() => Master.BattleBalloonSpam(), toolTip = "Spam pops and unpops everyone's balloons. Requires master." },
                new ButtonInfo { buttonText = "Battle Kill Self", method =() => Master.BattleKillSelf(), isTogglable = false, toolTip = "Kills yourself. Requires master." },
                new ButtonInfo { buttonText = "Battle Kill All", method =() => Master.BattleKillAll(), isTogglable = false, toolTip = "Kills everyone. Requires master." },
                new ButtonInfo { buttonText = "Battle Revive Self", method =() => Master.BattleReviveSelf(), isTogglable = false, toolTip = "Revives yourself. Requires master." },
                new ButtonInfo { buttonText = "Battle Revive All", method =() => Master.BattleReviveAll(), isTogglable = false, toolTip = "Revives everyone. Requires master." },
                new ButtonInfo { buttonText = "Battle God Mode", method =() => Master.BattleGodMode(), toolTip = "Gives you god mode in brawl. Requires master." },
            },

            new ButtonInfo[] { // Experimental Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "FPS Boost", method =() => Experimental.EnableFPSBoost(), disableMethod =() => Experimental.DisableFPSBoost(), toolTip = "Increases FPS by lowering quality by 99%.", isTogglable = true},
                new ButtonInfo { buttonText = "Max Badge Score SS", method =() => Experimental.SetMaxLevel(), toolTip = "Sets your badge score to max.", isTogglable = false},
                new ButtonInfo { buttonText = "Draw <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Experimental.Draw(), toolTip = "Allows you to draw with your fingers while holding <color=green>grip</color>.."},
                new ButtonInfo { buttonText = "Auto Clicker <color=grey>[</color><color=green>T</color><color=grey>]</color>", method =() => Experimental.AutoClicker(), toolTip = "Automatically presses trigger for you when holding <color=green>trigger</color>."},
                new ButtonInfo { buttonText = "Unlock All Cosmetics", method =() => Experimental.UnlockAll(), toolTip = "Unlocks all cosmetics", isTogglable = false},

            },
        };
    }
}
