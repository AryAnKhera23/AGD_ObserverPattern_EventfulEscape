using UnityEngine;

public class KeyView : MonoBehaviour, IInteractable
{
    [SerializeField] GameUIView gameUIView;
    
    private void OnEnable() => EventService.Instance.OnKeyPickedUp.AddListener(onKeyPickedup);
    private void OnDisable() => EventService.Instance.OnKeyPickedUp.RemoveListener(onKeyPickedup);
    public void Interact() => EventService.Instance.OnKeyPickedUp.InvokeEvent();
    

    public void onKeyPickedup()
    {
        int currentKeys = GameService.Instance.GetPlayerController().KeysEquipped;
        GameService.Instance.GetInstructionView().HideInstruction();
        GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.KeyPickUp);
        currentKeys++;
        gameUIView.UpdateKeyText();

        gameObject.SetActive(false);
    }
}
