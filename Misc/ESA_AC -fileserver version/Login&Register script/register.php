<?php
// Connection details
$dbhost = "mysql10.000webhost.com"; //!! localhost or the ip of the server
$dbname = "a6703767_lpocss"; //!! name of the database
$dbuser = "a6703767_lpocss2"; //!! username
$dbpass = "LPOcss2012"; //!! password

$user = addslashes($_POST["username"]);
$pass = addslashes($_POST["password"]);
$hwid = addslashes($_POST["hwid"]);

mysql_connect($dbhost, $dbuser, $dbpass)or die("3");
$verb = mysql_select_db($dbname);

if ($verb)
{
    if (!empty($user) and !empty($pass) and !empty($hwid))
    {
        if ( mysql_num_rows( mysql_query( "SELECT * FROM login WHERE username='".$user."'" ) ) == 0 ) {
            $sqlquery = "INSERT INTO login (username, password) VALUES('$user','$pass')";
            $results = mysql_query($sqlquery);
            $hwidfile = fopen("hwid.php","a");
            fwrite($hwidfile, $hwid."\r\n");
            fclose($hwidfile);
            echo("1");
        }else{
            echo("2");
        }
    }else{
        echo("0");
    }
}
mysql_close();
?>