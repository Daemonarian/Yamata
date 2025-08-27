using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BepInEx;

namespace com.daemonarium.yamata
{
    [BepInPlugin("com.daemonarium.yamata", "Yamata", "0.0.1")]
    public class MyModPlugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("My Mod is awake!");
        }
    }
}
