<?php
 $dbhost = "localhost";
 $dbuser = "root";
 $dbpass = "";
 $db = "gcc_users";
 
 
 $conn = mysqli_connect($dbhost,$dbuser,$dbpass,$db);

 if ($conn->connect_error){
 	 die("Connection failed: " . $conn->connect_error);
 }else{
 	 echo 'Connected Successfully';
 };


$fname = $_POST['FirstName'];
$lname = $_POST['LastName'];
$ID = $_POST['ID'];
$email = $_POST['Email'];
$sport = $_POST['Sport'];
$pword = $_POST['Password'];

$push = "INSERT INTO members(fname, lname, ID, Sport, password, email)
		 VALUES('$fname', '$lname', '$ID', '$sport', '$pword', '$email')";
		 $conn->query($push);

$conn->close();
echo 'Submission has been received your schedule will be emailed to you shortly';

?>