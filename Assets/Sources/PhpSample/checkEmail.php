<?php
include("common.php");
	$link=dbConnect();
	
	$email = $_POST['email'];
	$query = "SELECT * FROM `UserData` WHERE email = '" . $email . "'";
    $result = mysql_query($query) or die('Query failed: ' . mysql_error());
    $num_results = mysql_num_rows($result);  

    if($num_results > 0)
    {
		for($i = 0; $i < $num_results; $i++)
		{
			$row = mysql_fetch_array($result);		 
			if(strtolower($row['email']) == strtolower($email))
			{
				echo 'true';
				$i = $num_results;
			}
			else
			{
				echo 'false';
			}
		}
    }
	else
	{
		echo 'false';
	}
?>