using System;
using System.Collections;
using System.Collections.Generic;
using models.inputs;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class device : MonoBehaviour
{
    [SerializeField] public Button BackButton;
    [SerializeField] public Button GetDevicesButton;
    [SerializeField] public Button RevokeButton;
    [SerializeField] public TMP_InputField DeviceIdInput;

    // Start is called before the first frame update
    async void Start()
    {
        BackButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("mainMenu");
        });

        RevokeButton.onClick.AddListener(async () =>
        {
            var deviceId = DeviceIdInput.text;

            await DynamicPixels.Table.GetServices().Devices.RevokeDevice(new RevokeDeviceParams
            {
                DeviceId = Convert.ToInt32(deviceId)
            });
        });
        
        GetDevicesButton.onClick.AddListener(async () =>
        {
            var devices = await DynamicPixels.Table.GetServices().Devices.FindMyDevices(new FindMyDeviceParams{});

            foreach (var d in devices)
            {
                Debug.Log(d.ToString());    
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
