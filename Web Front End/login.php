<?php
 $dbhost = "localhost";
 $dbuser = "root";
 $dbpass = "";
 $db = "gcc_users";
 
 $conn = mysqli_connect($dbhost,$dbuser,$dbpass,$db);

		if ($conn->connect_error){
			 die("Connection failed: " . $conn->connect_error);
		}else{
			 echo "connection successful";
		}; 


	if(!empty($_POST['username']) && !empty($_POST['password'])) {  
		$user=$_POST['username'];  
		$pass=$_POST['password'];  
	   
		mysqli_select_db($conn, $db) or die("cannot select DB");  
	  
		$query1=("SELECT * FROM members WHERE ID='".$user."' AND password='".$pass."'"); 
		$query = mysqli_query($conn,$query1); 
		$numrows=mysqli_num_rows($query);  
		if($numrows!=0)  
		{  
		while($row=mysqli_fetch_assoc($query))  
		{  
		$dbusername=$row['ID'];  
		$dbpassword=$row['password'];  
		}  
	  
		if($user == $dbusername && $pass == $dbpassword)  
		{  
		session_start();  
		$_SESSION['sess_user']=$user;  
	  
		/* Redirect browser */  
		header("Location: index.html");  
		}  
		} else {  
		echo "Invalid username or password!";  
		}  
	  
	} else {  
		echo "All fields are required!";  
	}  
	

$conn->close();
?>