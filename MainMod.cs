using CapuchinMelonLoaderTemplate;
using MelonLoader;
using UnityEngine.XR;
using UnityEngine;

[assembly : MelonInfo(typeof(MainMod), ModInfo.NAME, ModInfo.VERSION, ModInfo.AUTHOR)]

namespace CapuchinMelonLoaderTemplate
{
    public class MainMod : MelonMod
    {
        void Update()
        {
            if (CaputillaMelonLoader.CaputillaHub.InModdedRoom)
            {
                InputDevice rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
                if (rightHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonPressed) && primaryButtonPressed)
                {
                    Vector3 forwardMovement = GameObject.Find("Main Camera").transform.TransformDirection(Vector3.forward) * 0.05f;
                    GameObject.Find("CapuchinPlayer").transform.position += forwardMovement;
                    Rigidbody playerRb = GameObject.Find("CapuchinPlayer").GetComponent<Rigidbody>();
                    playerRb.velocity = Vector3.zero;
                }
            }
        }
    }
}