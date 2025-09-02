using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.SceneManagement;

using BepInEx;
using HarmonyLib;

namespace com.daemonarium.Yamata
{
    [BepInPlugin("com.daemonarium.yamata", "Yamata", "0.0.1")]
    public class YamataPlugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("Yamata is awake!");
            new Harmony("com.daemonarium.yamata").PatchAll();
            Logger.LogInfo("Yamata finished patching.");
        }
    }

    [HarmonyPatch(typeof(NetworkLevelLoader), "LoadLevel", new Type[]
    {
        typeof(int),
        typeof(int),
        typeof(float),
        typeof(bool)
    })]
    public class NetworkLevelLoader_LoadLevel
    {
        internal static void Prefix(ref int _buildIndex)
        {
            try
            {
                CharacterSave chosenSave = SplitScreenManager.Instance.LocalPlayers[0].ChosenSave;
                if (!((CharacterSaveData)chosenSave.PSave).NewSave && !string.IsNullOrEmpty(chosenSave.PSave.AreaName))
                {
                    return;
                }
                for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
                    if (fileNameWithoutExtension != null && fileNameWithoutExtension == "DreamWorld")
                    {
                        _buildIndex = i;
                        break;
                    }
                }
            }
            catch
            {
            }
        }
    }
}
