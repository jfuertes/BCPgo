<?php
//require_once("config/mysql.php");

		require_once('config/mysql.php');
		$db              = new Connect();
		$dbh             = $db->enchufalo();


		$q = 'SELECT  *
				from establecimiento';

		$stmt = $dbh->prepare($q);
		$stmt->execute();
		$r = $stmt->fetchAll(PDO::FETCH_ASSOC);
		echo json_encode($r);
?>