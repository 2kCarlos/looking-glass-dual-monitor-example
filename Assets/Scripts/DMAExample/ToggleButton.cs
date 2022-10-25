using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LookingGlass;

namespace DMAExample {
    public class ToggleButton : MonoBehaviour {
        [SerializeField] private InterProcessCommunicator ipc;

        #region Public Inspector Methods
        public void InspectorToggle() {
            IPCCommand cmd = new IPCCommand { commandName = "toggleExamplePrefab" };
            string json = JsonUtility.ToJson(cmd);
            ipc.SendData(json);
        }
        #endregion
    }
}
