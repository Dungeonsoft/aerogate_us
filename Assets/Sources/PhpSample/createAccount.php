<?php
include("common.php");
	$link=dbConnect();
	
	$name = safe($_POST['name']);
	$password = safe($_POST['password']);
	$email = $_POST['email'];
	$activationCode = safe($_POST['activationCode']);
	$activationURL = safe($_POST['activationURL']);
	$deleteCode = safe($_POST['deleteCode']);
	$deleteAccountURL = safe($_POST['deleteAccountURL']);
	$gameName = safe($_POST['gameName']);
	$hash = safe($_POST['hash']);

    $real_hash = md5($name . $secretKey); 
	
    if($real_hash == $hash)
	{ 
		$query = "INSERT INTO $dbName .`UserData` (`id`, `name`, `password`, `email`, `activate`, `activationCode`, `deleteCode`) VALUES (NULL, '$name', '$password', '$email', 'No', '$activationCode', '$deleteCode');"; 
		$result = mysql_query($query) or die('Query failed: ' . mysql_error());

		$to = $email;
		$subject = "Activate Account";
		
		$body = "Good day \n" . 
				"Someone claiming to be " . $name . " has used this email to create an account for " . $gameName . "\n" . 
				"If it was not you who created this account, no further action is required on you behalf but, if you want, simply click the relevant link below to cancel this account immediately." . "\n" .
				"If you did create the account, please click the relevant link, below, to activate your account for " . $gameName .". \n \n" .
				"Activate your account - " . $activationURL . "activationCode=" . $activationCode ."\n" .
				"Cancel this account immediately - " . $deleteAccountURL . "deleteCode=" . $deleteCode ."\n \n" .				
				"Thank you for registerring for " . $gameName;
		
		
		if (mail($to, $subject, $body)) 
		{
			echo("true");
		} 
		else 
		{
			echo("emailFalse");
		}
	}
	else
	{
		echo 'secretKeyFalse';
	}
?>