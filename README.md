<p align="center">
  <img src="media/icon.png" width="100">
</p>

# Posture Assessment VR

Tool for assessing postural stability/balance/sway in Virtual Reality.

<p align="center">
  <img src="media/room-oscillate.gif">
  
  <i>The oscillating room condition</i>
</p>

## Features

Assess posture in one of three conditions.
* Normal (vision).
* No vision (HMD goes dark, ask participant to close their eyes too).
* Oscillating room. Room pitch rotation oscillates at a amplitude and period that you specify.

<p align="center">
  <img src="media/room.png">
  
  <i>The virtual room used for the assessments</i>
</p>

## How to use

First download the latest [Release Build](https://github.com/immersivecognition/posture-assessment-vr/releases/tag/2) and extract the zip file to your Windows PC.

1. Make sure you have a SteamVR compatible headset set up on your PC.
2. Put participant in a headset standing in the center of your VR area.
3. Launch the SwayAssessment .exe
4. Create a new participant list (or select existing) - data will be stored next to wherever you put this list.
5. Enter the participant details.
6. From here you can perform measurements:
    * If you want height/armspan measures, ask participant to stand with controllers in hands, hold them out horizontally.
    * Click the buttons to record height/armspan. Height and armspan will be added to the participant's row in the participant list.
    * Click buttons on-screen to perform the various assessments as needed.

<p align="center">
  <img src="media/ui.png" width="200">
  
  <i>The experimenter's user interface</i>
</p>

Info:

This project is built with SteamVR. It should work with any SteamVR compatible headset and SteamVR installed.
You can change some parameters by modifying the file: `posture-assessment-vr_Data/StreamingAssets/psat-vr.json`.
Data output is just raw movement data. Calculate path length by summing the point-to-point distances observed in head movement.
