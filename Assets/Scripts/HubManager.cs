using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class HubManager : MonoBehaviour
{

    public Animator anim;
    public GameObject[] games;
    public int current;

    private Process process;
    public GameObject aviso;

    private bool openGame;

    private void Awake()
    {
        Application.runInBackground = false;
        Application.targetFrameRate = 60;
        openGame = true;
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            ForwardAnimation();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            BackwardAnimation();
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            if (current == 0)
            {
                EjecutarG4();
            }
            if (current == 1)
            {
                EjecutarG5();
            }
            if (current == 2)
            {
                EjecutarG6();
            }
        }

        if (process != null)
        {
            aviso.SetActive(true);
            openGame = false;
        }
        if (process.HasExited)
        {
            //has exited
            process = null;
            aviso.SetActive(false);
            openGame = true;
        }
    }


    public void EjecutarG4()
    {
        if (openGame)
        {
            string path = Application.dataPath + "/../GamesMUI/G4/G4.exe";
            process = Process.Start(path);
        }
    }

    public void EjecutarG5()
    {
        if (openGame)
        {
            string path = Application.dataPath + "/../GamesMUI/G5/G5.exe";
            process = Process.Start(path);
        }
    }

    public void EjecutarG6()
    {
        if (openGame)
        {
            string path = Application.dataPath + "/../GamesMUI/G6/G6.exe";
            process = Process.Start(path);
        }
    }

    public void ForwardAnimation()
    {
        anim.Play("ForwardAnim");
        print("SUIUSIS");
        current++;
        if (current >= 3)
        {
            current = 0;
        }
        StartCoroutine(ChangeVideo());
    }

    public void BackwardAnimation()
    {
        print("SUUUU");
        anim.Play("BackwardAnim");
        current--;

        if (current <= 0)
        {
            current = 2;
        }
        StartCoroutine(ChangeVideo());
    }


   
    IEnumerator ChangeVideo()
    {
        yield return new WaitForSeconds(1);
        foreach (var item in games)
        {
            item.SetActive(false);
        }
        games[current].SetActive(true);
    }
}
