using System;
using UnityEngine;

public class SkullDropEvent : MonoBehaviour
{
    [SerializeField] private int keysRequiredToTrigger;
    [SerializeField] private Transform skulls;
    [SerializeField] private SoundType soundToPlay;


    private void OnEnable() => EventService.Instance.OnSkullShower.AddListener(OnSkullDrop);
    private void OnDisable() => EventService.Instance.OnSkullShower.RemoveListener(OnSkullDrop);

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerView>() != null && GameService.Instance.GetPlayerController().KeysEquipped >= keysRequiredToTrigger)
        {
            EventService.Instance.OnSkullShower.InvokeEvent();
            GameService.Instance.GetSoundView().PlaySoundEffects(soundToPlay);
            GetComponent<Collider>().enabled = false;
        }
    }

    private void OnSkullDrop()
    {
        skulls.gameObject.SetActive(true);
    }
}
