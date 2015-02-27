<?php
  include("common.php");
	$link=dbConnect();

	$name = safe($_POST['name']);
	$pass = safe($_POST['pass']);
	$hash = safe($_POST['hash']);

	$query = "SELECT * FROM `UserData` WHERE name = '". $name ."'";
    $result = mysql_query($query) or die('Query failed: ' . mysql_error());	
    $num_results = mysql_num_rows($result);  
	
    if($num_results > 0)
    {
		$row = mysql_fetch_assoc($result);
		$real_hash = md5($name . $secretKey); 
	
		if($real_hash == $hash)
		{
			if($row['activate'] == 'Yes')
			{
				if(strtolower($row['name']) == strtolower($name))
				{
					if(strtolower($row['password']) == strtolower($pass))
					{
						$resultsHash = md5($real_hash . 'true');
						echo $resultsHash;
					}
					else
					{
						echo 'passFalse';
					}					
				}
				else 
				{
					echo 'nameFalse';
				}
			}
			else
			{
				echo 'activateFalse';
			}
		}
		else
		{
			echo 'hashFalse';
		}
    }
	else
	{
		echo 'nameFalse';
	}
?>