using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject Zombie1, Zombie2, Zombie3, Zombie4, Zombie5, Zombie6, Zombie7, Zombie8,
        Zombie9, Zombie10, Zombie11, Zombie12, Zombie13, Zombie14, Zombie15;
    MenuKontrol menuKontrol;

    private void Start()
    {
        menuKontrol = GameManager.GetComponent<MenuKontrol>();
    }

    private void Update()
    {
        if (Zombie1 == null && Zombie2 == null && Zombie3 == null && Zombie4 == null && Zombie5 == null && Zombie6 == null && Zombie7 == null && Zombie8 == null && Zombie9 == null && Zombie10 == null && Zombie11 == null && Zombie12 == null && Zombie13 == null && Zombie14 == null && Zombie15 == null)
        {
            menuKontrol.Finish();
        }
    }
}
