using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class WeaponSelection : MonoBehaviour
{
    [System.Serializable]
    public class Weapon
    {
        public string weaponName;
        public Sprite weaponIcon;
    }

    public GameObject upgradePanel;
    public Button[] weaponButtons;
    public List<Weapon> weapons;

    private Character character;
    private List<Weapon> randomWeapons;

    void Start()
    {
        upgradePanel.SetActive(false);
        character = FindObjectOfType<Character>();

        for (int i = 0; i < weaponButtons.Length; i++)
        {
            int index = i; // 로컬 복사본 생성
            weaponButtons[i].onClick.AddListener(() => SelectWeapon(index));
        }
    }

    public void ShowUpgradePanel()
    {
        Time.timeScale = 0f; // 게임을 일시정지합니다.
        upgradePanel.SetActive(true);
        DisplayRandomWeapons();
    }

    void DisplayRandomWeapons()
    {
        randomWeapons = GetRandomWeapons(weaponButtons.Length);

        for (int i = 0; i < weaponButtons.Length; i++)
        {
            var weaponButton = weaponButtons[i];
            var weapon = randomWeapons[i];

            weaponButton.GetComponentInChildren<Text>().text = weapon.weaponName;
            weaponButton.transform.Find("Icon").GetComponent<Image>().sprite = weapon.weaponIcon;
        }
    }

    List<Weapon> GetRandomWeapons(int count)
    {
        List<Weapon> randomWeapons = new List<Weapon>(weapons);
        for (int i = 0; i < randomWeapons.Count; i++)
        {
            Weapon temp = randomWeapons[i];
            int randomIndex = Random.Range(i, randomWeapons.Count);
            randomWeapons[i] = randomWeapons[randomIndex];
            randomWeapons[randomIndex] = temp;
        }
        return randomWeapons.GetRange(0, Mathf.Min(count, randomWeapons.Count));
    }

    void HideUpgradePanel()
    {
        Time.timeScale = 1f; // 게임을 다시 시작합니다.
        upgradePanel.SetActive(false);
    }

    void SelectWeapon(int weaponIndex)
    {
        Weapon selectedWeapon = randomWeapons[weaponIndex];
        character.SetSelectedWeapon(selectedWeapon); // 선택한 무기를 캐릭터에게 전달
        HideUpgradePanel();
    }
}