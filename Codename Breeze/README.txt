Hi and thank you for downloading Codename Breeze!

This program is still in a development stage, so some features might be buggy and/or missing.

It's basically a Android controller that allows you to control your device via Keyboard/Mouse (if you're root) and view your 
device screen.

It can connect via USB cable and WiFi but needs ADB to do so. Non-rooted devices can only connect via USB.

For WiFi you must have a app that you can easily find on Market or CyanogenMod where you can just enable it on Settings->Developer Options->Enable ADB over Network
To connect to your device, pop up a command prompt, go to your ADB folder if you haven't set it on your Environment Settings, and type connect deviceip,
if you did everything correctly, you should see that it returns connected and all you need to do is open up Codename Breeze.

Working app (needs root): https://play.google.com/store/apps/details?id=com.ryosoftware.adbw&feature=search_result#?t=W251bGwsMSwyLDEsImNvbS5yeW9zb2Z0d2FyZS5hZGJ3Il0.

The requirements for this program to run are:
- Java
- Android SDK (for ADB)
- Eclipse (optional if you want to debug)
- Maven (native install)
- M2Eclipse (Maven - Eclipse plugin)
- XAMPP (if you want to run it as localhost for backoffice to work.)

The included folders are the project folders for Maven and Eclipse, I decided not to convert the Client folder to Eclipse because
you can export the client as a normal JAR file but you have to follow the steps that I left on a README inside the folder afterwards.

If you have any suggestions and encounter bugs (highly likely) please contact me at zgrav@null.net

If you also think that the external backoffice is going to hack you, the files are public at http://strikker.org/zgrav_pap

- David "z" Samuel
