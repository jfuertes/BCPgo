<?php
//require_once("config/mysql.php");

		require_once('config/mysql.php');
		$db              = new Connect();
		$dbh             = $db->enchufalo();

 $id=$_POST["id"];
 $tiempo_estimado=$_POST["tiempo_estimado"];
var_dump($_POST);
 $q = 'UPDATE establecimientos SET tiempo_estimado= :tiempo_estimado where id=:id';

		

		$stmt = $dbh->prepare($q);
		$stmt->bindParam(':id',  $id, PDO::PARAM_STR);
		$stmt->bindParam(':tiempo_estimado',  $tiempo_estimado, PDO::PARAM_STR);
		$stmt->execute();
		//$r = $stmt->fetchAll(PDO::FETCH_ASSOC);
		//echo json_encode($r);
?>