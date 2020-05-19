using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHP;
    public float HP;
    public float MaxArmor;
    public float Armor;

    [SerializeField] private GameObject DamagePopUp;

    public Slider ArmorBar;
    [SerializeField] private Text ArmorText;
    public Slider HPBar;
    [SerializeField] private Text HPText;

    private GameObject stats;

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Statistics");

        ArmorBar.maxValue = MaxArmor;
        ArmorBar.value = MaxArmor;
        HPBar.maxValue = MaxHP;
        HPBar.value = MaxHP;
        Armor = MaxArmor;
        HP = MaxHP;
    }

    void Update()
    {
        ArmorBar.value = Armor;
        ArmorText.text = Armor.ToString();
        HPBar.value = HP;
        HPText.text = HP.ToString();
        if (HP <= 0)
        {
            stats.SendMessage("Died", SendMessageOptions.DontRequireReceiver);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void PickUpHealth(int amount)
    {
        HP += amount;
        if (HP > 100)
        {
            HP = 100;
        }
    }

    void PickUpArmor(int amount)
    {
        Armor += amount;
        if (Armor > 100)
        {
            Armor = 100;
        }
    }

    void RecieveDamage(BulletParameters BulletParams)
    {
        int damage = BulletParams.Damage;

        if (Armor <= 0)
        {
            HP -= damage;
        }
        else
        {
            Armor -= damage;
        }
        GameObject PopUp = Instantiate(DamagePopUp, transform.position + new Vector3(0, 2, 0), transform.rotation);
        PopUp.GetComponent<DamagePopUp>().Setup(damage);
    }
}
