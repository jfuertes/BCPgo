<?php
//require_once("config/mysql.php");

		require_once('config/mysql.php');
		$db              = new Connect();
		$dbh             = $db->enchufalo();

 $q = 'select * from establecimientos';

		

		$stmt = $dbh->prepare($q);

		$stmt->execute();
		$r = $stmt->fetchAll(PDO::FETCH_ASSOC);
		echo json_encode($r);
?>