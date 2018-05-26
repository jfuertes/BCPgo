<?php

			require_once('config/mysql.php');
		$db              = new Connect();
		$dbh             = $db->enchufalo();

		 	$rspta = json_decode(file_get_contents("php://input"));
		
		$id= $rspta->id;
	var_dump($id);


		$q = 'select * from establecimientos where id=:id';
			
			$stmt = $dbh->prepare($q);
			$stmt->bindParam(':id',  $id, PDO::PARAM_STR);
			
			$stmt->execute();
			//s$rpta=array('success' => 'correcto');
		$r = $stmt->fetchAll(PDO::FETCH_ASSOC);
		echo json_encode($r);

?>