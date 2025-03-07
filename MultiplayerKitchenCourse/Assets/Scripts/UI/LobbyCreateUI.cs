using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyCreateUI : MonoBehaviour
{
    [SerializeField] Button closeButton;
    [SerializeField] Button createPublicButton;
    [SerializeField] Button createPrivateButton;
    [SerializeField] TMP_InputField lobbyNameInputField;

    private void Awake()
    {
        createPublicButton.onClick.AddListener(() => { KitchenGameLobby.Instance.CreateLobby(lobbyNameInputField.text, false); });
        createPrivateButton.onClick.AddListener(() => { KitchenGameLobby.Instance.CreateLobby(lobbyNameInputField.text, true); });
        closeButton.onClick.AddListener(() => { Hide(); });
    }

    private void Start()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        createPublicButton.Select();
    }
    void Hide() => gameObject.SetActive(false);
}
