using System;
using Unity.VisualScripting;
using UnityEngine;

public class LightsOffByGhostEvent : MonoBehaviour
{
    [SerializeField] private int keysRequired;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerView player) &&
            GameService.Instance.GetPlayerController().KeysEquipped == keysRequired)
        {
            EventService.Instance.OnLightsOffByGhostEvent.InvokeEvent();
            GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.SpookyGiggle);
            GetComponent<Collider>().enabled = false;
        };
    }
}