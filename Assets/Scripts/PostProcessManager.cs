using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class PostProcessManager : MonoBehaviour
{
    public static PostProcessManager instance;

    
    private PostProcessVolume postProcessVolume;
    private Grain grain;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);

        postProcessVolume = GetComponent<PostProcessVolume>();

        postProcessVolume.profile.TryGetSettings(out grain);
    }

    public void EnableGrain()
    {
        grain.active = true;
    }

    public void DisableGrain() 
    {
        grain.active = false;
    }

    public void ToggleGrain()
    {
        if (grain.active)
        {
            DisableGrain();
        }
        else
        {
            EnableGrain();
        }
    }
}
