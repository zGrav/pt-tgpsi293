Warning: Needs Android SDK to compile, both files are found on SDK folder\platform-tools

dx --dex --output=classes.dex codename_breezeclient.jar
aapt add codename_breezeclient.jar classes.dex