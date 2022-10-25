using UnityEngine;
using LookingGlass;

namespace DMAExample {
    public class PrefabToggler : MonoBehaviour {
        [SerializeField] private InterProcessCommunicator ipc;
        [SerializeField] private GameObject prefab;

        private GameObject instance;

        private void OnEnable() {
            instance = GameObject.Instantiate(prefab, transform);
            instance.gameObject.SetActive(false);
            ipc.OnMessageReceived += OnIPCMessageReceived;
        }

        private void OnDisable() {
            ipc.OnMessageReceived -= OnIPCMessageReceived;
        }

        private void OnIPCMessageReceived(string message) {
            IPCCommand command = JsonUtility.FromJson<IPCCommand>(message);
            switch (command.commandName) {
                case "toggleExamplePrefab":
                    instance.gameObject.SetActive(!instance.gameObject.activeSelf);
                    break;
            }
        }
    }
}
