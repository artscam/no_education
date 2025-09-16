using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GuitarSpecial : MonoBehaviour
{
    // the special move uses sauce, which is charged up by corrupting students.
    // the duration of the move is proportional to sauce used
    [SerializeField]
    private SauceBarUI sauceBar;
    public int Sauce, MaxSauce;
    public GameObject FireCircle;
    private GameObject newFire;
    private Vector3 newPos;
    public UnityEvent SpecialFire;

    private void Start()
    {
        sauceBar.SetMaxSauce(MaxSauce);
        sauceBar.SetSauce(Sauce);
    }
    public void IncreaseSauce()
    {
        Sauce++;
        Sauce = Mathf.Clamp(Sauce, 0, MaxSauce);
        sauceBar.SetSauce(Sauce);
    }


    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetMouseButtonDown(1) & Sauce > 0)
            {
                SpawnFireCircle();
                EventManager.onGuitar2();
                SpecialFire.Invoke();
            }
        }

    }

    private void SpawnFireCircle()
    {
        // spawn a fire circle that attracts students, spending sauce for duration
        if (newFire)
        {
            Destroy(newFire);
            EventManager.onDestroyGuitar2();
        }
        newFire = Instantiate(FireCircle);

        newPos = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        newFire.transform.position = newPos;

        
        StartCoroutine(despawnFireCircle());

        Sauce = 0;
        sauceBar.SetSauce(Sauce);
    }

    IEnumerator despawnFireCircle()
    {
        yield return new WaitForSeconds(Sauce);
        EventManager.onDestroyGuitar2();
        Destroy(newFire);
    }
}
