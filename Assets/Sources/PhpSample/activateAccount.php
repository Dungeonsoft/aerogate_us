<?php
include("common.php");
	$link=dbConnect();
	
	$activationCode = $_GET['activationCode'];
	
	$query = "UPDATE `UserData` SET activate = 'Yes' WHERE activationCode = '" . $activationCode . "'";

    $result = mysql_query($query) or die('Query failed: ' . mysql_error());
s
?>

<p style="font: 20pt/20pt Garamond, Georgia, serif;color:#000000;">Thank you for registering, your account a now activated </p>
<p style="font: 20pt/20pt Garamond, Georgia, serif;color:#000000;">We hope you enjoy</p>
