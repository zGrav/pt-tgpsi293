<?php
//Codename Breeze PHP Backoffice
//Author: David "z" Samuel
//Date: 20th February 2013

//Don't steal Source Code, read it, learn it, adapt it and give credit to original owner.
//Check out my Github if you're interested on any other project that I might have - http://github.com/zGrav
//Contact me at zgrav@null.net for more information
//Please contribute and report bugs or any new features you would like to be implemented.

$computer = addslashes($_POST['compname']); //computer name
$devicename = addslashes($_POST['device']); //device name
$connectiontype = addslashes($_POST['connection']); //connection type on device (USB/WiFi)
$deviceversion = addslashes($_POST['version']); //device version
$deviceapi = addslashes($_POST['api']); //device api
$osname = addslashes($_POST['os']); //os name

$switcharg = addslashes($_POST['arg']);

//Our argument switch that handles file/data parse.

if ($computer == null) 
{
die('No computer name specified, PHP terminated.');
}

switch($switcharg) {

case 0: //file creation

$handle = fopen("$computer."."txt", 'a') or die('Cannot open file: '."$computer."."txt");

$data = "\r\n".'Codename Breeze Logging System online.'."\r\n";

fwrite($handle, $data);

fclose($handle); 
 
echo 'File creation successful.';

break;

case 1: //program start

$data = "\r\n".'Program started at: '.date('Y-m-d H:i:s')."\r\n";

appendData($computer, $data);

echo 'Open program date to file was successful.';

break;

case 2: //program termination

$data = "\r\n".'Program terminated at: '.date('Y-m-d H:i:s')."\r\n";

appendData($computer, $data);

echo 'Close program date to file was successful.';

break;

case 3: //device connection

$data = "\r\n".'User has connected to a device at: '.date('Y-m-d H:i:s')."\r\n";

appendData($computer, $data);

echo 'Connection date to file was successful.';

break;

case 4; //device disconnection

$data = "\r\n".'User has disconnected from a device at: '.date('Y-m-d H:i:s')."\r\n";

appendData($computer, $data);

echo 'Disconnect date to file was successful.';

break;

case 5: //get device name

$data = "\r\n".'Device name: '."$devicename"."\r\n";

appendData($computer, $data);

echo 'Device name to file was successful.';

break;

case 6: //device connection type

$data = "\r\n".'Device connection type: '."$connectiontype"."\r\n";

appendData($computer, $data);

echo 'Connection type to file was successful.';

break;

case 7: //device version

$data = "\r\n".'Device Android version: '."$deviceversion"."\r\n";

appendData($computer, $data);

echo 'Device version to file was successful.';

break;

case 8: //device API

$data = "\r\n".'Device API version: '."$deviceapi"."\r\n";

appendData($computer, $data);

echo 'Device API to file was successful.';

break;

case 9: //OS name

$data = "\r\n".'Operating System: '."$osname"."\r\n";

appendData($computer, $data);

echo 'OS Name to file was successful.';

break;

default: 

echo "Invalid argument detected.";
}
//End of our switch

//Our append function

function appendData($computer, $data)
{

$append = fopen("$computer."."txt", 'a') or die('Cannot open file: '."$computer."."txt");

fwrite($append, $data);

fclose($append);

}
//End of our append function

?>