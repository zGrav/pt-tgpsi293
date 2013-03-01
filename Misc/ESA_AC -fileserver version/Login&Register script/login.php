<?php
// Connection details
$dbhost = "mysql10.000webhost.com"; //!! localhost or the ip of the server
$dbname = "a6703767_lpocss"; //!! name of the database
$dbuser = "a6703767_lpocss2"; //!! username
$dbpass = "LPOcss2012"; //!! password

$user = addslashes($_GET['username']);
$pass = addslashes($_GET['password']);

mysql_connect($dbhost, $dbuser, $dbpass)or die("3");
$verb = mysql_select_db($dbname);

if ($verb)
{
    $sql = "SELECT * FROM login WHERE username='".$user."'";
    $quer = mysql_query($sql) or die("4");
    $num = mysql_num_rows($quer);
    if ($num == 0)
    {
    echo("0");
    exit();
    }
    else
    {
    $row = mysql_fetch_object($quer);
    $passwort = $row->password;
    if ($passwort == $pass)
    {
    echo("1");
    exit();
        }
        else
        {
        echo("2");
    exit();
        }
    }
}
mysql_close();
?>