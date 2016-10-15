using UnityEngine;
using System.Collections;

public class ClimateControl : MonoBehaviour
{
    public GameObject dlight;
    public GameObject plight;
    public GameObject rain;
    public GameObject snow;
    public GameObject splitrain;
    private int countl;
    public string climate;//s -snow d- dust storm, r- rain
    private GameObject[] weathers;
    private IEnumerator Reset(float Count)
    {
        yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.
                                                //And here goes your method of resetting the game...
        yield return null;
    }
    void Stoprain_or_snow(char s)
    {
        if (s == 'r')
        {
            rain.GetComponent<EllipsoidParticleEmitter>().maxSize = 0.0F;
            rain.GetComponent<EllipsoidParticleEmitter>().minSize = 0.0F;
            splitrain.GetComponent<EllipsoidParticleEmitter>().minSize = 0.0F;
            splitrain.GetComponent<EllipsoidParticleEmitter>().maxSize = 0.0F;
        }
        if (s=='s')
        {
            snow.GetComponent<EllipsoidParticleEmitter>().maxSize = 0.0F;
            snow.GetComponent<EllipsoidParticleEmitter>().minSize = 0.0F;
        }
    }
    void Runrain_or_snow(char s)
    {
        if (s == 'r')
        {
            rain.GetComponent<EllipsoidParticleEmitter>().maxSize = 0.3F;
            rain.GetComponent<EllipsoidParticleEmitter>().minSize = 0.2F;
            splitrain.GetComponent<EllipsoidParticleEmitter>().minSize = 0.2F;
            splitrain.GetComponent<EllipsoidParticleEmitter>().maxSize = 0.3F;
        }
        if (s == 's')
        {
            snow.GetComponent<EllipsoidParticleEmitter>().maxSize = 0.35F;
            snow.GetComponent<EllipsoidParticleEmitter>().minSize = 0.25F;
        }
    }
    void Start()
    {
        countl = 1;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Something inter into trigger");
        if (coll.tag == "Player")
        {
            Debug.Log("Player inter into climate controler");
            weathers = GameObject.FindGameObjectsWithTag("Weather");

            foreach (GameObject weather in weathers)
            {
                Debug.Log("Find object weather");
                Debug.Log(weather.gameObject.GetComponent<ParticleSystem>().name);
                if (climate == "d")
                {
                    //dlight.GetComponent<Light>().intensity=3.0F;
                    plight.GetComponent<Light>().intensity = 0.0F;
                    if (weather.gameObject.GetComponent<ParticleSystem>().name == "DustStorm")
                    {
                        Debug.Log("DustStorm run");
                        weather.gameObject.GetComponent<ParticleSystem>().Play(true);
                        Stoprain_or_snow('r');
                        Stoprain_or_snow('s');
                    }
                    else
                    {
                        Debug.Log(" Not DustStorm run");
                        weather.gameObject.GetComponent<ParticleSystem>().Stop(true);
                    }
                    countl = 1;
                }
                if (climate=="r")
                {
                    countl = 0;
                    weather.gameObject.GetComponent<ParticleSystem>().Stop(true);
                    Stoprain_or_snow('s');
                    Runrain_or_snow('r');
                  //  while (dlight.GetComponent<Light>().intensity > 0.3F)
                  //  {
                  //      dlight.GetComponent<Light>().intensity = dlight.GetComponent<Light>().intensity * 0.9999F;
                  //      Debug.Log("0");
                  //  }
                  // dlight.GetComponent<Light>().intensity = 0.0F;
                    plight.GetComponent<Light>().intensity = 1.3F;
                }
                if (climate == "s")
                {
                    weather.gameObject.GetComponent<ParticleSystem>().Stop(true);
                    Stoprain_or_snow('r');
                    Runrain_or_snow('s');
                    //dlight.GetComponent<Light>().intensity = 3.0F;
                    plight.GetComponent<Light>().intensity = 0.0F;
                    countl = 1;
                }

            }
        }
    }
    void Update()
    {
        if ((climate == "r")&&(countl==0))
        {
            if (dlight.GetComponent<Light>().intensity > 0.1F)
            {
                dlight.GetComponent<Light>().intensity = dlight.GetComponent<Light>().intensity * 0.99F;
            }
            else dlight.GetComponent<Light>().intensity = 0;
        }
        else
        {
            if (countl==1)
            if (dlight.GetComponent<Light>().intensity < 2.8F)
            {
                dlight.GetComponent<Light>().intensity = dlight.GetComponent<Light>().intensity * 1.01F;
            }
            else dlight.GetComponent<Light>().intensity = 3;
        }
    }
}

