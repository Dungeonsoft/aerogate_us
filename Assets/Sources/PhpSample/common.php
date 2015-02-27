<?php

$dbName = 'Databasename';
$secretKey = "12345"; # Change this value to match the value in unity

function dbConnect()
{
	global  $dbName;
	global  $secretKey;

	$link = mysql_connect('Host', 'User', 'Pass');
	
	if(!$link)
	{
		fail("Couldn´t connect to database server");
	}
	
	if(!@mysql_select_db($dbName))
	{
		fail("Couldn´t find database $dbName");
	}
	
	return $link;
	}
	
function safe($variable)
{
	$variable = addslashes(trim($variable));
	return $variable;
}

function fail($errorMsg)
{
	print $errorMsg;
	exit;
}

?>