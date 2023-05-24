using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManeger : MonoBehaviour
{
    [SerializeField]
    private GameObject _soldPanel = default;
    [SerializeField]
    private GameObject _equipPanel = default;
    [SerializeField]
    private GameObject _upgradePanel = default;
    [SerializeField]
    private GameObject _statsPanel = default;
    public void HiedeUI()
    {
        _soldPanel.SetActive(false);
        _equipPanel.SetActive(false);
        _upgradePanel.SetActive(false);
    }
    public void OpenSoldUI()
    {
        _soldPanel.SetActive(true);
        _equipPanel.SetActive(false);
        _upgradePanel.SetActive(false);
    }
    public void OpenWattUI()
    {
        _equipPanel.SetActive(true);
        _soldPanel.SetActive(false);
        _upgradePanel.SetActive(false);
    }
    public void OpenUpgradeUI()
    {
        _upgradePanel.SetActive(true);
        _soldPanel.SetActive(false);
        _equipPanel.SetActive(false);
    }
}
