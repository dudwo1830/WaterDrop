using UnityEngine;

public class PanelManager : MonoBehaviour, IPanelManager
{
    [SerializeField, Header("����� �ǳ�")]
    private GameObject reStartPanel;

    public void ShowReStartPanel()
    {
        reStartPanel.SetActive(true);
    }
}
