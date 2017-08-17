# Win10IOT-Win10Service-Project
## Questions
if you have any questions or comments please email me at code-support@sorafamily.com
## Description
Windows (version independant Vista->Win10 compatable, DotNet Dependant) Service with Win10 IOT Device for remote control operation of a computer via the service.
### Infomatic from Youtube Video

Win IOT RiPi(and others) Development for a Push Button Remote Mute for Windows 10 and Win 10 iot 

Join me on the journey through Figuring out how to make a mute button remote control for my remote entertainment PC. 
we are working with Windows 10, Windows 10 IOT, Visual Studio 2017, Arduino Studio(?) and some great nuget packages.  -- Watch live at https://www.twitch.tv/skyhoshi Or Recordings on 
Part 1: (10 hour video of live stream, I'll be cutting this up later) - https://youtu.be/K4MyibC9jHU

Process:
1. Create Windows Service to run on the remote PC. 
2. Create Logic to Mute the PC
3. Create the Push Button IOT Device
4. Create Remote Services connection [RSC] (We are using Azure Storage - Queues - as a message Queue.) (NOTE: we could use iot hub. but we aren't.. not at first - Cost is a big reason why) 
5. Update the Windows Service to monitor the RSC. 
6. Update the IOT Device to send to the RSC. 
7. Test, Test, Test, TEst, teST, TeSt, and if your not sure if it's going to work again when you put your button iot device back together, switch your Ripi or IOT device out for a different one and set it up with your code and TEST!. :D
