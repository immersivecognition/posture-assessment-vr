using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperimenterControls : MonoBehaviour
{

    public UXF.Session session;
    public ExperimentManager experiment;
    public int logLines = 25;
    public Text logText;
    public List<string> log = new List<string>();

    public Text currentHeight;
    string heightFormatText;
    public Text currentArmSpan;
    string armSpanFormatText;

    public UXF.ParticipantListSelection ppListSelect;

    public BodyMeasurementTool measurementTool;

    public GameObject participantUI;

    // Use this for initialization
    void Start()
    {
        heightFormatText = currentHeight.text;
        armSpanFormatText = currentArmSpan.text;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // get height, armspan
        currentHeight.text = string.Format(heightFormatText, measurementTool.CalculateHeight());
        currentArmSpan.text = string.Format(armSpanFormatText, measurementTool.CalculateArmSpan());
    }

    public void RecordHeight()
    {

        // doing this measurement and updating the participant list CSV isn't ideal,
        // but it allows us to easily load retrieve the participants' height from
        // another task built in UXF

        float h = measurementTool.CalculateHeight();
        LogMessage(string.Format("Saving height value: {0:0.00} to participant list", h));
        ppListSelect.UpdateDatapoint(session.ppid, "height", h);
        ppListSelect.CommitCSV();

        // make pp UI change position according to height
        Vector3 pos = participantUI.transform.localPosition;
        pos.y = h;
        participantUI.transform.localPosition = pos;
    }

    public void RecordArmSpan()
    {
        float a = measurementTool.CalculateArmSpan();
        LogMessage(string.Format("Saving armspan value: {0:0.00} to participant list", a));
        ppListSelect.UpdateDatapoint(session.ppid, "armSpan", a);
        ppListSelect.CommitCSV();
    }

    public void StartTrial(int assessmentType)
    {
        if (session.InTrial)
        {
            LogMessage("(!) Wait for previous trial to finish");
            return;
        }
        experiment.StartAssessment((AssessmentType)assessmentType);
        LogMessage(string.Format("Started assessment: {0}", (AssessmentType)assessmentType));
    }

    public void LogMessage(string s)
    {
        Debug.Log(s);
        log.Insert(0, s);

        string newLogText = string.Empty;
        for (int i = logLines - 1; i >= 0; i--)
        {
            if (i < log.Count)
            {
                newLogText += log[i] + "\n\r";
            }
        }

        logText.text = newLogText;

    }

    public void Finished(AssessmentType assessmentType)
    {
        LogMessage(string.Format("Finished assessment: {0}", assessmentType));
    }


    public void QueueQuit()
    {
        session.End();
    }

}
