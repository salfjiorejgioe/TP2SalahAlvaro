using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public GameObject prefab;   // l'objet à copier (coin OU obstacle OU map)
    public int quantite = 10;   // combien on prépare au début

    private List<GameObject> liste = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < quantite; i++)
        {
            GameObject obj = Instantiate(prefab); // on crée une copie du prefab
            obj.SetActive(false);                 // on le cache
            liste.Add(obj);                       // on le garde dans la liste
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetObject()
    {
    
        for (int i = 0; i < liste.Count; i++)
        {
            if (liste[i].activeSelf == false)
            {
                liste[i].SetActive(true);   // affiche l'objet
                return liste[i];          // 
            }
        }

      
        GameObject nouveau = Instantiate(prefab);
        liste.Add(nouveau);
        return nouveau;
    }

    public void ReturnObject(GameObject obj)
    {
       
        obj.SetActive(false);
    }
}