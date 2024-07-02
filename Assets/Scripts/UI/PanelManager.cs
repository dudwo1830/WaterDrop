using UnityEngine;

public class PanelManager : MonoBehaviour, IPanelManager
{
    [SerializeField, Header("재시작 판넬")]
    private GameObject reStartPanel;

    public void ShowReStartPanel()
    {
        reStartPanel.SetActive(true);
    }
}
