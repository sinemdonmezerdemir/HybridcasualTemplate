using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class NextCam : MonoBehaviour
{
    private async void OnEnable()
    {
        await Task.Delay(1500);

        this.gameObject.SetActive(false);
    }
}
