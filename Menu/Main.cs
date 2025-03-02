using BepInEx;
using ExitGames.Client.Photon;
using g3;
using GorillaTagScripts;
using HarmonyLib;
using OpiumWare.Classes;
using OpiumWare.Notifications;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static OpiumWare.Menu.Buttons;
using static OpiumWare.Settings;
using static OpiumWare.Classes.RigManager;
using static UnityEngine.LightAnchor;
using System.Collections;
using OpiumWare.Mods;

namespace OpiumWare.Menu
{
    [HarmonyPatch(typeof(GorillaLocomotion.Player))]
    [HarmonyPatch("LateUpdate", MethodType.Normal)]
    public class Main : MonoBehaviour
    {
        // Constant
        public static void Prefix()
        {
            // Initialize Menu
            try
            {
                bool toOpen = (!rightHanded && ControllerInputPoller.instance.leftControllerSecondaryButton) || (rightHanded && ControllerInputPoller.instance.rightControllerSecondaryButton);
                bool keyboardOpen = UnityInput.Current.GetKey(keyboardButton);
                bool buttonCondition = ControllerInputPoller.instance.leftControllerSecondaryButton;

                if (bothHands)
                {
                    buttonCondition = ControllerInputPoller.instance.leftControllerSecondaryButton || ControllerInputPoller.instance.rightControllerSecondaryButton;
                    if (buttonCondition)
                    {
                        openedwithright = ControllerInputPoller.instance.rightControllerSecondaryButton;
                    }
                }


                if (menu == null)
                {
                    if (toOpen || keyboardOpen)
                    {
                        CreateMenu();
                        RecenterMenu(rightHanded, keyboardOpen);
                        if (reference == null)
                        {
                            CreateReference(rightHanded);
                        }
                    }
                }
                else
                {
                    if ((toOpen || keyboardOpen))
                    {
                        RecenterMenu(rightHanded, keyboardOpen);
                    }
                    else
                    {
                        Rigidbody comp = menu.AddComponent(typeof(Rigidbody)) as Rigidbody;
                        if (rightHanded)
                        {
                            comp.velocity = GorillaLocomotion.Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                        }
                        else
                        {
                            comp.velocity = GorillaLocomotion.Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                        }

                        UnityEngine.Object.Destroy(menu, 2);
                        menu = null;

                        UnityEngine.Object.Destroy(reference);
                        reference = null;
                    }
                }
            }
            catch (Exception exc)
            {
                UnityEngine.Debug.LogError(string.Format("{0} // Error initializing at {1}: {2}", PluginInfo.Name, exc.StackTrace, exc.Message));
            }

            // Constant
            try
            {
                // Pre-Execution
                if (fpsObject != null)
                {
                    fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();
                }

                // Execute Enabled mods
                foreach (ButtonInfo[] buttonlist in buttons)
                {
                    foreach (ButtonInfo v in buttonlist)
                    {
                        if (v.enabled)
                        {
                            if (v.method != null)
                            {
                                try
                                {
                                    v.method.Invoke();
                                }
                                catch (Exception exc)
                                {
                                    UnityEngine.Debug.LogError(string.Format("{0} // Error with mod {1} at {2}: {3}", PluginInfo.Name, v.buttonText, exc.StackTrace, exc.Message));
                                }
                            }
                        }
                    }
                }
            } catch (Exception exc)
            {
                UnityEngine.Debug.LogError(string.Format("{0} // Error with executing mods at {1}: {2}", PluginInfo.Name, exc.StackTrace, exc.Message));
            }
        }
        

        // Functions
        public static void CreateMenu()
        {
            // Menu Holder
            menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
            UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
            menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.3825f);

            // Menu Background
            menuBackground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(menuBackground.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(menuBackground.GetComponent<BoxCollider>());
            menuBackground.transform.parent = menu.transform;
            menuBackground.transform.rotation = Quaternion.identity;
            menuBackground.transform.localScale = menuSize;
            menuBackground.GetComponent<Renderer>().material.color = backgroundColor.colors[0].color;
            menuBackground.transform.position = new Vector3(0.05f, 0f, 0f);

            ColorChanger colorChanger = menuBackground.AddComponent<ColorChanger>();
            colorChanger.colorInfo = backgroundColor;
            colorChanger.Start();

            // Canvas
            canvasObject = new GameObject();
            canvasObject.transform.parent = menu.transform;
            Canvas canvas = canvasObject.AddComponent<Canvas>();
            CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
            canvasObject.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvasScaler.dynamicPixelsPerUnit = 1000f;

            // Title and FPS
            Text text = new GameObject
            {
                transform =
                    {
                        parent = canvasObject.transform
                    }
            }.AddComponent<Text>();
            text.font = currentFont;
            text.text = PluginInfo.Name + " <color=grey>[</color><color=white>" + (pageNumber + 1).ToString() + "</color><color=grey>]</color>";
            text.fontSize = 1;
            text.color = textColors[0];
            text.supportRichText = true;
            text.fontStyle = FontStyle.Italic;
            text.alignment = TextAnchor.MiddleCenter;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.18f, 0.03f);
            component.position = new Vector3(0.06f, 0f, 0.160f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

            if (fpsCounter)
            {
                fpsObject = new GameObject
                {
                    transform =
                    {
                        parent = canvasObject.transform
                    }
                }.AddComponent<Text>();
                fpsObject.font = currentFont;
                fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();
                fpsObject.color = textColors[0];
                fpsObject.fontSize = 1;
                fpsObject.supportRichText = true;
                fpsObject.fontStyle = FontStyle.Italic;
                fpsObject.alignment = TextAnchor.MiddleCenter;
                fpsObject.horizontalOverflow = UnityEngine.HorizontalWrapMode.Overflow;
                fpsObject.resizeTextForBestFit = true;
                fpsObject.resizeTextMinSize = 0;
                RectTransform component2 = fpsObject.GetComponent<RectTransform>();
                component2.localPosition = Vector3.zero;
                component2.sizeDelta = new Vector2(0.16f, 0.02f);
                component2.position = new Vector3(0.06f, 0f, 0.138f);
                component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }

            // Buttons
            // Disconnect
            if (disconnectButton)
            {
                GameObject disconnectbutton = GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (!UnityInput.Current.GetKey(KeyCode.Q))
                {
                    disconnectbutton.layer = 2;
                }
                UnityEngine.Object.Destroy(disconnectbutton.GetComponent<Rigidbody>());
                disconnectbutton.GetComponent<BoxCollider>().isTrigger = true;
                disconnectbutton.transform.parent = menu.transform;
                disconnectbutton.transform.rotation = Quaternion.identity;
                disconnectbutton.transform.localScale = new Vector3(0.07f, 0.8f, 0.07f);
                disconnectbutton.transform.localPosition = new Vector3(0.56f, 0f, 0.5f);
                disconnectbutton.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
                disconnectbutton.AddComponent<Classes.Button>().relatedText = "Disconnect";

                colorChanger = disconnectbutton.AddComponent<ColorChanger>();
                colorChanger.colorInfo = buttonColors[0];
                colorChanger.Start();

                Text discontext = new GameObject
                {
                    transform =
                            {
                                parent = canvasObject.transform
                            }
                }.AddComponent<Text>();
                discontext.text = "Disconnect";
                discontext.font = currentFont;
                discontext.fontSize = 1;
                discontext.color = textColors[0];
                discontext.alignment = TextAnchor.MiddleCenter;
                discontext.resizeTextForBestFit = true;
                discontext.resizeTextMinSize = 0;

                RectTransform rectt = discontext.GetComponent<RectTransform>();
                rectt.localPosition = Vector3.zero;
                rectt.sizeDelta = new Vector2(0.2f, 0.02f);
                rectt.localPosition = new Vector3(0.064f, 0f, 0.19f);
                rectt.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }

            // Page Buttons
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.07f, 0.2f, 0.07f);
            gameObject.transform.localPosition = new Vector3(0.56f, 0.30f, -0.52f);
            gameObject.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
            gameObject.AddComponent<Classes.Button>().relatedText = "PreviousPage";

            colorChanger = gameObject.AddComponent<ColorChanger>();
            colorChanger.colorInfo = buttonColors[0];
            colorChanger.Start();

            text = new GameObject
            {
                transform =
                        {
                            parent = canvasObject.transform
                        }
            }.AddComponent<Text>();
            text.font = currentFont;
            text.text = "<";
            text.fontSize = 1;
            text.color = textColors[0];
            text.alignment = TextAnchor.MiddleCenter;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.2f, 0.02f);
            component.localPosition = new Vector3(0.064f, 0.09f, -0.20f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

            gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.2f, 0.07f);
            gameObject.transform.localPosition = new Vector3(0.56f, -0.3f, -0.52f);
            gameObject.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
            gameObject.AddComponent<Classes.Button>().relatedText = "NextPage";

            colorChanger = gameObject.AddComponent<ColorChanger>();
            colorChanger.colorInfo = buttonColors[0];
            colorChanger.Start();

            text = new GameObject
            {
                transform =
                        {
                            parent = canvasObject.transform
                        }
            }.AddComponent<Text>();
            text.font = currentFont;
            text.text = ">";
            text.fontSize = 1;
            text.color = textColors[0];
            text.alignment = TextAnchor.MiddleCenter;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.2f, 0.02f);
            component.localPosition = new Vector3(0.064f, -0.09f, -0.2f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

            // Mod Buttons
            ButtonInfo[] activeButtons = buttons[buttonsType].Skip(pageNumber * buttonsPerPage).Take(buttonsPerPage).ToArray();
            for (int i = 0; i < activeButtons.Length; i++)
            {
                CreateButton(i * 0.1f, activeButtons[i]);
            }

            // Admin
            try
            {
                if (PhotonNetwork.InRoom)
                {
                    if (PhotonNetwork.LocalPlayer.IsMasterClient && !lastMasterClient)
                    {
                        NotifiLib.SendNotification("<color=grey>[</color><color=purple>MASTER</color><color=grey>]</color> You are now master client.");
                    }
                    lastMasterClient = PhotonNetwork.LocalPlayer.IsMasterClient;
                }
            }
            catch { }
        }

        public static void CreateButton(float offset, ButtonInfo method)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f);
            gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - offset);
            gameObject.AddComponent<Classes.Button>().relatedText = method.buttonText;

            ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
            if (method.enabled)
            {
                colorChanger.colorInfo = buttonColors[1];
            }
            else
            {
                colorChanger.colorInfo = buttonColors[0];
            }
            colorChanger.Start();

            Text text = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<Text>();
            text.font = currentFont;
            text.text = method.buttonText;
            if (method.overlapText != null)
            {
                text.text = method.overlapText;
            }
            text.supportRichText = true;
            text.fontSize = 1;
            if (method.enabled)
            {
                text.color = textColors[1];
            }
            else
            {
                text.color = textColors[0];
            }
            text.alignment = TextAnchor.MiddleCenter;
            text.fontStyle = FontStyle.Italic;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(.2f, .02f);
            component.localPosition = new Vector3(.064f, 0, .108f - offset / 2.6f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }

        public static void RecreateMenu()
        {
            if (menu != null)
            {
                UnityEngine.Object.Destroy(menu);
                menu = null;

                CreateMenu();
                RecenterMenu(rightHanded, UnityInput.Current.GetKey(keyboardButton));
            }
        }

        public static void RecenterMenu(bool isRightHanded, bool isKeyboardCondition)
        {
            if (!isKeyboardCondition)
            {
                if (!isRightHanded)
                {
                    menu.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                    menu.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                }
                else
                {
                    menu.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    Vector3 rotation = GorillaTagger.Instance.rightHandTransform.rotation.eulerAngles;
                    rotation += new Vector3(0f, 0f, 180f);
                    menu.transform.rotation = Quaternion.Euler(rotation);
                }
            }
            else
            {
                try
                {
                    TPC = GameObject.Find("Player Objects/Third Person Camera/Shoulder Camera").GetComponent<Camera>();
                }
                catch { }
                if (TPC != null)
                {
                    TPC.transform.position = new Vector3(-999f, -999f, -999f);
                    TPC.transform.rotation = Quaternion.identity;
                    GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    bg.transform.localScale = new Vector3(10f, 10f, 0.01f);
                    bg.transform.transform.position = TPC.transform.position + TPC.transform.forward;
                    bg.GetComponent<Renderer>().material.color = new Color32((byte)(backgroundColor.colors[0].color.r * 50), (byte)(backgroundColor.colors[0].color.g * 50), (byte)(backgroundColor.colors[0].color.b * 50), 255);
                    GameObject.Destroy(bg, Time.deltaTime);
                    menu.transform.parent = TPC.transform;
                    menu.transform.position = (TPC.transform.position + (Vector3.Scale(TPC.transform.forward, new Vector3(0.5f, 0.5f, 0.5f)))) + (Vector3.Scale(TPC.transform.up, new Vector3(-0.02f, -0.02f, -0.02f)));
                    Vector3 rot = TPC.transform.rotation.eulerAngles;
                    rot = new Vector3(rot.x - 90, rot.y + 90, rot.z);
                    menu.transform.rotation = Quaternion.Euler(rot);

                    if (reference != null)
                    {
                        if (Mouse.current.leftButton.isPressed)
                        {
                            Ray ray = TPC.ScreenPointToRay(Mouse.current.position.ReadValue());
                            RaycastHit hit;
                            bool worked = Physics.Raycast(ray, out hit, 100);
                            if (worked)
                            {
                                Classes.Button collide = hit.transform.gameObject.GetComponent<Classes.Button>();
                                if (collide != null)
                                {
                                    collide.OnTriggerEnter(buttonCollider);
                                }
                            }
                        }
                        else
                        {
                            reference.transform.position = new Vector3(999f, -999f, -999f);
                        }
                    }
                }
            }
        }

        public static void CreateReference(bool isRightHanded)
        {
            reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            if (isRightHanded)
            {
                reference.transform.parent = GorillaTagger.Instance.leftHandTransform;
            }
            else
            {
                reference.transform.parent = GorillaTagger.Instance.rightHandTransform;
            }
            reference.GetComponent<Renderer>().material.color = backgroundColor.colors[0].color;
            reference.transform.localPosition = new Vector3(0f, -0.1f, 0f);
            reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            buttonCollider = reference.GetComponent<SphereCollider>();

            ColorChanger colorChanger = reference.AddComponent<ColorChanger>();
            colorChanger.colorInfo = backgroundColor;
            colorChanger.Start();
        }

        public static void Toggle(string buttonText)
        {
            int lastPage = ((buttons[buttonsType].Length + buttonsPerPage - 1) / buttonsPerPage) - 1;
            if (buttonText == "PreviousPage")
            {
                pageNumber--;
                if (pageNumber < 0)
                {
                    pageNumber = lastPage;
                }
            } else
            {
                if (buttonText == "NextPage")
                {
                    pageNumber++;
                    if (pageNumber > lastPage)
                    {
                        pageNumber = 0;
                    }
                } else
                {
                    ButtonInfo target = GetIndex(buttonText);
                    if (target != null)
                    {
                        if (target.isTogglable)
                        {
                            target.enabled = !target.enabled;
                            if (target.enabled)
                            {
                                NotifiLib.SendNotification("<color=grey>[</color><color=green>ENABLE</color><color=grey>]</color> " + target.toolTip);
                                if (target.enableMethod != null)
                                {
                                    try { target.enableMethod.Invoke(); } catch { }
                                }
                            }
                            else
                            {
                                NotifiLib.SendNotification("<color=grey>[</color><color=red>DISABLE</color><color=grey>]</color> " + target.toolTip);
                                if (target.disableMethod != null)
                                {
                                    try { target.disableMethod.Invoke(); } catch { }
                                }
                            }
                        }
                        else
                        {
                            NotifiLib.SendNotification("<color=grey>[</color><color=green>ENABLE</color><color=grey>]</color> " + target.toolTip);
                            if (target.method != null)
                            {
                                try { target.method.Invoke(); } catch { }
                            }
                        }
                    }
                    else
                    {
                        UnityEngine.Debug.LogError(buttonText + " does not exist");
                    }
                }
            }
            RecreateMenu();
        }

        private static Vector3 GunPositionSmoothed = Vector3.zero;
        public static (RaycastHit Ray, GameObject NewPointer) RenderGun(int overrideLayerMask = -1)
        {
            Transform GunTransform = SwapGunHand ? GorillaTagger.Instance.leftHandTransform : GorillaTagger.Instance.rightHandTransform;

            Vector3 StartPosition = GunTransform.position;
            Vector3 Direction = GunTransform.forward;

            switch (GunDirection)
            {
                case 1:
                    Direction = -GunTransform.up;
                    break;
                case 2:
                    Direction = GunTransform.right * (SwapGunHand ? 1f : -1f);
                    break;
                case 3:
                    Direction = SwapGunHand ? TrueLeftHand().forward : TrueRightHand().forward;
                    break;
            }

            Physics.Raycast(StartPosition + (Direction / 4f), Direction, out var Ray, 512f, overrideLayerMask > 0 ? overrideLayerMask : NoInvisLayerMask());
            if (shouldBePC)
            {
                Ray ray = TPC.ScreenPointToRay(Mouse.current.position.ReadValue());
                Physics.Raycast(ray, out Ray, 512f, NoInvisLayerMask());
            }
            Vector3 EndPosition = isCopying ? whoCopy.transform.position : Ray.point;

            if (SmoothGunPointer)
            {
                GunPositionSmoothed = Vector3.Lerp(GunPositionSmoothed, EndPosition, Time.deltaTime * 4f);
                EndPosition = GunPositionSmoothed;
            }

            GameObject NewPointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            NewPointer.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            NewPointer.GetComponent<Renderer>().material.color = (isCopying || GetGunInput(true)) ? GetBDColor(0f) : GetBRColor(0f);
            NewPointer.transform.localScale = smallGunPointer ? new Vector3(0.1f, 0.1f, 0.1f) : new Vector3(0.1f, 0.1f, 0.1f);
            NewPointer.transform.position = EndPosition;
            if (disableGunPointer)
            {
                NewPointer.GetComponent<Renderer>().enabled = false;
            }
            UnityEngine.Object.Destroy(NewPointer.GetComponent<BoxCollider>());
            UnityEngine.Object.Destroy(NewPointer.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(NewPointer.GetComponent<Collider>());
            UnityEngine.Object.Destroy(NewPointer, Time.deltaTime);

            if (!disableGunLine)
            {
                GameObject line = new GameObject("Line");
                LineRenderer liner = line.AddComponent<LineRenderer>();
                liner.material.shader = Shader.Find("GUI/Text Shader");
                liner.startColor = GetBGColor(0f);
                liner.endColor = GetBGColor(0f);
                liner.startWidth = 0.025f;
                liner.endWidth = 0.025f;
                liner.positionCount = 2;
                liner.useWorldSpace = true;
                liner.SetPosition(0, StartPosition);
                liner.SetPosition(1, EndPosition);
                UnityEngine.Object.Destroy(line, Time.deltaTime);

                int Step = 50;
                switch (gunVariation)
                {
                    case 1:
                        if (GetGunInput(true) || isCopying)
                        {
                            liner.positionCount = Step;
                            liner.SetPosition(0, StartPosition);

                            for (int i = 1; i < (Step - 1); i++)
                                liner.SetPosition(i, Vector3.Lerp(StartPosition, EndPosition, i / (Step - 1f)) + (UnityEngine.Random.Range(0f, 1f) > 0.75f ? new Vector3(UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(-0.1f, 0.1f)) : Vector3.zero));

                            liner.SetPosition(Step - 1, EndPosition);
                        }
                        break;
                    case 2:
                        if (GetGunInput(true) || isCopying)
                        {
                            liner.positionCount = Step;
                            liner.SetPosition(0, StartPosition);

                            for (int i = 1; i < (Step - 1); i++)
                                liner.SetPosition(i, Vector3.Lerp(StartPosition, EndPosition, i / (Step - 1f)) + new Vector3(0f, Mathf.Sin((Time.time * -10f) + i) * 0.05f, 0f));

                            liner.SetPosition(Step - 1, EndPosition);
                        }
                        break;
                    case 3:
                        if (GetGunInput(true) || isCopying)
                        {
                            liner.positionCount = Step;
                            liner.SetPosition(0, StartPosition);

                            for (int i = 1; i < (Step - 1); i++)
                            {
                                Vector3 Position = Vector3.Lerp(StartPosition, EndPosition, i / (Step - 1f));
                                liner.SetPosition(i, new Vector3(Mathf.Round(Position.x * 50f) / 50f, Mathf.Round(Position.y * 50f) / 50f, Mathf.Round(Position.z * 50f) / 50f));
                            }

                            liner.SetPosition(Step - 1, EndPosition);
                        }
                        break;
                }
            }

            return (Ray, NewPointer);
        }

        public static void VisualizeAura(Vector3 position, float range, Color color)
        {
            GameObject what = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            UnityEngine.Object.Destroy(what, Time.deltaTime);
            UnityEngine.Object.Destroy(what.GetComponent<Collider>());
            UnityEngine.Object.Destroy(what.GetComponent<Rigidbody>());
            what.transform.position = position;
            what.transform.localScale = new Vector3(range, range, range);
            Color clr = color;
            clr.a = 0.25f;
            what.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            what.GetComponent<Renderer>().material.color = clr;
        }

        public static List<NetPlayer> InfectedList()
        {
            List<NetPlayer> infected = new List<NetPlayer> { };
            string gamemode = GorillaGameManager.instance.GameModeName().ToLower();
            if (gamemode.Contains("infection") || gamemode.Contains("tag"))
            {
                GorillaTagManager tagman = GameObject.Find("GT Systems/GameModeSystem/Gorilla Tag Manager").GetComponent<GorillaTagManager>();
                if (tagman.isCurrentlyTag)
                {
                    infected.Add(tagman.currentIt);
                }
                else
                {
                    foreach (NetPlayer plr in tagman.currentInfected)
                    {
                        infected.Add(plr);
                    }
                }
            }
            if (gamemode.Contains("ghost"))
            {
                GorillaAmbushManager tagman = GameObject.Find("GT Systems/GameModeSystem/Gorilla GhostTag Manager").GetComponent<GorillaAmbushManager>();
                if (tagman.isCurrentlyTag)
                {
                    infected.Add(tagman.currentIt);
                }
                else
                {
                    foreach (NetPlayer plr in tagman.currentInfected)
                    {
                        infected.Add(plr);
                    }
                }
            }
            if (gamemode.Contains("ambush") || gamemode.Contains("stealth"))
            {
                GorillaAmbushManager tagman = GameObject.Find("GT Systems/GameModeSystem/Gorilla Stealth Manager").GetComponent<GorillaAmbushManager>();
                if (tagman.isCurrentlyTag)
                {
                    infected.Add(tagman.currentIt);
                }
                else
                {
                    foreach (NetPlayer plr in tagman.currentInfected)
                    {
                        infected.Add(plr);
                    }
                }
            }
            if (gamemode.Contains("freeze"))
            {
                GorillaFreezeTagManager tagman = GameObject.Find("GT Systems/GameModeSystem/Gorilla Freeze Tag Manager").GetComponent<GorillaFreezeTagManager>();
                if (tagman.isCurrentlyTag)
                {
                    infected.Add(tagman.currentIt);
                }
                else
                {
                    foreach (NetPlayer plr in tagman.currentInfected)
                    {
                        infected.Add(plr);
                    }
                }
            }
            return infected;
        }

        public static void AddInfected(NetPlayer plr)
        {
            string gamemode = GorillaGameManager.instance.GameModeName().ToLower();
            if (gamemode.Contains("infection") || gamemode.Contains("tag"))
            {
                GorillaTagManager tagman = GameObject.Find("GT Systems/GameModeSystem/Gorilla Tag Manager").GetComponent<GorillaTagManager>();
                if (tagman.isCurrentlyTag)
                {
                    tagman.ChangeCurrentIt(plr);
                }
                else
                {
                    if (!tagman.currentInfected.Contains(plr))
                    {
                        tagman.AddInfectedPlayer(plr);
                    }
                }
            }
            if (gamemode.Contains("ambush") || gamemode.Contains("stealth"))
            {
                GorillaAmbushManager tagman = GameObject.Find("GT Systems/GameModeSystem/Gorilla Stealth Manager").GetComponent<GorillaAmbushManager>();
                if (tagman.isCurrentlyTag)
                {
                    tagman.ChangeCurrentIt(plr);
                }
                else
                {
                    if (!tagman.currentInfected.Contains(plr))
                    {
                        tagman.AddInfectedPlayer(plr);
                    }
                }
            }
            if (gamemode.Contains("ghost"))
            {
                GorillaAmbushManager tagman = GameObject.Find("GT Systems/GameModeSystem/Gorilla GhostTag Manager").GetComponent<GorillaAmbushManager>();
                if (tagman.isCurrentlyTag)
                {
                    tagman.ChangeCurrentIt(plr);
                }
                else
                {
                    if (!tagman.currentInfected.Contains(plr))
                    {
                        tagman.AddInfectedPlayer(plr);
                    }
                }
            }
            if (gamemode.Contains("freeze"))
            {
                GorillaFreezeTagManager tagman = GameObject.Find("GT Systems/GameModeSystem/Gorilla Freeze Tag Manager").GetComponent<GorillaFreezeTagManager>();
                if (tagman.isCurrentlyTag)
                {
                    tagman.ChangeCurrentIt(plr);
                }
                else
                {
                    if (!tagman.currentInfected.Contains(plr))
                    {
                        tagman.AddInfectedPlayer(plr);
                    }
                }
            }
        }

        public static void RemoveInfected(NetPlayer plr)
        {
            string gamemode = GorillaGameManager.instance.GameModeName().ToLower();
            if (gamemode.Contains("infection") || gamemode.Contains("tag"))
            {
                GorillaTagManager tagman = GameObject.Find("GT Systems/GameModeSystem/Gorilla Tag Manager").GetComponent<GorillaTagManager>();
                if (tagman.isCurrentlyTag)
                {
                    if (tagman.currentIt == plr)
                    {
                        tagman.currentIt = null;
                    }
                }
                else
                {
                    if (tagman.currentInfected.Contains(plr))
                    {
                        tagman.currentInfected.Remove(plr);
                    }
                }
            }
            if (gamemode.Contains("ambush") || gamemode.Contains("stealth"))
            {
                GorillaAmbushManager tagman = GameObject.Find("GT Systems/GameModeSystem/Gorilla Stealth Manager").GetComponent<GorillaAmbushManager>();
                if (tagman.isCurrentlyTag)
                {
                    if (tagman.currentIt == plr)
                    {
                        tagman.currentIt = null;
                    }
                }
                else
                {
                    if (tagman.currentInfected.Contains(plr))
                    {
                        tagman.currentInfected.Remove(plr);
                    }
                }
            }
            if (gamemode.Contains("ghost"))
            {
                GorillaAmbushManager tagman = GameObject.Find("GT Systems/GameModeSystem/Gorilla GhostTag Manager").GetComponent<GorillaAmbushManager>();
                if (tagman.isCurrentlyTag)
                {
                    if (tagman.currentIt == plr)
                    {
                        tagman.currentIt = null;
                    }
                }
                else
                {
                    if (tagman.currentInfected.Contains(plr))
                    {
                        tagman.currentInfected.Remove(plr);
                    }
                }
            }
            if (gamemode.Contains("freeze"))
            {
                GorillaFreezeTagManager tagman = GameObject.Find("GT Systems/GameModeSystem/Gorilla Freeze Tag Manager").GetComponent<GorillaFreezeTagManager>();
                if (tagman.isCurrentlyTag)
                {
                    if (tagman.currentIt == plr)
                    {
                        tagman.currentIt = null;
                    }
                }
                else
                {
                    if (tagman.currentInfected.Contains(plr))
                    {
                        tagman.currentInfected.Remove(plr);
                    }
                }
            }
        }

        public static GradientColorKey[] GetSolidGradient(Color color)
        {
            return new GradientColorKey[] { new GradientColorKey(color, 0f), new GradientColorKey(color, 1f) };
        }

        public static ButtonInfo GetIndex(string buttonText)
        {
            foreach (ButtonInfo[] buttons in Menu.Buttons.buttons)
            {
                foreach (ButtonInfo button in buttons)
                {
                    if (button.buttonText == buttonText)
                    {
                        return button;
                    }
                }
            }

            return null;
        }

        public static void RPCProtection()
        {
            try
            {
                if (hasRemovedThisFrame == false)
                {
                    hasRemovedThisFrame = true;
                    if (GetIndex("Experimental RPC Protection").enabled)
                    {
                        PhotonNetwork.RaiseEvent(0, null, new RaiseEventOptions
                        {
                            CachingOption = EventCaching.DoNotCache,
                            TargetActors = new int[]
                            {
                                PhotonNetwork.LocalPlayer.ActorNumber
                            }
                        }, SendOptions.SendReliable);
                    }
                    else
                    {
                        GorillaNot.instance.rpcErrorMax = int.MaxValue;
                        GorillaNot.instance.rpcCallLimit = int.MaxValue;
                        GorillaNot.instance.logErrorMax = int.MaxValue;

                        PhotonNetwork.MaxResendsBeforeDisconnect = int.MaxValue;
                        PhotonNetwork.QuickResends = int.MaxValue;

                        //PhotonNetwork.OpCleanRpcBuffer(GorillaTagger.Instance.myVRRig.GetView);
                        PhotonNetwork.OpCleanActorRpcBuffer(PhotonNetwork.LocalPlayer.ActorNumber);
                        PhotonNetwork.SendAllOutgoingCommands();

                        GorillaNot.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
                    }
                }
            }
            catch { UnityEngine.Debug.Log("RPC protection failed, are you in a lobby?"); }
        }
        public static bool PlayerIsTagged(VRRig who)
        {
            string name = who.mainSkin.material.name.ToLower();
            return name.Contains("fected") || name.Contains("it") || name.Contains("stealth") || name.Contains("ice") || !who.nameTagAnchor.activeSelf;
            //return PlayerIsTagged(GorillaTagger.Instance.offlineVRRig);
        }


        public static Color GetBGColor(float offset)
        {
            Color oColor = bgColorA;
            GradientColorKey[] array = new GradientColorKey[3];
            array[0].color = bgColorA;
            array[0].time = 0f;
            array[1].color = bgColorB;
            array[1].time = 0.5f;
            array[2].color = bgColorA;
            array[2].time = 1f;

            Gradient bg = new Gradient
            {
                colorKeys = array
            };
            oColor = bg.Evaluate(((Time.time / 2f) + offset) % 1f);
            if (themeType == 6)
            {
                float h = ((Time.frameCount / 180f) + offset) % 1f;
                oColor = UnityEngine.Color.HSVToRGB(h, 1f, 1f);
            }
            if (themeType == 47)
            {
                oColor = new Color32((byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), 255);
            }
            if (themeType == 51)
            {
                float h = (Time.frameCount / 180f) % 1f;
                oColor = UnityEngine.Color.HSVToRGB(h, 0.3f, 1f);
            }
            if (themeType == 8)
            {
                if (!Menu.Main.PlayerIsTagged(GorillaTagger.Instance.offlineVRRig))
                {
                    oColor = GorillaTagger.Instance.offlineVRRig.mainSkin.material.color;
                }
                else
                {
                    oColor = new Color32(255, 111, 0, 255);
                }
            }

            return oColor;
        }
        public static Color GetBRColor(float offset)
        {
            Color oColor = buttonDefaultA;
            GradientColorKey[] array = new GradientColorKey[3];
            array[0].color = buttonDefaultA;
            array[0].time = 0f;
            array[1].color = buttonDefaultB;
            array[1].time = 0.5f;
            array[2].color = buttonDefaultA;
            array[2].time = 1f;

            Gradient bg = new Gradient
            {
                colorKeys = array
            };
            oColor = bg.Evaluate(((Time.time / 2f) + offset) % 1f);

            return oColor;
        }

        public static Color GetBDColor(float offset)
        {
            Color oColor = buttonClickedA;
            GradientColorKey[] array = new GradientColorKey[3];
            array[0].color = buttonClickedA;
            array[0].time = 0f;
            array[1].color = buttonClickedB;
            array[1].time = 0.5f;
            array[2].color = buttonClickedA;
            array[2].time = 1f;

            Gradient bg = new Gradient
            {
                colorKeys = array
            };
            oColor = bg.Evaluate(((Time.time / 2f) + offset) % 1f);
            if (themeType == 6)
            {
                float h = ((Time.frameCount / 180f) + offset) % 1f;
                oColor = UnityEngine.Color.HSVToRGB(h, 1f, 1f);
            }
            if (themeType == 47)
            {
                oColor = new Color32((byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), 255);
            }
            if (themeType == 51)
            {
                float h = (Time.frameCount / 180f) % 1f;
                oColor = UnityEngine.Color.HSVToRGB(h, 0.3f, 1f);
            }
            if (themeType == 8)
            {
                if (!Menu.Main.PlayerIsTagged(GorillaTagger.Instance.offlineVRRig))
                {
                    oColor = GorillaTagger.Instance.offlineVRRig.mainSkin.material.color;
                }
                else
                {
                    oColor = new Color32(255, 111, 0, 255);
                }
            }

            return oColor;
        }

        public static void ChangeColor(Color color)
        {
            PlayerPrefs.SetFloat("redValue", Mathf.Clamp(color.r, 0f, 1f));
            PlayerPrefs.SetFloat("greenValue", Mathf.Clamp(color.g, 0f, 1f));
            PlayerPrefs.SetFloat("blueValue", Mathf.Clamp(color.b, 0f, 1f));

            //GorillaTagger.Instance.offlineVRRig.mainSkin.material.color = color;
            GorillaTagger.Instance.UpdateColor(color.r, color.g, color.b);
            PlayerPrefs.Save();

            try
            {
                GorillaTagger.Instance.myVRRig.SendRPC("RPC_InitializeNoobMaterial", RpcTarget.All, new object[] { color.r, color.g, color.b });
                RPCProtection();
            }
            catch { }
        }

        public static bool GetGunInput(bool isShooting)
        {
            if (isShooting)
                return (SwapGunHand ? leftTrigger > 0.5f : rightTrigger > 0.5f) || Mouse.current.leftButton.isPressed;
            else
                return (SwapGunHand ? leftGrab : rightGrab) || Mouse.current.rightButton.isPressed;
        }

        public static string[] letters = new string[]
        {
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J", "K", "L", "Z", "X", "C", "V", "B", "N", "M"
        };

        public static int[] bones = new int[] {
            4, 3, 5, 4, 19, 18, 20, 19, 3, 18, 21, 20, 22, 21, 25, 21, 29, 21, 31, 29, 27, 25, 24, 22, 6, 5, 7, 6, 10, 6, 14, 6, 16, 14, 12, 10, 9, 7
        };


        // Variables
        // Important
        // Objects
        public static GameObject menu;
                    public static GameObject menuBackground;   
                    public static GameObject reference;
                    public static GameObject canvasObject;

                    public static SphereCollider buttonCollider;
                    public static Camera TPC;
                    public static Text fpsObject;

        public static bool hasRemovedThisFrame = false;


        public static (Vector3 position, Quaternion rotation, Vector3 up, Vector3 forward, Vector3 right) TrueLeftHand()
        {
            Quaternion rot = GorillaTagger.Instance.leftHandTransform.rotation * GorillaLocomotion.Player.Instance.leftHandRotOffset;
            return (GorillaTagger.Instance.leftHandTransform.position + GorillaTagger.Instance.leftHandTransform.rotation * GorillaLocomotion.Player.Instance.leftHandOffset, rot, rot * Vector3.up, rot * Vector3.forward, rot * Vector3.right);
        }

        public static (Vector3 position, Quaternion rotation, Vector3 up, Vector3 forward, Vector3 right) TrueRightHand()
        {
            Quaternion rot = GorillaTagger.Instance.rightHandTransform.rotation * GorillaLocomotion.Player.Instance.rightHandRotOffset;
            return (GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.rotation * GorillaLocomotion.Player.Instance.rightHandOffset, rot, rot * Vector3.up, rot * Vector3.forward, rot * Vector3.right);
        }

        public static int NoInvisLayerMask()
        {
            return ~(1 << TransparentFX | 1 << IgnoreRaycast | 1 << Zone | 1 << GorillaTrigger | 1 << GorillaBoundary | 1 << GorillaCosmetics | 1 << GorillaParticle);
        }

        public static BalloonHoldable[] archiveballoons = null;
        public static BalloonHoldable[] GetBalloons()
        {
            if (Time.time > lastRecievedTime)
            {
                archiveballoons = null;
                lastRecievedTime = Time.time + 5f;
            }
            if (archiveballoons == null)
            {
                archiveballoons = UnityEngine.Object.FindObjectsOfType<BalloonHoldable>();
            }
            return archiveballoons;
        }

        public static void WorldScale(GameObject obj, Vector3 targetWorldScale)
        {
            Vector3 parentScale = obj.transform.parent.lossyScale;
            obj.transform.localScale = new Vector3(targetWorldScale.x / parentScale.x, targetWorldScale.y / parentScale.y, targetWorldScale.z / parentScale.z);
        }

        public static void FixStickyColliders(GameObject platform) // Object must be at true hand position
        {
            Vector3[] localPositions = new Vector3[]
            {
                new Vector3(0, 1f, 0),
                new Vector3(0, -1f, 0),
                new Vector3(1f, 0, 0),
                new Vector3(-1f, 0, 0),
                new Vector3(0, 0, 1f),
                new Vector3(0, 0, -1f)
            };
            Quaternion[] localRotations = new Quaternion[]
            {
                Quaternion.Euler(90, 0, 0),
                Quaternion.Euler(-90, 0, 0),
                Quaternion.Euler(0, -90, 0),
                Quaternion.Euler(0, 90, 0),
                Quaternion.identity,
                Quaternion.Euler(0, 180, 0)
            };
            for (int i = 0; i < localPositions.Length; i++)
            {
                GameObject side = GameObject.CreatePrimitive(PrimitiveType.Cube);
                try
                {
                    if (platformMode == 5)
                    {
                        side.AddComponent<GorillaSurfaceOverride>().overrideIndex = 29;
                    }
                    if (platformMode == 6)
                    {
                        side.AddComponent<GorillaSurfaceOverride>().overrideIndex = 32;
                    }
                    if (platformMode == 7)
                    {
                        side.AddComponent<GorillaSurfaceOverride>().overrideIndex = 204;
                    }
                    if (platformMode == 8)
                    {
                        side.AddComponent<GorillaSurfaceOverride>().overrideIndex = 231;
                    }
                    if (platformMode == 9)
                    {
                        side.AddComponent<GorillaSurfaceOverride>().overrideIndex = 240;
                    }
                    if (platformMode == 10)
                    {
                        side.AddComponent<GorillaSurfaceOverride>().overrideIndex = 249;
                    }
                    if (platformMode == 11)
                    {
                        side.AddComponent<GorillaSurfaceOverride>().overrideIndex = 252;
                    }
                }
                catch { }
                float size = 0.025f;
                side.transform.SetParent(platform.transform);
                side.transform.position = localPositions[i] * (size / 2);
                side.transform.rotation = localRotations[i];
                WorldScale(side, new Vector3(size, size, 0.01f));
                side.GetComponent<Renderer>().enabled = false;
            }
        }

        public static SnowballThrowable[] snowballs = new SnowballThrowable[] { };
        public static Dictionary<string, SnowballThrowable> snowballDict = null;
        public static SnowballThrowable GetProjectile(string provided)
        {
            if (snowballDict == null)
            {
                snowballDict = new Dictionary<string, SnowballThrowable>();

                snowballs = UnityEngine.Object.FindObjectsOfType<SnowballThrowable>(true);
                foreach (SnowballThrowable lol in snowballs)
                {
                    try
                    {
                        if (GetFullPath(lol.transform.parent).ToLower() == "player objects/local vrrig/local gorilla player/holdables" || GetFullPath(lol.transform.parent).ToLower().Contains("player objects/local vrrig/local gorilla player/riganchor/rig/body/shoulder.l/upper_arm.l/forearm.l/hand.l/palm.01.l/transferrableitemlefthand") || GetFullPath(lol.transform.parent).ToLower().Contains("player objects/local vrrig/local gorilla player/riganchor/rig/body/shoulder.r/upper_arm.r/forearm.r/hand.r/palm.01.r/transferrableitemrighthand"))
                        {
                            UnityEngine.Debug.Log("Projectile " + lol.gameObject.name + " logged");
                            snowballDict.Add(lol.gameObject.name, lol);
                        }
                    }
                    catch { }
                }
                if (snowballDict.Count < 18)
                {
                    UnityEngine.Debug.Log("Projectile dictionary unfinished (" + snowballDict.Count + "/18)");
                    snowballDict = null;
                }
            }
            if (snowballDict != null && snowballDict.ContainsKey(provided))
            {
                return snowballDict[provided];
            }
            else
            {
                UnityEngine.Debug.Log("No key found for " + provided);
                return null;
            }
        }

        public static string GetFullPath(Transform transform)
        {
            string path = "";
            while (transform.parent != null)
            {
                transform = transform.parent;
                if (path == "")
                {
                    path = transform.name;
                }
                else
                {
                    path = transform.name + "/" + path;
                }
            }
            return path;
        }

        public static VRRig PlayerGun;
        public static GameObject GunMain;
        public static LineRenderer LineMain;
        public static Color GunPointerColor1 = Color.black;
        public static GameObject pointer = null;
        public static VRRig GunShitLock;
        public static Color GunColorShit = Color.white;
        public static bool GunPointerShit;
        public static VRRig GunLockRig;

        public static GameObject CreateGun(Vector3 position, Color color, float scale)
        {
            GameObject gun = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            gun.GetComponent<Renderer>().material.color = color;
            gun.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            gun.transform.localScale = new Vector3(scale, scale, scale);
            gun.transform.position = position;

            UnityEngine.Object.Destroy(gun.GetComponent<BoxCollider>());
            UnityEngine.Object.Destroy(gun.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(gun.GetComponent<Collider>());

            return gun;
        }

        public static LineRenderer CreateLine(Vector3 startPosition, Vector3 endPosition, Color color, float width)
        {
            GameObject lineObject = new GameObject("Line");
            LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();
            lineRenderer.startColor = color;
            lineRenderer.endColor = color;
            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;
            lineRenderer.positionCount = 2;
            lineRenderer.useWorldSpace = true;
            lineRenderer.SetPosition(0, startPosition);
            lineRenderer.SetPosition(1, endPosition);
            lineRenderer.material.shader = Shader.Find("GUI/Text Shader");

            return lineRenderer;
        }

        public static void DestroyObject(GameObject obj)
        {
            if (obj != null)
            {
                UnityEngine.Object.Destroy(obj);
            }
        }

        public static IEnumerator DestroyAfterDelay(GameObject obj, float delay)
        {
            yield return new WaitForSeconds(delay);
            DestroyObject(obj);
        }



        // Data
        public static int pageNumber = 0;
            public static int buttonsType = 0;

            public static float armlength = 1.25f;

            public static string serverLink = "https://discord.gg/Y4PZPHjb7B";

            public static int flySpeedCycle = 1;
            public static float flySpeed = 10f;

        public static bool noclip = false;
        public static bool bothHands = false;

        public static string rejRoom = null;
        public static float rejDebounce = 0f;

        public static float kgDebounce = 0f;

        public static bool isMenuButtonHeld = false;
        public static bool shouldBePC = false;
        public static bool leftPrimary = false;
        public static bool leftSecondary = false;
        public static bool rightPrimary = false;
        public static bool rightSecondary = false;
        public static bool leftGrab = false;
        public static bool rightGrab = false;
        public static float leftTrigger = 0f;
        public static float rightTrigger = 0f;

        public static int TransparentFX = LayerMask.NameToLayer("TransparentFX");
        public static int IgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
        public static int Zone = LayerMask.NameToLayer("Zone");
        public static int GorillaTrigger = LayerMask.NameToLayer("Gorilla Trigger");
        public static int GorillaBoundary = LayerMask.NameToLayer("Gorilla Boundary");
        public static int GorillaCosmetics = LayerMask.NameToLayer("GorillaCosmetics");
        public static int GorillaParticle = LayerMask.NameToLayer("GorillaParticle");

        public static int themeType = 1;
        public static Color bgColorA = new Color32(0, 0, 0, 0);
        public static Color bgColorB = new Color32(0, 0, 0, 0);

        public static Color buttonDefaultA = new Color32(0, 0, 0, 0);
        public static Color buttonDefaultB = new Color32(0, 0, 0, 0);

        public static Color buttonClickedA = new Color32(0, 0, 0, 0);
        public static Color buttonClickedB = new Color32(0, 0, 0, 0);

        public static bool SmoothGunPointer = false;
        public static bool smallGunPointer = false;
        public static bool disableGunPointer = false;
        public static bool disableGunLine = false;
        public static bool SwapGunHand = false;
        public static int gunVariation = 0;
        public static int GunDirection = 0;

        public static bool isCopying = false;
        public static VRRig whoCopy = null;

        public static float startX = -1f;
        public static float startY = -1f;

        public static float subThingy = 0f;
        public static float subThingyZ = 0f;

        public static Vector2 leftJoystick = Vector2.zero;
        public static Vector2 rightJoystick = Vector2.zero;

        public static bool EverythingSlippery = false;
        public static bool EverythingGrippy = false;

        private static float lastRecievedTime = -1f;

        public static FontStyle activeFontStyle = FontStyle.Italic;

        public static float colorChangerDelay = 0f;
        public static bool strobeColor = false;

        public static int platformMode;

        public static bool lastMasterClient;

        public static float projDebounce;
        public static float projDebounceType = 0.1f;
        public static int projmode;
        public static int trailmode;

        public static int shootCycle = 1;
        public static float ShootStrength = 19.44f;

        public static float red;
        public static float green;
        public static float blue;

        public static string[] ExternalProjectileNames = new string[]
        {
            "SnowballLeft",
            "WaterBalloonLeft",
            "LavaRockLeft",
            "BucketGiftFunctional",
            "ScienceCandyLeft",
            "FishFoodLeft",
            "TrickTreatFunctionalAnchor",
            "VotingRockAnchor_LEFT",
            "TrickTreatFunctionalAnchor",
            "TrickTreatFunctionalAnchor",
            "AppleLeftAnchor"
        };

        public static string[] InternalProjectileNames = new string[]
        {
            "LMACE. LEFT.",
            "LMAEX. LEFT.",
            "LMAGD. LEFT.",
            "LMAHQ. LEFT.",
            "LMAIE. RIGHT.",
            "LMAIO. LEFT.",
            "LMAMN. LEFT.",
            "LMAMS. LEFT.",
            "LMAMN. LEFT.",
            "LMAMN. LEFT.",
            "LMAMU. LEFT."
        };

        public static VRRig GhostRig = null;
        public static bool ghostException;
        public static bool disableGhostview;
        public static bool legacyGhostview;
        public static Material funnyghostmaterial = null;

        public static bool lastHit;
        public static bool lastHit2;

        public static float splashDel;

        public static int buttonClickSound = 8;
        public static int buttonClickIndex;
        public static int buttonClickVolume = 4;

        public static bool openedwithright;

        public static int speedboostCycle = 1;
        public static float jspeed = 7.5f;
        public static float jmulti = 1.25f;
    }
}
