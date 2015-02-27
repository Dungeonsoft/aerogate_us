<?php
include("common.php");
    $link=dbConnect();
	
	$email = $_POST['email'];
	$query = "SELECT * FROM `UserData` WHERE email = '". $email ."'";

    $result = mysql_query($query) or die('Query failed: ' . mysql_error());

    $num_results = mysql_num_rows($result);  

    if($num_results == 1)
    {
        $row = mysql_fetch_assoc($result);
		if(strtolower($row['email']) == strtolower($email))
		{
			$to = $email;
			$subject = "You Password/Username";
			$body = "Name: " . $row['name'] . " \n" . "Password: " . $row['password'];
			if (mail($to, $subject, $body))
			{
				echo("true");
			} 
			else 
			{
				echo("false");
			}
			$i = $num_results;
		}
		else 
		{
			echo("notFound");
		}
    }
	else 
	{
		echo("notFound");
	}
?>