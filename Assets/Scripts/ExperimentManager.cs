using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExperimentManager : MonoBehaviour
{
    public GameObject fixationCross;

    public ExperimenterControls controls;

    UXF.Block mainBlock;

    public RoomOscillator oscillator;
    UXF.Session session;

    public void SwitchLights(bool state)
    {
        ScreenFader fader = GetComponent<ScreenFader>();
        if (state)
        {
            fader.FadeFromBlack();
        }
        else
        {
            fader.FadeToBlack();
        }
    }

    public void ShowFixation(bool state)
    {
        fixationCross.SetActive(state);
    }

    public void ToggleOscillation(bool state)
    {
        if (state)
        {
            float period = session.settings.GetFloat("oscillate_period");
            float amp = session.settings.GetFloat("oscillate_amp_deg");
            oscillator.StartOscillation(period, amp);
        }
        else
        {
            oscillator.StopOscillation();
        }
    }

    public void Init(UXF.Session session)
    {
        this.session = session;
        mainBlock = session.CreateBlock();
    }


    public void StartAssessment(AssessmentType assessmentType)
    {
        // here we make a new trial on-the-fly
        // this allows us to have a dynamic number of assessments controlled via the UI.
        var newTrial = mainBlock.CreateTrial();
        newTrial.settings.SetValue("assessment_type", assessmentType);
        newTrial.Begin();
        Invoke("EndAssessment", newTrial.settings.GetFloat("assessment_time"));
    }


    public void TrialSetup(UXF.Trial trial)
    {
        AssessmentType type = (AssessmentType) trial.settings.GetObject("assessment_type");
        switch (type)
        {
            case AssessmentType.Vision:
                ShowFixation(true);
                break;
            case AssessmentType.NoVision:
                SwitchLights(false);
                break;
            case AssessmentType.RoomOscillate:
                ShowFixation(false);
                ToggleOscillation(true);
                break;
        }
    }


    void EndAssessment()
    {
        var currentTrial = session.CurrentTrial;
        controls.Finished((AssessmentType) currentTrial.settings.GetObject("assessment_type"));
        currentTrial.End();
    }

    public void SceneEnd(UXF.Trial trial)
    {
        AssessmentType type = (AssessmentType)trial.settings.GetObject("assessment_type");
        switch (type)
        {
            case AssessmentType.Vision:
                ShowFixation(false);
                break;
            case AssessmentType.NoVision:
                SwitchLights(true);
                break;
            case AssessmentType.RoomOscillate:
                ShowFixation(true);
                ToggleOscillation(false);
                break;
        }
    }

}


public enum AssessmentType
{
    Vision = 0, NoVision = 1, RoomOscillate = 2
}
