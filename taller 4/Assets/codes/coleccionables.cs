using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class coleccionables : MonoBehaviour
{
    public bool cuerda = false;
    public bool craneo = false;
    public bool oso = false;
    public bool atrapasueno = false;
    public Image imgcuerda;
    public Image imgcalaca;
    public Image imgoso;
    public Image imgatrapasueno;

    void Start()
    {
        cuerda = false;
        craneo = false;
        oso = false;
        atrapasueno = false;
        imgcuerda.gameObject.SetActive(false);
        imgcalaca.gameObject.SetActive(false);
        imgoso.gameObject.SetActive(false);
        imgatrapasueno.gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pentagrama") && cuerda == true && craneo == true && oso == true && atrapasueno == true)// sirve sin poner el == true
        {
            //ending
            SceneManager.LoadScene("endgame");
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
        }

        if (collision.gameObject.name == "cuerda")
        {
            cuerda = true;
            imgcuerda.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "craneo")
        {
            craneo = true;
            imgcalaca.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "oso")
        {
            oso = true;
            imgoso.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "atrapasuenos")
        {
            atrapasueno = true;
            imgatrapasueno.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    public void setPlayerUi()
    {
        imgatrapasueno = GameObject.Find("UIatrapasueño").GetComponent<Image>();
        imgcalaca = GameObject.Find("UIcraneo").GetComponent<Image>();
        imgoso = GameObject.Find("UIoso").GetComponent<Image>();
        imgcuerda = GameObject.Find("UIcuerda").GetComponent<Image>();
    }

    public void checkUIcollectables()
    {
        if (cuerda)
        {
            imgcuerda.gameObject.SetActive(true);
        }
        else
        {
            imgcuerda.gameObject.SetActive(false);
        }

        if (craneo)
        {
            imgcalaca.gameObject.SetActive(true);
        }
        else
        {
            imgcalaca.gameObject.SetActive(false);
        }

        if (oso)
        {
            imgoso.gameObject.SetActive(true);
        }
        else
        {
            imgoso.gameObject.SetActive(false);
        }

        if (atrapasueno)
        {
            imgatrapasueno.gameObject.SetActive(true);
        }
        else
        {
            imgatrapasueno.gameObject.SetActive(false);
        }
    }
}
