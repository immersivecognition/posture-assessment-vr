using UnityEngine;
using Valve.VR;

public class ScreenFader : MonoBehaviour
{
    private float fadeDuration = 0.5f;
    public void FadeToBlack()
    {
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.black, fadeDuration);
    }
    public void FadeFromBlack()
    {
        //set start color
        SteamVR_Fade.Start(Color.black, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.clear, fadeDuration);
    }
}