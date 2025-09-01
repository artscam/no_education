using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentSpawner : MonoBehaviour
{
    public Student Student;
    public float speed = 3f;
    public GameObject Target;
    public GameObject playerFollow;
    public float timescale = 1f;
    float timer;
    bool spawnButton;
    public void SpawnStudent()
    {
        Student newStudent =  Instantiate(Student);
        newStudent.Target = Target;
        newStudent.playerFollow = playerFollow;
        newStudent.speed = speed;
    }
    void Start()
    {
        SpawnStudent();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if ((timer >= timescale) & MyInput())
        {
            SpawnStudent();
            timer = 0;
        }
            
    }
    private bool MyInput()
    {
        return Input.GetButton("Fire1");
    }
}
