using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BepInEx;

namespace com.daemonarium.yamata
{
    [BepInPlugin("com.daemonarium.yamata", "Yamata", "0.0.1")]
    public class YamataPlugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("Yamata is awake!");
        }
    }
}
