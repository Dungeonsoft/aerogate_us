<?php
include("common.php");
    $link=dbConnect();
	
	$deleteCode = $_GET['deleteCode'];

	$query = "DELETE FROM `UserData` WHERE deleteCode = '".$deleteCode."'";

    $result = mysql_query($query) or die('Query failed: ' . mysql_error());

    //$num_results = mysql_num_rows($result);  
?>

<p style="font: 20pt/20pt Garamond, Georgia, serif;color:#000000;">The account is now deleted</p>
<p style="font: 20pt/20pt Garamond, Georgia, serif;color:#000000;">We a sorry for wasting your time</p>
