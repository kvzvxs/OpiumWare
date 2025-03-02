using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GorillaExtensions;
using OpiumWare.Classes;
using Photon.Pun;
using POpusCodec.Enums;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using static OpiumWare.Menu.Main;

namespace OpiumWare.Mods
{
    internal class Visual
    {
        public static void Tracers()
        {
            if (PhotonNetwork.InLobby || PhotonNetwork.InRoom)
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (!vrrig.isOfflineVRRig)
                    {
                        GameObject gameObject = new GameObject("Line");
                        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();

                        Gradient gradient = new Gradient();

                        Color red = new Color(1.0f, 0.0f, 0.0f);
                        Color green = new Color(0.0f, 1.0f, 0.0f);
                        Color blue = new Color(0.0f, 0.0f, 1.0f);

                        gradient.SetKeys(
                            new GradientColorKey[] {
                                new GradientColorKey(blue, 0.0f),
                                new GradientColorKey(green, 0.33f),
                                new GradientColorKey(red, 0.66f)
                            },
                            new GradientAlphaKey[] {
                                new GradientAlphaKey(1.0f, 0.0f),
                                new GradientAlphaKey(1.0f, 1.0f)
                            }
                        );

                        lineRenderer.colorGradient = gradient;
                        lineRenderer.startWidth = lineRenderer.endWidth = 0.01f;
                        lineRenderer.positionCount = 2;
                        lineRenderer.SetPositions(new Vector3[]
                        {
                            GorillaLocomotion.Player.Instance.rightControllerTransform.position,
                            vrrig.transform.position
                        });
                        lineRenderer.material.shader = Shader.Find("GUI/Text Shader");

                        UnityEngine.Object.Destroy(gameObject, Time.deltaTime);
                    }
                }
            }
        }

        public static void BoxESP()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != null && !vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                {
                    GameObject gameObject = new GameObject("box");
                    gameObject.transform.position = vrrig.transform.position;

                    GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    GameObject gameObject3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    GameObject gameObject4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    GameObject gameObject5 = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    UnityEngine.Object.Destroy(gameObject2.GetComponent<BoxCollider>());
                    UnityEngine.Object.Destroy(gameObject5.GetComponent<BoxCollider>());
                    UnityEngine.Object.Destroy(gameObject4.GetComponent<BoxCollider>());
                    UnityEngine.Object.Destroy(gameObject3.GetComponent<BoxCollider>());

                    gameObject2.transform.SetParent(gameObject.transform);
                    gameObject2.transform.localPosition = new Vector3(0f, 0.49f, 0f);
                    gameObject2.transform.localScale = new Vector3(1f, 0.02f, 0.02f);

                    gameObject5.transform.SetParent(gameObject.transform);
                    gameObject5.transform.localPosition = new Vector3(0f, -0.49f, 0f);
                    gameObject5.transform.localScale = new Vector3(1f, 0.02f, 0.02f);

                    gameObject4.transform.SetParent(gameObject.transform);
                    gameObject4.transform.localPosition = new Vector3(-0.49f, 0f, 0f);
                    gameObject4.transform.localScale = new Vector3(0.02f, 1f, 0.02f);

                    gameObject3.transform.SetParent(gameObject.transform);
                    gameObject3.transform.localPosition = new Vector3(0.49f, 0f, 0f);
                    gameObject3.transform.localScale = new Vector3(0.02f, 1f, 0.02f);

                    Color[] colors = new Color[]
                    {
                        new Color(0.0f, 0.0f, 1.0f),
                        new Color(0.0f, 1.0f, 0.0f),
                        new Color(1.0f, 0.0f, 0.0f)
                    };

                    float duration = 3.0f;
                    float t = (Time.time % duration) / duration;
                    int fromIndex = (int)(t * (colors.Length - 1));
                    int toIndex = (fromIndex + 1) % colors.Length;
                    float lerpT = (t * (colors.Length - 1)) % 1.0f;

                    Color lerpedColor = Color.Lerp(colors[fromIndex], colors[toIndex], lerpT);

                    gameObject2.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    gameObject5.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    gameObject4.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    gameObject3.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");

                    gameObject2.GetComponent<Renderer>().material.color = lerpedColor;
                    gameObject5.GetComponent<Renderer>().material.color = lerpedColor;
                    gameObject4.GetComponent<Renderer>().material.color = lerpedColor;
                    gameObject3.GetComponent<Renderer>().material.color = lerpedColor;

                    gameObject.transform.LookAt(gameObject.transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);

                    UnityEngine.Object.Destroy(gameObject, Time.deltaTime);
                }
            }
        }

        public static void RGBSky()
        {
            if (oldSkyMat == null)
            {
                GetSky();
                return;
            }
            float num = (float)Time.frameCount / 180f % 1f;
            Renderer SkyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>();
            SkyObject.material.shader = Shader.Find("GorillaTag/UberShader");
            SkyObject.material.color = Color.HSVToRGB(num, 1f, 1f);
        }
        public static void FixSky()
        {
            if (oldSkyMat == null) return;
            GameObject sky = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky");
            sky.GetComponent<MeshRenderer>().material = oldSkyMat;
        }

        private static Material oldSkyMat;
        public static void GetSky()
        {
            GameObject sky = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky");
            oldSkyMat = new Material(sky.GetComponent<MeshRenderer>().material);
        }

        public static void NightTime()
        {
            BetterDayNightManager.instance.SetTimeOfDay(0);
        }

        public static void EveningTime()
        {
            BetterDayNightManager.instance.SetTimeOfDay(7);
        }

        public static void MorningTime()
        {
            BetterDayNightManager.instance.SetTimeOfDay(1);
        }

        public static void DayTime()
        {
            BetterDayNightManager.instance.SetTimeOfDay(3);
        }

        public static void Rain()
        {
            for (int i = 1; i < BetterDayNightManager.instance.weatherCycle.Length; i++)
            {
                BetterDayNightManager.instance.weatherCycle[i] = BetterDayNightManager.WeatherType.Raining;
            }
        }

        public static void NoRain()
        {
            for (int i = 1; i < BetterDayNightManager.instance.weatherCycle.Length; i++)
            {
                BetterDayNightManager.instance.weatherCycle[i] = BetterDayNightManager.WeatherType.None;
            }
        }

        private static LightmapData[] hell = null;
        public static void Fullbright()
        {
            hell = LightmapSettings.lightmaps;
            LightmapSettings.lightmaps = null;
        }

        public static void Fullshade()
        {
            LightmapSettings.lightmaps = hell;
        }

        private static Dictionary<VRRig, GameObject> nametags = new Dictionary<VRRig, GameObject> { };
        public static void NameTags()
        {
            foreach (KeyValuePair<VRRig, GameObject> nametag in nametags)
            {
                if (!GorillaParent.instance.vrrigs.Contains(nametag.Key))
                {
                    UnityEngine.Object.Destroy(nametag.Value);
                    nametags.Remove(nametag.Key);
                }
            }

            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    if (!nametags.ContainsKey(vrrig))
                    {
                        GameObject go = new GameObject("iiMenu_Nametag");
                        go.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                        TextMesh textMesh = go.AddComponent<TextMesh>();
                        textMesh.fontSize = 48;
                        textMesh.characterSize = 0.1f;
                        textMesh.anchor = TextAnchor.MiddleCenter;
                        textMesh.alignment = TextAlignment.Center;

                        nametags.Add(vrrig, go);
                    }

                    GameObject nameTag = nametags[vrrig];
                    nameTag.GetComponent<TextMesh>().text = RigManager.GetPlayerFromVRRig(vrrig).NickName;
                    nameTag.GetComponent<TextMesh>().color = vrrig.playerColor;
                    nameTag.GetComponent<TextMesh>().fontStyle = activeFontStyle;

                    nameTag.transform.position = vrrig.headMesh.transform.position + vrrig.headMesh.transform.up * 0.4f;
                    nameTag.transform.LookAt(Camera.main.transform.position);
                    nameTag.transform.Rotate(0f, 180f, 0f);
                }
            }
        }

        public static void DisableNameTags()
        {
            foreach (KeyValuePair<VRRig, GameObject> nametag in nametags)
            {
                UnityEngine.Object.Destroy(nametag.Value);
            }
            nametags.Clear();
        }



        /*public static void EnableRemoveLeaves()
        {
            foreach (GameObject g in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                if (g.activeSelf && g.name.Contains("smallleaves"))
                {
                    g.SetActive(false);
                    leaves.Add(g);
                }
            }
        }

        public static void DisableRemoveLeaves()
        {
            foreach (GameObject l in leaves)
            {
                l.SetActive(true);
            }
            leaves.Clear();
        }*/
        public static List<GameObject> leaves = new List<GameObject> { };
        public static void EnableRemoveLeaves()
        {
            foreach (GameObject g in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                if (g.activeSelf && (g.name.Contains("leaves_green") || g.name.Contains("fallleaves")))
                {
                    g.SetActive(false);
                    leaves.Add(g);
                }
            }
        }

        public static void DisableRemoveLeaves()
        {
            foreach (GameObject l in leaves)
            {
                l.SetActive(true);
            }
            leaves.Clear();
        }

        public static bool PerformanceVisuals;
        public static void PerformanceVisualsEnabled()
        {
            PerformanceVisuals = true;
        }
        public static void PerformanceVisualsDisabled()
        {
            PerformanceVisuals = false;
        }

        private static Dictionary<VRRig, float> delays = new Dictionary<VRRig, float> { };
        public static void FixRigMaterialESPColors(VRRig rig)
        {
            if ((delays.ContainsKey(rig) && Time.time > delays[rig]) || !delays.ContainsKey(rig))
            {
                if (delays.ContainsKey(rig))
                    delays[rig] = Time.time + 5f;
                else
                    delays.Add(rig, Time.time + 5f);

                rig.mainSkin.sharedMesh.colors32 = Enumerable.Repeat((Color32)Color.white, rig.mainSkin.sharedMesh.colors32.Length).ToArray();
                rig.mainSkin.sharedMesh.colors = Enumerable.Repeat(Color.white, rig.mainSkin.sharedMesh.colors.Length).ToArray();
            }
        }

        public static float PerformanceModeStep = 0.2f;
        public static int PerformanceModeStepIndex = 2;

        public static float PerformanceVisualDelay;
        public static int DelayChangeStep;
    }
}

