using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform ShootingPoint;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private KeyCode Fire;
    [SerializeField] private KeyCode ReloadKey;

    [SerializeField] private string WeaponEquipped;
    [SerializeField] private GameObject Pistol;
    [SerializeField] private Transform PistolFirePoint;
    [SerializeField] private Weapon PistolStats;
    [SerializeField] private GameObject AssaultRifle;
    [SerializeField] private Transform AssaultRifleFirePoint;
    [SerializeField] private Weapon AssaultRifleStats;

    [SerializeField] private float FireRate;
    [SerializeField] private float FireTimer;
    [SerializeField] private int Ammo;
    [SerializeField] private int MaxMagazineAmmo;
    [SerializeField] private int AllAmmo;
    [SerializeField] private float BulletSpeed;
    [SerializeField] private bool Reloading;
    [SerializeField] private float ReloadTime;
    [SerializeField] private float TimeTakesToReload;
    [SerializeField] private int WeaponDamage;

    [SerializeField] private int CriticalChance;

    [SerializeField] private Text AmmoText;
    [SerializeField] private GameObject ReloadingText;

    private GameObject stats;
    [SerializeField] private PauseManager Pause;

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Statistics");
    }

    void Update()
    {
        if (!Pause.Paused)
        {
            if (Reloading)
            {
                ReloadingText.SetActive(true);
                ReloadTime += Time.deltaTime;
                if (ReloadTime >= TimeTakesToReload)
                {
                    ReloadTime = 0f;
                    Reloading = false;
                }
            }
            else
            {
                ReloadingText.SetActive(false);
            }

            EquipWeapon();

            GetShootInput();

            if (Input.GetKeyDown(ReloadKey))
            {
                Reload();
            }
        }

        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        AmmoText.text = Ammo + "/" + AllAmmo;
    }

    void GetShootInput()
    {
        if (Input.GetKey(Fire))
        {
            if (!Reloading)
            {
                if (Ammo >= 1)
                {
                    if (FireTimer <= 0)
                    {
                        Shoot();
                        FireTimer = FireRate;
                    }
                }
                else
                {
                    Reload();
                }
            }

            FireTimer -= Time.deltaTime;
        }
        else
        {
            FireTimer -= Time.deltaTime;
        }
    }

    void EquipWeapon()
    {
        if (WeaponEquipped == "Pistol")
        {
            WeaponDamage = PistolStats.Damage;
            FireRate = PistolStats.FireRate;
            MaxMagazineAmmo = PistolStats.MagazineSize;
            TimeTakesToReload = PistolStats.ReloadTime;
            ShootingPoint = PistolFirePoint;
            Pistol.SetActive(true);
            AssaultRifle.SetActive(false);
        }
        else if (WeaponEquipped == "Assault Rifle")
        {
            WeaponDamage = AssaultRifleStats.Damage;
            FireRate = AssaultRifleStats.FireRate;
            MaxMagazineAmmo = AssaultRifleStats.MagazineSize;
            TimeTakesToReload = AssaultRifleStats.ReloadTime;
            ShootingPoint = AssaultRifleFirePoint;
            Pistol.SetActive(false);
            AssaultRifle.SetActive(true);
        }
    }

    void Shoot()
    {
        GameObject Bullet;
        Bullet = Instantiate(BulletPrefab, ShootingPoint.position, ShootingPoint.rotation);
        Bullet.GetComponent<Rigidbody>().AddForce(-Bullet.transform.forward.normalized * BulletSpeed, ForceMode.Impulse);
        Bullet.GetComponent<Bullet>().Damage = CriticalHit();
        Bullet.GetComponent<Bullet>().ShotBy = "Player";
        stats.SendMessage("ShotFired", SendMessageOptions.DontRequireReceiver);
        Ammo--;
    }

    int CriticalHit()
    {
        int CritChance = Random.Range(1, CriticalChance + 1);

        if (CritChance == 3)
        {
            return Mathf.RoundToInt(WeaponDamage + (WeaponDamage / 2));
        }

        return WeaponDamage;
    }

    void Reload()
    {
        if (Ammo >= MaxMagazineAmmo)
        {
            Ammo = MaxMagazineAmmo;
        }
        else if (AllAmmo >= 1)
        {
            Ammo = MaxMagazineAmmo;
            AllAmmo -= MaxMagazineAmmo;

            if (AllAmmo < 0)
            {
                AllAmmo = 0;
            }
            Reloading = true;
        }
    }

    void PickupAmmo(int amount)
    {
        AllAmmo += amount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ARPickup")
        {
            WeaponEquipped = "Assault Rifle";
            Destroy(other.gameObject);
        }
    }
}
